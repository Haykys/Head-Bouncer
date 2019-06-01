using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Destructible2D;

public class Floor : MonoBehaviour
{
    // Constants
    const string BouncingObject = "Bouncing Object";
    const string NonBouncingObject = "Non Bouncing Object";
    const string DestroyedBouncingObject = "Destroyed Bouncing Object";
    const string Player = "Player";

    //config params
    [Header("SFX")]
    [SerializeField] AudioClip bounceFailSound;
    [SerializeField] [Range(0, 1)] float bounceFailSounddVolume = 0.7f;

    // Cached ref
    GameSession gameSession;
    PlayerHealth playerHealth;
    GameObject player;

    void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
        playerHealth = FindObjectOfType<PlayerHealth>();
        player = GameObject.FindGameObjectWithTag(Player);
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
                #region Game Over
                GameObject[] bouncingObjects = GameObject.FindGameObjectsWithTag(BouncingObject);

                for (int i = 0; i < bouncingObjects.Length; i++)
                {
                    bouncingObjects[i].SetActive(false);
                }

                player.GetComponent<Renderer>().enabled = false; ;
                Destroy(otherGameObject);
                gameSession.ResetGame();

                if (PlayerPrefsController.GetBestScore() < gameSession.CurrentScore)
                {
                    PlayerPrefsController.SetBestScore(gameSession.CurrentScore);
                }

                PlayerPrefsController.SetLastScore(gameSession.CurrentScore);
            }
            else
            {
                // Need to call this piece of code twice because of the bug in the asset
                HandleFracture(otherGameObject, collision);
                HandleFracture(otherGameObject, collision);
            }
            #endregion
        }
    }

    private void HandleFracture(GameObject otherGameObject, Collision2D collision)
    {
        otherGameObject.GetComponent<D2dFracturer>().Fracture();
        otherGameObject.tag = DestroyedBouncingObject;
        otherGameObject.GetComponent<D2dDestroyer>().enabled = true;
    }
}
