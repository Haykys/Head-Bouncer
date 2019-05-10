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
    private bool spawnedSixthEmitter = false;
    private bool spawnedSeventhEmitter = false;
    private bool spawnedEigthEmitter = false;
    private bool spawnedNinthEmitter = false;
    private bool spawnedTenthEmitter = false;

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
            if (gameSession.CurrentScore < 5 && !spawnedFirstEmitter)
            {
                Vector2 emittorSpawnPossition = new Vector2(transform.position.x, transform.position.y + 5f);
                GameObject newEmitter = Instantiate(emittor, emittorSpawnPossition, Quaternion.identity);
                newEmitter.transform.parent = transform;

                spawnedFirstEmitter = true;
            }
            else if (gameSession.CurrentScore >= 5 && !spawnedSecondEmitter)
            {
                spawnedSecondEmitter = SpawnNewEmiter(5f, 4f, 2f, 6f, 1f, false);
            }
            else if (gameSession.CurrentScore >= 15 && !spawnedThirdEmitter)
            {
                FindObjectOfType<CameraBehavior>().CameraMovementSpeed = 2f;
                spawnedThirdEmitter = SpawnNewEmiter(5f, 5f, 1.2f, 8f, 1f, false);
            } else if (gameSession.CurrentScore >= 30 && !spawnedForthEmitter)
            {
                spawnedForthEmitter = SpawnNewEmiter(3f, 4f, 3f, 5f, 1f, false);
            } else if (gameSession.CurrentScore >= 50 && !spawnedFifthEmitter)
            {
                FindObjectOfType<CameraBehavior>().CameraMovementSpeed = 3f;
                spawnedFifthEmitter = SpawnNewEmiter(3f, 5f, 2f, 7f, 1f, false);
            } else if (gameSession.CurrentScore >= 80 && !spawnedSixthEmitter)
            {
                spawnedSixthEmitter = SpawnNewEmiter(3f, 6f, 2.5f, 10f, 1f, false);
            } else if (gameSession.CurrentScore >= 120 && !spawnedSeventhEmitter)
            {
                FindObjectOfType<CameraBehavior>().CameraMovementSpeed = 4f;
                spawnedSeventhEmitter = SpawnNewEmiter(6f, 5f, 2f, 5f, 1f, false);
            } else if (gameSession.CurrentScore >= 170 && !spawnedEigthEmitter)
            {
                spawnedEigthEmitter = SpawnNewEmiter(6f, 10f, 1.3f, 7f, 0.9f, false);
            } else if (gameSession.CurrentScore >= 230 && !spawnedNinthEmitter)
            {
                FindObjectOfType<CameraBehavior>().CameraMovementSpeed = 3f;
                spawnedNinthEmitter = SpawnNewEmiter(6f, 7.5f, 1f, 8f, 0.9f, false);
            } else if (gameSession.CurrentScore >= 300 && !spawnedTenthEmitter)
            {
                FindObjectOfType<CameraBehavior>().CameraMovementSpeed = 4f;
                spawnedTenthEmitter = SpawnNewEmiter(4f, 12f, 1.5f, 10f, 0.9f, false);
            }
        }
    }

    private bool SpawnNewEmiter(float spawnPosition, float bouncerSpawnDelay,
        float xPush, float yPush, float gravityScale, bool withKnife)
    {
        Vector2 emittorSpawnPossition = new Vector2(transform.position.x, transform.position.y + spawnPosition);
        GameObject newEmitter = Instantiate(emittor, emittorSpawnPossition, Quaternion.identity);

        newEmitter.GetComponent<BouncingStuff>().BouncerSpawnDelay = bouncerSpawnDelay;
        newEmitter.GetComponent<BouncingStuff>().XPush = xPush;
        newEmitter.GetComponent<BouncingStuff>().YPush = yPush;
        newEmitter.GetComponent<BouncingStuff>().GravityScale = gravityScale;
        newEmitter.GetComponent<BouncingStuff>().WithKnife = withKnife;
        gameSession.IncrementDifficulty();

        newEmitter.transform.parent = transform;

        return true;
    }
}
