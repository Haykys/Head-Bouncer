using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BouncingStuff : MonoBehaviour
{
    // config params
    private float bouncerSpawnDelay = 3f;
    private float xPushMin = 3f;
    private float xPushMax = 3.5f;
    private float yPush = 4f;
    private float gravityScale = 1f;
    private bool withKnife;

    // cached ref
    [SerializeField] GameObject[] bouncers;
    GameSession gameSession;

    public float BouncerSpawnDelay { get => bouncerSpawnDelay; set => bouncerSpawnDelay = value; }
    public float XPushMin { get => xPushMin; set => xPushMin = value; }
    public float XPushMax { get => xPushMax; set => xPushMax = value; }
    public float YPush { get => yPush; set => yPush = value; }
    public float GravityScale { get => gravityScale; set => gravityScale = value; }
    public bool WithKnife { get => withKnife; set => withKnife = value; }

    IEnumerator Start()
    {
        // Use to later implement progresive difficulty with higher score
        gameSession = FindObjectOfType<GameSession>();

        while (true)
        {
            yield return new WaitForSeconds(bouncerSpawnDelay);
            SpawnBouncer();
        }
    }

    private void SpawnBouncer()
    {
        GameObject bouncer;

        if (WithKnife)
        {
            bouncer = bouncers[Random.Range(0, bouncers.Length)];
        } else
        {
            bouncer = bouncers[Random.Range(1, bouncers.Length)];

        }
        Spawn(bouncer);
    }

    private void Spawn(GameObject bouncer)
    {
        Vector2 bouncerSpawnPossition = transform.position;
        GameObject newBouncer = Instantiate(bouncer, bouncerSpawnPossition, transform.rotation * Quaternion.Euler(180, 0, 0)) as GameObject;
        Rigidbody2D newBouncerRB = newBouncer.GetComponent<Rigidbody2D>();

        // Launch the bouncer given the direction
        newBouncerRB.velocity = new Vector2(Random.Range(XPushMin, XPushMax), YPush);
        newBouncerRB.gravityScale = GravityScale;

        newBouncer.transform.parent = transform;
    }

}
