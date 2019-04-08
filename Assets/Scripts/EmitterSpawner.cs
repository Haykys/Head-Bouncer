using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmitterSpawner : MonoBehaviour
{
    //config params
    private bool spawnedFirstEmitter = false;
    private bool spawnedSecondEmitter = false;
    private bool spawnedThirdEmitter = false;
    private bool spawnedForthEmitter = false;
    private bool spawnedFifthEmitter = false;

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
            if (gameSession.CurrentScore < 10 && !spawnedFirstEmitter)
            {
                Vector2 emittorSpawnPossition = new Vector2(transform.position.x, transform.position.y + 5);
                GameObject newEmitter = Instantiate(emittor, emittorSpawnPossition, Quaternion.identity);
                newEmitter.transform.parent = transform;

                spawnedFirstEmitter = true;
            }
            else if (gameSession.CurrentScore >= 10 && !spawnedSecondEmitter)
            {
                FindObjectOfType<CameraBehavior>().CameraMovementSpeed = 1.5f;
                spawnedSecondEmitter = SpawnNewEmiter(2f, 7, 4, 5, 2, 3, 2, 3, 0.8f);
            }
            else if (gameSession.CurrentScore >= 30 && !spawnedThirdEmitter)
            {
                FindObjectOfType<CameraBehavior>().CameraMovementSpeed = 2f;
                spawnedThirdEmitter = SpawnNewEmiter(3f, 3, 5, 6, 2, 3, 7, 8, 0.7f);
            } else if (gameSession.CurrentScore >= 80 && !spawnedForthEmitter)
            {
                FindObjectOfType<CameraBehavior>().CameraMovementSpeed = 3f;
                spawnedForthEmitter = SpawnNewEmiter(4f, 2, 6, 7, 2, 4, 8, 9, 0.8f);
            } else if (gameSession.CurrentScore >= 150 && !spawnedFifthEmitter)
            {
                FindObjectOfType<CameraBehavior>().CameraMovementSpeed = 4f;
                spawnedFifthEmitter = SpawnNewEmiter(5f, 9, 7, 8, 2, 4, 1, 2, 0.6f);
            }
        }
    }

    private bool SpawnNewEmiter(float cameraMovemntSpeed, int spawnPosition, int bouncerSpawnDelayMin, int bouncerSpawnDelayMax,
        int xPushMin, int xPushMax, int yPushMin, int yPushMax, float gravityScale)
    {
        FindObjectOfType<CameraBehavior>().CameraMovementSpeed = cameraMovemntSpeed;
        Vector2 emittorSpawnPossition = new Vector2(transform.position.x, transform.position.y + spawnPosition);
        GameObject newEmitter = Instantiate(emittor, emittorSpawnPossition, Quaternion.identity);

        newEmitter.GetComponent<BouncingStuff>().BouncerSpawnDelayMin = bouncerSpawnDelayMin;
        newEmitter.GetComponent<BouncingStuff>().BouncerSpawnDelayMax = bouncerSpawnDelayMax;
        newEmitter.GetComponent<BouncingStuff>().XPushMin = xPushMin;
        newEmitter.GetComponent<BouncingStuff>().XPushMax = xPushMax;
        newEmitter.GetComponent<BouncingStuff>().YPushMin = yPushMin;
        newEmitter.GetComponent<BouncingStuff>().YPushMax = yPushMax;
        newEmitter.GetComponent<BouncingStuff>().GravityScale = gravityScale;

        newEmitter.transform.parent = transform;

        return true;
    }
}
