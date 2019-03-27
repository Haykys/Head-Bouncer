using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class GameSession : MonoBehaviour
{

    private static GameSession instance;

    public static GameSession Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<GameSession>();
            }

            return instance;
        }
    }

    // State variable
    int currentScore = 0;

    public int CurrentScore { get => currentScore; set => currentScore = value; }

    // cached ref
    GameObject scoreDisplay;

    private void Awake()
    {
        SetUpSingleton();
    }

    private void Update()
    {
        scoreDisplay = GameObject.Find("Score Text");
    }

    private void SetUpSingleton()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        } else
        {
            instance = this;
            CurrentScore = 0;
            DontDestroyOnLoad(gameObject);
        }
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
    /// Will restart the currently loaded level
    /// </summary>
    public void ResetGame()
    {
        Time.timeScale = 0;

        var go = GetGameOverMenu();

        go.SetActive(true);
    }

    GameObject GetGameOverMenu()
    {
        return GameObject.Find("Game Canvas").transform.Find("Game Over Menu").gameObject;
    }
}
