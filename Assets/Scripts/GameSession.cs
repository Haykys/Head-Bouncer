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

    // State variable
    int currentScore = 0;
    int difficultyLevel = 1;

    public int CurrentScore { get => currentScore; set => currentScore = value; }
    public int DifficultyLevel { get => difficultyLevel; set => difficultyLevel = value; }

    // cached ref
    ScoreDisplay scoreDisplay;
    DifficultyLevel gameDifficultyLevel;
    GameObject player;
    GlobalManager globalManager;

    private void Awake()
    {
        CurrentScore = 0;
    }

    private void Start()
    {
        scoreDisplay = FindObjectOfType<ScoreDisplay>();
        gameDifficultyLevel = FindObjectOfType<DifficultyLevel>();
        player = GameObject.FindGameObjectWithTag(Player);
        globalManager = FindObjectOfType<GlobalManager>();

        globalManager.SetCharacter(player);
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

    /// <summary>
    /// Increment Difficulty level in the Game Scene
    /// </summary>
    public void IncrementDifficulty()
    {
        DifficultyLevel += 1;
        gameDifficultyLevel.GetComponent<DifficultyLevel>().DisplayDifficulty();
    }

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
