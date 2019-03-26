using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShredderFailure : MonoBehaviour
{
    string BouncingObject = "Bouncing Object";

    GameSession gameSession;

    private void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        GameObject otherGameObject = otherCollider.gameObject;
        if(otherGameObject.layer == LayerMask.NameToLayer(BouncingObject))
        {
            Destroy(otherGameObject);
            gameSession.ResetGame();
        }
    }
}
