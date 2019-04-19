using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShredderFailure : MonoBehaviour
{
    // Constants
    const string BouncingObject = "Bouncing Object";
    const string NonBouncingObject = "Non Bouncing Object";

    // Config params
    GameSession gameSession;
    PlayerHealth playerHealth;
    [SerializeField] GameObject player;

    private void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
        playerHealth = FindObjectOfType<PlayerHealth>();
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        GameObject otherGameObject = otherCollider.gameObject;
        if(otherGameObject.layer == LayerMask.NameToLayer(BouncingObject))
        {
            playerHealth.DecreaseHealth(1);
            if(playerHealth.Health <= 0)
            {
                #region Game Over
                GameObject[] bouncingObjects = GameObject.FindGameObjectsWithTag(BouncingObject);

                for (int i = 0; i < bouncingObjects.Length; i++)
                {
                    bouncingObjects[i].SetActive(false);
                }

                player.SetActive(false);
                Destroy(otherGameObject);
                gameSession.ResetGame();

                if (PlayerPrefsController.GetBestScore() < gameSession.CurrentScore)
                {
                    PlayerPrefsController.SetBestScore(gameSession.CurrentScore);
                }

                PlayerPrefsController.SetLastScore(gameSession.CurrentScore);
            }
            else if (otherGameObject.layer == LayerMask.NameToLayer(NonBouncingObject))
            {
                gameSession.AddToScore(1);
                Destroy(otherGameObject);
            }
            #endregion
        }
    }
}
