using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShredderNeutral : MonoBehaviour
{
    // Constants
    string BouncingObject = "Bouncing Object";

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        GameObject otherGameObject = otherCollider.gameObject.transform.parent.gameObject;
        if (otherGameObject.tag == BouncingObject)
        {
            Destroy(otherGameObject);
        }
    }
}
