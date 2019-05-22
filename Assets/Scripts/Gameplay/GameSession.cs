using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class GameSession : MonoBehaviour
{
    //constants
    const string Player = "Player";

    // config params
    [SerializeField] bool isAutoplayEnabled;
    [SerializeField] GameObject playerCharacter;

    // State variable
    int currentScore = 0;
    int points = 0;
    int difficultyLevel = 1;
    int nextDifficultyIn = 5;

    public int CurrentScore { get => currentScore; set => currentScore = value; }
    public int DifficultyLevel { get => difficultyLevel; set => difficultyLevel = value; }
    public int Points { get => points; set => points = value; }
    public int NextDifficultyIn { get => nextDifficultyIn; set => nextDifficultyIn = value; }

    // cached ref
    ScoreDisplay scoreDisplay;
    DifficultyLevel gameDifficultyLevel;
    GameObject player;
    GlobalManager globalManager;
    EmitterSpawner emitterSpawner;
    NextDifficultyIn nextDifficultyInComponent;

    private void Awake()
    {
        CurrentScore = 0;
        SpawnPlayer();
    }

    private void Start()
    {
        scoreDisplay = FindObjectOfType<ScoreDisplay>();
        gameDifficultyLevel = FindObjectOfType<DifficultyLevel>();
        player = GameObject.FindGameObjectWithTag(Player);
        globalManager = FindObjectOfType<GlobalManager>();
        emitterSpawner = FindObjectOfType<EmitterSpawner>();
        nextDifficultyInComponent = FindObjectOfType<NextDifficultyIn>();

        globalManager.SetCharacter(player);
    }

    void Update()
    {
        PointsTillTextDifficulty();
    }

    private void SpawnPlayer()
    {
        Vector2 playerSpawnPossition = transform.position;
        GameObject newPlayer = Instantiate(playerCharacter, playerSpawnPossition, Quaternion.identity);
        newPlayer.transform.parent = transform;
    }

    /// <summary>
    /// Adds a certain amount of points to the player for bouncing of objects
    /// </summary>
    /// <param name="amount">Amount to add</param>
    public void AddToScore(int amount)
    {
        CurrentScore += amount;
        scoreDisplay.GetComponent<ScoreDisplay>().DisplayScore();
    }

    public void AddPoints(int amount)
    {
        int currentPoints = PlayerPrefsController.GetPoints();
        int newPoints = currentPoints + amount;
        PlayerPrefsController.SetPoints(newPoints);
    }

    /// <summary>
    /// Increment Difficulty level in the Game Scene
    /// </summary>
    public void IncrementDifficulty()
    {
        DifficultyLevel += 1;
        gameDifficultyLevel.GetComponent<DifficultyLevel>().DisplayDifficulty();
    }

    #region NextDifficultyIn
    public void PointsTillTextDifficulty()
    {
        if (CurrentScore < emitterSpawner.FirstDifficultyThreshold)
        {
            NextDifficultyIn = emitterSpawner.FirstDifficultyThreshold - CurrentScore;
            nextDifficultyInComponent.DisplayNextDifficultyIn();
        } else if (CurrentScore < emitterSpawner.SecondDifficultyThreshold)
        {
            NextDifficultyIn = emitterSpawner.SecondDifficultyThreshold - CurrentScore;
            nextDifficultyInComponent.DisplayNextDifficultyIn();
        } else if (CurrentScore < emitterSpawner.ThirdDifficultyThreshold)
        {
            NextDifficultyIn = emitterSpawner.ThirdDifficultyThreshold - CurrentScore;
            nextDifficultyInComponent.DisplayNextDifficultyIn();
        } else if (CurrentScore < emitterSpawner.ForthDifficultyThreshold)
        {
            NextDifficultyIn = emitterSpawner.ForthDifficultyThreshold - CurrentScore;
            nextDifficultyInComponent.DisplayNextDifficultyIn();
        } else if (CurrentScore < emitterSpawner.FifthDifficultyThreshold)
        {
            NextDifficultyIn = emitterSpawner.FifthDifficultyThreshold - CurrentScore;
            nextDifficultyInComponent.DisplayNextDifficultyIn();
        } else if (CurrentScore < emitterSpawner.SixthDifficultyThreshold)
        {
            NextDifficultyIn = emitterSpawner.SixthDifficultyThreshold - CurrentScore;
            nextDifficultyInComponent.DisplayNextDifficultyIn();
        } else if (CurrentScore < emitterSpawner.SeventhDifficultyThreshold)
        {
            NextDifficultyIn = emitterSpawner.SeventhDifficultyThreshold - CurrentScore;
            nextDifficultyInComponent.DisplayNextDifficultyIn();
        } else if (CurrentScore < emitterSpawner.EigthDifficultyThreshold)
        {
            NextDifficultyIn = emitterSpawner.EigthDifficultyThreshold - CurrentScore;
            nextDifficultyInComponent.DisplayNextDifficultyIn();
        } else if (CurrentScore < emitterSpawner.NinthDifficultyThreshold)
        {
            NextDifficultyIn = emitterSpawner.NinthDifficultyThreshold - CurrentScore;
            nextDifficultyInComponent.DisplayNextDifficultyIn();
        }
    }
    #endregion

    /// <summary>
    /// Will restart the currently loaded level
    /// </summary>
    public void ResetGame()
    {
        FindObjectOfType<GameOverMenuBehavior>().SetPauseMenu(true);

        var go = GetGameOverMenu();

        go.SetActive(true);
    }

    /// <summary>
    /// Show Game Over Menu
    /// </summary>
    /// <returns></returns>
    public GameObject GetGameOverMenu()
    {
        return GameObject.Find("Game Canvas").transform.Find("Game Over Menu").gameObject;
    }

    /// <summary>
    /// Enables Autoplay Feature (Currently not good use with knifes in game)
    /// </summary>
    /// <returns></returns>
    public bool IsAutoplayEnabled()
    {
        return isAutoplayEnabled;
    }
}
