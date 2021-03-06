﻿using System.Collections;
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

    [Header("SFX")]
    [SerializeField] AudioClip nextDifficultySound;
    [SerializeField] [Range(0, 1)] float nextDifficultySoundVolume = 0.7f;

    // State variable
    int currentScore = 0;
    int currentBouncingSpree = 0;
    int points = 0;
    int difficultyLevel = 1;
    int nextDifficultyIn = 5;

    public int CurrentScore { get => currentScore; set => currentScore = value; }
    public int DifficultyLevel { get => difficultyLevel; set => difficultyLevel = value; }
    public int Points { get => points; set => points = value; }
    public int NextDifficultyIn { get => nextDifficultyIn; set => nextDifficultyIn = value; }
    public int CurrentBouncingSpree { get => currentBouncingSpree; set => currentBouncingSpree = value; }

    // cached ref
    ScoreDisplay scoreDisplay;
    BouncingSpreeDisplay bouncingSpreeDisplay;
    DifficultyLevel gameDifficultyLevel;
    GameObject player;
    GlobalManager globalManager;
    EmitterSpawner emitterSpawner;
    NextDifficultyIn nextDifficultyInComponent;

    private void Awake()
    {
        CurrentScore = 0;
        CurrentBouncingSpree = 0;
        SpawnPlayer();
    }

    private void Start()
    {
        scoreDisplay = FindObjectOfType<ScoreDisplay>();
        bouncingSpreeDisplay = FindObjectOfType<BouncingSpreeDisplay>();
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

    public void AddToBouncingSpree(int amount)
    {
        CurrentBouncingSpree += amount;
        bouncingSpreeDisplay.GetComponent<BouncingSpreeDisplay>().DisplayBouncingSpree();
    }

    public void AddPoints(int amount)
    {
        int currentPoints = PlayerPrefsController.GetPoints();
        int newPoints = currentPoints + amount;
        PlayerPrefsController.SetPoints(newPoints);
    }

    public void ResetBouncingSpree()
    {
        if (CurrentBouncingSpree > PlayerPrefsController.GetBestBouncingSpree())
        {
            PlayerPrefsController.SetBestBouncingSpree(CurrentBouncingSpree);
        }

        CurrentBouncingSpree = 0;
        bouncingSpreeDisplay.GetComponent<BouncingSpreeDisplay>().DisplayBouncingSpree();
    }

    /// <summary>
    /// Increment Difficulty level in the Game Scene
    /// </summary>
    public void IncrementDifficulty()
    {
        if (PlayerPrefsController.GetVibration() == true)
        {
            Handheld.Vibrate(); 
        }
        AudioSource.PlayClipAtPoint(nextDifficultySound, transform.position, nextDifficultySoundVolume);

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
        } else if (CurrentScore < emitterSpawner.TenthDifficultyThreshold)
        {
            NextDifficultyIn = emitterSpawner.TenthDifficultyThreshold - CurrentScore;
            nextDifficultyInComponent.DisplayNextDifficultyIn();
        } else if (CurrentScore < emitterSpawner.EleventhDifficultyThreshold)
        {
            NextDifficultyIn = emitterSpawner.EleventhDifficultyThreshold - CurrentScore;
            nextDifficultyInComponent.DisplayNextDifficultyIn();
        } else if (CurrentScore < emitterSpawner.TwelfthDifficultyThreshold)
        {
            NextDifficultyIn = emitterSpawner.TwelfthDifficultyThreshold - CurrentScore;
            nextDifficultyInComponent.DisplayNextDifficultyIn();
        } else if (CurrentScore < emitterSpawner.ThirtiethDifficultyThreshold)
        {
            NextDifficultyIn = emitterSpawner.ThirtiethDifficultyThreshold - CurrentScore;
            nextDifficultyInComponent.DisplayNextDifficultyIn();
        } else if (CurrentScore < emitterSpawner.FourteenthDifficultyThreshold)
        {
            NextDifficultyIn = emitterSpawner.FourteenthDifficultyThreshold - CurrentScore;
            nextDifficultyInComponent.DisplayNextDifficultyIn();
        } else if (CurrentScore < emitterSpawner.FifteenthDifficultyThreshold)
        {
            NextDifficultyIn = emitterSpawner.FifteenthDifficultyThreshold - CurrentScore;
            nextDifficultyInComponent.DisplayNextDifficultyIn();
        } else if (CurrentScore < emitterSpawner.SixteenthDifficultyThreshold)
        {
            NextDifficultyIn = emitterSpawner.SixteenthDifficultyThreshold - CurrentScore;
            nextDifficultyInComponent.DisplayNextDifficultyIn();
        } else if (CurrentScore < emitterSpawner.SeventeenthDifficultyThreshold)
        {
            NextDifficultyIn = emitterSpawner.SeventeenthDifficultyThreshold - CurrentScore;
            nextDifficultyInComponent.DisplayNextDifficultyIn();
        } else if (CurrentScore < emitterSpawner.EighteenthDifficultyThreshold)
        {
            NextDifficultyIn = emitterSpawner.EighteenthDifficultyThreshold - CurrentScore;
            nextDifficultyInComponent.DisplayNextDifficultyIn();
        } else if (CurrentScore < emitterSpawner.NineteenthDifficultyThreshold)
        {
            NextDifficultyIn = emitterSpawner.NineteenthDifficultyThreshold - CurrentScore;
            nextDifficultyInComponent.DisplayNextDifficultyIn();
        } else if (CurrentScore >= emitterSpawner.NineteenthDifficultyThreshold)
        {
            NextDifficultyIn = 0;
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
