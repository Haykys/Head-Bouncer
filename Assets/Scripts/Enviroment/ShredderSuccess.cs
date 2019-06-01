using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShredderSuccess : MonoBehaviour
{

    string BouncingObject = "Bouncing Object";

    //config params
    [Header("SFX")]
    [SerializeField] AudioClip[] bounceSuccessSound;
    [SerializeField] [Range(0, 1)] float bounceSuccessSoundVolume = 0.7f;

    // cached ref
    GameSession gameSession;

    private void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        GameObject otherGameObject = otherCollider.gameObject.transform.parent.gameObject;
        if (otherGameObject.tag == BouncingObject)
        {
            AudioClip clip = bounceSuccessSound[Random.Range(0, bounceSuccessSound.Length - 1)];
            AudioSource.PlayClipAtPoint(clip, transform.position, bounceSuccessSoundVolume);

            gameSession.AddToScore(1);
            gameSession.AddPoints(1);
            Destroy(otherGameObject);
        }
    }
}
