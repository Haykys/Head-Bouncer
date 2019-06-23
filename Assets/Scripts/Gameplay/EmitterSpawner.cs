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
    private bool spawnedEleventhEmitter = false;
    private bool spawnedTwelfthEmitter = false;
    private bool spawnedThirtiethEmitter = false;
    private bool spawnedFourteenthEmitter = false;
    private bool spawnedFifteenthEmitter = false;
    private bool spawnedSixteenthEmitter = false;
    private bool spawnedSeventeenthEmitter = false;
    private bool spawnedEighteenthEmitter = false;
    private bool spawnedNineteennthEmitter = false;
    private bool spawnedTwentiethEmitter = false;

    private int firstDifficultyThreshold = 3;
    private int secondDifficultyThreshold = 10;
    private int thirdDifficultyThreshold = 25;
    private int forthDifficultyThreshold = 40;
    private int fifthDifficultyThreshold = 60;
    private int sixthDifficultyThreshold = 80;
    private int seventhDifficultyThreshold = 100;
    private int eigthDifficultyThreshold = 130;
    private int ninthDifficultyThreshold = 160;
    private int tenthDifficultyThreshold = 190;
    private int eleventhDifficultyThreshold = 230;
    private int twelfthDifficultyThreshold = 270;
    private int thirtiethDifficultyThreshold = 310;
    private int fourteenthDifficultyThreshold = 360;
    private int fifteenthDifficultyThreshold = 410;
    private int sixteenthDifficultyThreshold = 460;
    private int seventeenthDifficultyThreshold = 520;
    private int eighteenthDifficultyThreshold = 580;
    private int nineteenthDifficultyThreshold = 640;

    public int FirstDifficultyThreshold { get => firstDifficultyThreshold; set => firstDifficultyThreshold = value; }
    public int SecondDifficultyThreshold { get => secondDifficultyThreshold; set => secondDifficultyThreshold = value; }
    public int ThirdDifficultyThreshold { get => thirdDifficultyThreshold; set => thirdDifficultyThreshold = value; }
    public int ForthDifficultyThreshold { get => forthDifficultyThreshold; set => forthDifficultyThreshold = value; }
    public int FifthDifficultyThreshold { get => fifthDifficultyThreshold; set => fifthDifficultyThreshold = value; }
    public int SixthDifficultyThreshold { get => sixthDifficultyThreshold; set => sixthDifficultyThreshold = value; }
    public int SeventhDifficultyThreshold { get => seventhDifficultyThreshold; set => seventhDifficultyThreshold = value; }
    public int EigthDifficultyThreshold { get => eigthDifficultyThreshold; set => eigthDifficultyThreshold = value; }
    public int NinthDifficultyThreshold { get => ninthDifficultyThreshold; set => ninthDifficultyThreshold = value; }
    public int TenthDifficultyThreshold { get => tenthDifficultyThreshold; set => tenthDifficultyThreshold = value; }
    public int EleventhDifficultyThreshold { get => eleventhDifficultyThreshold; set => eleventhDifficultyThreshold = value; }
    public int TwelfthDifficultyThreshold { get => twelfthDifficultyThreshold; set => twelfthDifficultyThreshold = value; }
    public int ThirtiethDifficultyThreshold { get => thirtiethDifficultyThreshold; set => thirtiethDifficultyThreshold = value; }
    public int FourteenthDifficultyThreshold { get => fourteenthDifficultyThreshold; set => fourteenthDifficultyThreshold = value; }
    public int FifteenthDifficultyThreshold { get => fifteenthDifficultyThreshold; set => fifteenthDifficultyThreshold = value; }
    public int SixteenthDifficultyThreshold { get => sixteenthDifficultyThreshold; set => sixteenthDifficultyThreshold = value; }
    public int SeventeenthDifficultyThreshold { get => seventeenthDifficultyThreshold; set => seventeenthDifficultyThreshold = value; }
    public int EighteenthDifficultyThreshold { get => eighteenthDifficultyThreshold; set => eighteenthDifficultyThreshold = value; }
    public int NineteenthDifficultyThreshold { get => nineteenthDifficultyThreshold; set => nineteenthDifficultyThreshold = value; }
    public bool SpawnedFirstEmitter { get => spawnedFirstEmitter; set => spawnedFirstEmitter = value; }
    public bool SpawnedSecondEmitter { get => spawnedSecondEmitter; set => spawnedSecondEmitter = value; }
    public bool SpawnedThirdEmitter { get => spawnedThirdEmitter; set => spawnedThirdEmitter = value; }
    public bool SpawnedForthEmitter { get => spawnedForthEmitter; set => spawnedForthEmitter = value; }
    public bool SpawnedFifthEmitter { get => spawnedFifthEmitter; set => spawnedFifthEmitter = value; }
    public bool SpawnedSixthEmitter { get => spawnedSixthEmitter; set => spawnedSixthEmitter = value; }
    public bool SpawnedSeventhEmitter { get => spawnedSeventhEmitter; set => spawnedSeventhEmitter = value; }

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
            if (gameSession.CurrentScore < firstDifficultyThreshold && !SpawnedFirstEmitter)
            {
                Vector2 emittorSpawnPossition = new Vector2(transform.position.x, transform.position.y + 6f);
                GameObject newEmitter = Instantiate(emittor, emittorSpawnPossition, Quaternion.identity);
                newEmitter.transform.parent = transform;

                SpawnedFirstEmitter = true;
            }
            else if (gameSession.CurrentScore >= FirstDifficultyThreshold && !SpawnedSecondEmitter)
            {
                SpawnedSecondEmitter = SpawnNewEmiter(6f, 4f, 1.5f, 2.3f, 6f, 0.9f, false);
            }
            else if (gameSession.CurrentScore >= SecondDifficultyThreshold && !SpawnedThirdEmitter)
            {
                FindObjectOfType<CameraBehavior>().CameraMovementSpeed = 2f;
                SpawnedThirdEmitter = SpawnNewEmiter(5f, 5f, 1.2f, 1.5f, 8f, 0.9f, false);
            } else if (gameSession.CurrentScore >= ThirdDifficultyThreshold && !SpawnedForthEmitter)
            {
                SpawnedForthEmitter = SpawnNewEmiter(4f, 4f, 2.5f, 3.3f, 6f, 0.9f, false);
            } else if (gameSession.CurrentScore >= ForthDifficultyThreshold && !SpawnedFifthEmitter)
            {
                SpawnedFifthEmitter = SpawnNewEmiter(4f, 5f, 1.5f, 2.3f, 7f, 0.9f, false);
            } else if (gameSession.CurrentScore >= FifthDifficultyThreshold && !SpawnedSixthEmitter)
            {
                FindObjectOfType<CameraBehavior>().CameraMovementSpeed = 3f;
                SpawnedSixthEmitter = SpawnNewEmiter(4f, 6f, 2f, 2.8f, 7f, 0.9f, false);
            } else if (gameSession.CurrentScore >= SixthDifficultyThreshold && !SpawnedSeventhEmitter)
            {
                SpawnedSeventhEmitter = SpawnNewEmiter(6f, 5f, 1.5f, 2.3f, 5f, 0.9f, false);
            } else if (gameSession.CurrentScore >= SeventhDifficultyThreshold && !spawnedEigthEmitter)
            {
                spawnedEigthEmitter = SpawnNewEmiter(5.5f, 10f, 1.3f, 1.6f, 7f, 0.9f, false);
            } else if (gameSession.CurrentScore >= EigthDifficultyThreshold && !spawnedNinthEmitter)
            {
                FindObjectOfType<CameraBehavior>().CameraMovementSpeed = 4f;
                spawnedNinthEmitter = SpawnNewEmiter(5f, 7.5f, 1f, 1.3f, 8f, 0.9f, false);
            } else if (gameSession.CurrentScore >= NinthDifficultyThreshold && !spawnedTenthEmitter)
            {
                spawnedTenthEmitter = SpawnNewEmiter(5f, 12f, 1.5f, 1.8f, 10f, 0.9f, false);
            } else if (gameSession.CurrentScore >= TenthDifficultyThreshold && !spawnedEleventhEmitter)
            {
                spawnedEleventhEmitter = SpawnNewEmiter(4f, 6f, 1f, 2f, 8f, 0.9f, false);
            } else if (gameSession.CurrentScore >= EleventhDifficultyThreshold && !spawnedTwelfthEmitter)
            {
                FindObjectOfType<CameraBehavior>().CameraMovementSpeed = 5f;
                spawnedTwelfthEmitter = SpawnNewEmiter(5f, 7f, 1.4f, 1.9f, 6f, 0.9f, false);
            } else if (gameSession.CurrentScore >= TwelfthDifficultyThreshold && !spawnedThirtiethEmitter)
            {
                spawnedThirtiethEmitter = SpawnNewEmiter(3.5f, 8f, 1.3f, 1.7f, 10f, 0.9f, false);
            } else if (gameSession.CurrentScore >= ThirtiethDifficultyThreshold && !spawnedFourteenthEmitter)
            {
                spawnedFourteenthEmitter = SpawnNewEmiter(6f, 10f, 2f, 2.2f, 5f, 0.9f, false);
            } else if (gameSession.CurrentScore >= FourteenthDifficultyThreshold && !spawnedFifteenthEmitter)
            {
                FindObjectOfType<CameraBehavior>().CameraMovementSpeed = 6f;
                spawnedFifteenthEmitter = SpawnNewEmiter(4.5f, 2f, 1f, 2f, 8f, 0.9f, false);
            } else if (gameSession.CurrentScore >= FifteenthDifficultyThreshold && !spawnedSixteenthEmitter)
            {
                spawnedSixteenthEmitter = SpawnNewEmiter(5f, 7f, 1.2f, 1.5f, 8f, 0.9f, false);
            } else if (gameSession.CurrentScore >= SixteenthDifficultyThreshold && !spawnedSeventeenthEmitter)
            {
                spawnedSeventeenthEmitter = SpawnNewEmiter(4f, 8f, 2.5f, 3.3f, 6f, 0.9f, false);
            } else if (gameSession.CurrentScore >= SeventeenthDifficultyThreshold && !spawnedEighteenthEmitter)
            {
                FindObjectOfType<CameraBehavior>().CameraMovementSpeed = 6f;
                spawnedEighteenthEmitter = SpawnNewEmiter(4f, 9f, 2.5f, 3.3f, 6f, 0.9f, false);
            } else if (gameSession.CurrentScore >= EighteenthDifficultyThreshold && !spawnedNineteennthEmitter)
            {
                spawnedNineteennthEmitter = SpawnNewEmiter(4f, 10f, 2f, 2.8f, 7f, 0.9f, false);
            } else if (gameSession.CurrentScore >= NineteenthDifficultyThreshold && !spawnedTwentiethEmitter)
            {
                FindObjectOfType<CameraBehavior>().CameraMovementSpeed = 6f;
                spawnedTwentiethEmitter = SpawnNewEmiter(6f, 11f, 1.5f, 2.3f, 5f, 0.9f, false);
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
