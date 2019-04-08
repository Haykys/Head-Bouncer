﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShredderNeutral : MonoBehaviour
{
    string BouncingObject = "Bouncing Object";

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        GameObject otherGameObject = otherCollider.gameObject;
        if (otherGameObject.layer == LayerMask.NameToLayer(BouncingObject))
        {
            Destroy(otherGameObject);
        }
    }
}
