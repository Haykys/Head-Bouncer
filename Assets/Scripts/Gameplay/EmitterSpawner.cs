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

    private int firstDifficultyThreshold = 5;
    private int secondDifficultyThreshold = 15;
    private int thirdDifficultyThreshold = 30;
    private int forthDifficultyThreshold = 50;
    private int fifthDifficultyThreshold = 80;
    private int sixthDifficultyThreshold = 120;
    private int seventhDifficultyThreshold = 170;
    private int eigthDifficultyThreshold = 230;
    private int ninthDifficultyThreshold = 300;

    public int FirstDifficultyThreshold { get => firstDifficultyThreshold; set => firstDifficultyThreshold = value; }
    public int SecondDifficultyThreshold { get => secondDifficultyThreshold; set => secondDifficultyThreshold = value; }
    public int ThirdDifficultyThreshold { get => thirdDifficultyThreshold; set => thirdDifficultyThreshold = value; }
    public int ForthDifficultyThreshold { get => forthDifficultyThreshold; set => forthDifficultyThreshold = value; }
    public int FifthDifficultyThreshold { get => fifthDifficultyThreshold; set => fifthDifficultyThreshold = value; }
    public int SixthDifficultyThreshold { get => sixthDifficultyThreshold; set => sixthDifficultyThreshold = value; }
    public int SeventhDifficultyThreshold { get => seventhDifficultyThreshold; set => seventhDifficultyThreshold = value; }
    public int EigthDifficultyThreshold { get => eigthDifficultyThreshold; set => eigthDifficultyThreshold = value; }
    public int NinthDifficultyThreshold { get => ninthDifficultyThreshold; set => ninthDifficultyThreshold = value; }

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
                Vector2 emittorSpawnPossition = new Vector2(transform.position.x, transform.position.y + 6f);
                GameObject newEmitter = Instantiate(emittor, emittorSpawnPossition, Quaternion.identity);
                newEmitter.transform.parent = transform;

                spawnedFirstEmitter = true;
            }
            else if (gameSession.CurrentScore >= FirstDifficultyThreshold && !spawnedSecondEmitter)
            {
                spawnedSecondEmitter = SpawnNewEmiter(6f, 4f, 1.5f, 2.3f, 6f, 0.9f, false);
            }
            else if (gameSession.CurrentScore >= SecondDifficultyThreshold && !spawnedThirdEmitter)
            {
                FindObjectOfType<CameraBehavior>().CameraMovementSpeed = 2f;
                spawnedThirdEmitter = SpawnNewEmiter(6f, 5f, 1.2f, 1.5f, 8f, 0.9f, false);
            } else if (gameSession.CurrentScore >= ThirdDifficultyThreshold && !spawnedForthEmitter)
            {
                spawnedForthEmitter = SpawnNewEmiter(4f, 4f, 2.5f, 3.3f, 6f, 0.9f, false);
            } else if (gameSession.CurrentScore >= ForthDifficultyThreshold && !spawnedFifthEmitter)
            {
                FindObjectOfType<CameraBehavior>().CameraMovementSpeed = 3f;
                spawnedFifthEmitter = SpawnNewEmiter(4f, 5f, 1.5f, 2.3f, 7f, 0.9f, false);
            } else if (gameSession.CurrentScore >= FifthDifficultyThreshold && !spawnedSixthEmitter)
            {
                spawnedSixthEmitter = SpawnNewEmiter(4f, 6f, 2f, 2.8f, 7f, 0.9f, false);
            } else if (gameSession.CurrentScore >= SixthDifficultyThreshold && !spawnedSeventhEmitter)
            {
                FindObjectOfType<CameraBehavior>().CameraMovementSpeed = 4f;
                spawnedSeventhEmitter = SpawnNewEmiter(7f, 5f, 1.5f, 2.3f, 5f, 0.9f, false);
            } else if (gameSession.CurrentScore >= SeventhDifficultyThreshold && !spawnedEigthEmitter)
            {
                spawnedEigthEmitter = SpawnNewEmiter(7f, 10f, 1.3f, 1.6f, 7f, 0.9f, false);
            } else if (gameSession.CurrentScore >= EigthDifficultyThreshold && !spawnedNinthEmitter)
            {
                FindObjectOfType<CameraBehavior>().CameraMovementSpeed = 3f;
                spawnedNinthEmitter = SpawnNewEmiter(7f, 7.5f, 1f, 1.3f, 8f, 0.9f, false);
            } else if (gameSession.CurrentScore >= NinthDifficultyThreshold && !spawnedTenthEmitter)
            {
                FindObjectOfType<CameraBehavior>().CameraMovementSpeed = 4f;
                spawnedTenthEmitter = SpawnNewEmiter(5f, 12f, 1.5f, 1.8f, 10f, 0.9f, false);
            }
        }
    }

    private bool SpawnNewEmiter(float spawnPosition, float bouncerSpawnDelay,
        float xPushMin, float xPushMax, float yPush, float gravityScale, bool withKnife)
    {
        Vector2 emittorSpawnPossition = new Vector2(transform.position.x, transform.position.y + spawnPosition);
        GameObject newEmitter = Instantiate(emittor, emittorSpawnPossition, Quaternion.identity);

        newEmitter.GetComponent<BouncingStuff>().BouncerSpawnDelay = bouncerSpawnDelay;
        newEmitter.GetComponent<BouncingStuff>().XPushMin = xPushMin;
        newEmitter.GetComponent<BouncingStuff>().XPushMax = xPushMax;
        newEmitter.GetComponent<BouncingStuff>().YPush = yPush;
        newEmitter.GetComponent<BouncingStuff>().GravityScale = gravityScale;
        newEmitter.GetComponent<BouncingStuff>().WithKnife = withKnife;
        gameSession.IncrementDifficulty();

        newEmitter.transform.parent = transform;

        return true;
    }
}
