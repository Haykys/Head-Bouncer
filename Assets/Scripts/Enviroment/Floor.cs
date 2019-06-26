using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Destructible2D;
using System;
using SA.CrossPlatform.UI;

public class Floor : MonoBehaviour
{
    // Constants
    const string BouncingObject = "Bouncing Object";
    const string NonBouncingObject = "Non Bouncing Object";
    const string DestroyedBouncingObject = "Destroyed Bouncing Object";
    const string EmissionObject = "Emission Object";
    const string Player = "Player";

    //config params
    [Header("SFX")]
    [SerializeField] AudioClip bounceFailSound;
    [SerializeField] [Range(0, 1)] float bounceFailSounddVolume = 0.7f;
    [SerializeField] float waitTime = 2.0f;

    private bool isGameOver = false;

    // cached ref
    GameSession gameSession;
    PlayerHealth playerHealth;
    GameObject player;
    PauseMenuBehaviour pauseMenuBehaviour;
    LevelLoader levelLoader;
    RewardedGoogleAd rewardedGoogleAd;
    GameObject[] bouncingObjects;

    public bool IsGameOver { get => isGameOver; set => isGameOver = value; }

    void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
        playerHealth = FindObjectOfType<PlayerHealth>();
        pauseMenuBehaviour = FindObjectOfType<PauseMenuBehaviour>();
        levelLoader = FindObjectOfType<LevelLoader>();
        rewardedGoogleAd = FindObjectOfType<RewardedGoogleAd>();

        player = GameObject.FindGameObjectWithTag(Player);
    }

    private void Update()
    {
        bouncingObjects = GameObject.FindGameObjectsWithTag(BouncingObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject otherGameObject = collision.collider.gameObject.transform.parent.gameObject;

        if (otherGameObject.tag == BouncingObject)
        {
            AudioSource.PlayClipAtPoint(bounceFailSound, transform.position, bounceFailSounddVolume);

            playerHealth.DecreaseHealth(1);
            if (playerHealth.Health < 1)
            {
                HandleFracture(otherGameObject, collision);
                HandleFracture(otherGameObject, collision);

                IsGameOver = true;

                StartCoroutine(WaitForAllObjectToBeDestroyed(otherGameObject));
            }
            else
            {
                // Need to call this piece of code twice because of the bug in the asset
                HandleFracture(otherGameObject, collision);
                HandleFracture(otherGameObject, collision);
            }
        }
    }

    private IEnumerator WaitForAllObjectToBeDestroyed(GameObject otherGameObject)
    { 
        yield return new WaitUntil(() => bouncingObjects.Length <= 0);

        StartCoroutine(GameOver(otherGameObject));
    }

    private IEnumerator GameOver(GameObject otherGameObject)
    {
        yield return new WaitForSeconds(waitTime);

        IsGameOver = false;

        if (Application.internetReachability == NetworkReachability.NotReachable || !InitializeGoogleAds.AdInitialized)
        {
            SaveLastAndBestScore();
            levelLoader.LoadMainMenu();
            yield break;
        }

        if (rewardedGoogleAd.AdShown)
        {
            SaveLastAndBestScore();
            levelLoader.LoadMainMenu();
            if (PlayerPrefsController.GetBestScore() > 60 && PlayerPrefsController.GetRateApp() == false)
            {
                PlayerPrefsController.SetRateApp(true);
                UM_ReviewController.RequestReview();
            }
            yield break;
        }

        pauseMenuBehaviour.HidePauseButton();

        player.GetComponent<Renderer>().enabled = false;
        Destroy(otherGameObject);
        gameSession.ResetGame();
        SaveLastAndBestScore();
        yield break;
    }

    private void SaveLastAndBestScore()
    {
        if (PlayerPrefsController.GetBestScore() < gameSession.CurrentScore)
        {
            PlayerPrefsController.SetBestScore(gameSession.CurrentScore);
        }

        PlayerPrefsController.SetLastScore(gameSession.CurrentScore);
    }

    private void HandleFracture(GameObject otherGameObject, Collision2D collision)
    {
        otherGameObject.GetComponent<D2dFracturer>().Fracture();
        otherGameObject.tag = DestroyedBouncingObject;
        otherGameObject.GetComponent<D2dDestroyer>().enabled = true;
    }
}
