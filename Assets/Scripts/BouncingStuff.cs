using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BouncingStuff : MonoBehaviour
{
    // config params
    private int bouncerSpawnDelayMin = 2;
    private int bouncerSpawnDelayMax = 3;
    private int xPushMin = 2;
    private int xPushMax = 4;
    private int yPushMin = 3;
    private int yPushMax = 4;
    private float gravityScale = 1;

    // cached ref
    [SerializeField] GameObject bouncer;
    GameSession gameSession;

    public int BouncerSpawnDelayMin { get => bouncerSpawnDelayMin; set => bouncerSpawnDelayMin = value; }
    public int BouncerSpawnDelayMax { get => bouncerSpawnDelayMax; set => bouncerSpawnDelayMax = value; }
    public int XPushMin { get => xPushMin; set => xPushMin = value; }
    public int XPushMax { get => xPushMax; set => xPushMax = value; }
    public int YPushMin { get => yPushMin; set => yPushMin = value; }
    public int YPushMax { get => yPushMax; set => yPushMax = value; }
    public float GravityScale { get => gravityScale; set => gravityScale = value; }

    IEnumerator Start()
    {
        // Use to later implement progresive difficulty with higher score
        gameSession = FindObjectOfType<GameSession>();

        while (true)
        {
            yield return new WaitForSeconds(Random.Range(BouncerSpawnDelayMax, BouncerSpawnDelayMax));
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
        newBouncerRB.velocity = new Vector2(Random.Range(XPushMin,XPushMax), Random.Range(YPushMin, YPushMax));
        newBouncerRB.gravityScale = GravityScale;

        newBouncer.transform.parent = transform;
    }

}
