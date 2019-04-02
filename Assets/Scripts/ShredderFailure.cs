using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShredderFailure : MonoBehaviour
{
    // Constants
    string BouncingObject = "Bouncing Object";

    // Config params
    GameSession gameSession;
    [SerializeField] GameObject player;

    private void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        GameObject otherGameObject = otherCollider.gameObject;
        if(otherGameObject.layer == LayerMask.NameToLayer(BouncingObject))
        {
            GameObject[] bouncingObjects = GameObject.FindGameObjectsWithTag(BouncingObject);

            for (int i = 0; i < bouncingObjects.Length; i++)
            {
                bouncingObjects[i].SetActive(false);
            }

            player.SetActive(false);
            Destroy(otherGameObject);
            gameSession.ResetGame();
        }
    }
}
