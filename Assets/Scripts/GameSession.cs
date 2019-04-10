using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class GameSession : MonoBehaviour
{

    // config params
    [SerializeField] bool isAutoplayEnabled;

    // State variable
    int currentScore = 0;

    public int CurrentScore { get => currentScore; set => currentScore = value; }

    // cached ref
    ScoreDisplay scoreDisplay;

    private void Awake()
    {
        CurrentScore = 0;
    }

    private void Update()
    {
        scoreDisplay = FindObjectOfType<ScoreDisplay>();
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
        FindObjectOfType<GameOverMenuBehavior>().SetPauseMenu(true);

        var go = GetGameOverMenu();

        go.SetActive(true);
    }

    public GameObject GetGameOverMenu()
    {
        return GameObject.Find("Game Canvas").transform.Find("Game Over Menu").gameObject;
    }

    public bool IsAutoplayEnabled()
    {
        return isAutoplayEnabled;
    }
}
