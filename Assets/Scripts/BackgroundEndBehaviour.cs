using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundEndBehaviour : MonoBehaviour
{
    // constants
    string Player = "Player";

    // config params
    [Tooltip("How much time to wait before destroyying the background after reaching the end")]
    [SerializeField] float destroyTime = 1.5f;

    private void OnTriggerEnter(Collider otherCollider)
    {
        // First check if we collided with the player
        if (otherCollider.gameObject.layer == LayerMask.NameToLayer(Player))
        {
            // If we did, spawn a new tile
            GameObject.FindObjectOfType<GameController>().SpawnNextBackground();

            //And destroy this entire tile after a short delay
            Destroy(transform.parent.gameObject, destroyTime);
        }
    }
}
