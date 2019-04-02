using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmitterSpawner : MonoBehaviour
{
    //config params
    private bool spawnedFirstEmitter = false;

    // cached ref
    [SerializeField] GameObject emittor;
    PlayerBehavior playerBehavior;
    GameSession gameSession;

    private void Start()
    {
        playerBehavior = FindObjectOfType<PlayerBehavior>();
        gameSession = FindObjectOfType<GameSession>();
    }

    private void Update()
    {
        SpawnEmitter();
    }

    /// <summary>
    /// Spawns an emitter at the location
    /// </summary>
    public void SpawnEmitter()
    {
        if (playerBehavior.HasMoved)
        {
            if(gameSession.CurrentScore <= 10 && !spawnedFirstEmitter)
            {
                Vector2 emittorSpawnPossition = new Vector2(transform.position.x, transform.position.y + 5f);
                GameObject newEmitter = Instantiate(emittor, emittorSpawnPossition, Quaternion.identity);
                newEmitter.transform.parent = transform;

                spawnedFirstEmitter = true;
            }
        }
    }
}
