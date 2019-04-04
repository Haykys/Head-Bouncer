using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BouncingStuff : MonoBehaviour
{
    // config params
    [SerializeField] float bouncerSpawnDelayMin = 1f;
    [SerializeField] float bouncerSpawnDelayMax = 5f;
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 6f;

    // cached ref
    [SerializeField] GameObject bouncer;
    GameSession gameSession;

    IEnumerator Start()
    {
        // Use to later implement progresive difficulty with higher score
        gameSession = FindObjectOfType<GameSession>();

        while (true)
        {
            yield return new WaitForSeconds(Random.Range(bouncerSpawnDelayMin, bouncerSpawnDelayMax));
            SpawnBouncer();
        }
    }

    private void Update()
    {

    }

    private void SpawnBouncer()
    {
        Spawn(bouncer);
    }

    private void Spawn(GameObject bouncer)
    {
        Vector2 bouncerSpawnPossition = transform.position;
        GameObject newBouncer = Instantiate(bouncer, bouncerSpawnPossition, Quaternion.identity);
        Rigidbody2D newBouncerRB = newBouncer.GetComponent<Rigidbody2D>();

        // Launch the bouncer given the direction
        newBouncerRB.velocity = new Vector2(xPush, yPush);

        newBouncer.transform.parent = transform;
    }

}
