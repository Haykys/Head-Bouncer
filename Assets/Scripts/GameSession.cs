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

    public int CurrentScore { get => currentScore; }

    // cached ref
    [SerializeField] TextMeshProUGUI scoreText;

    private void Awake()
    {
        SetUpSingleton();
    }

    private void SetUpSingleton()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        } else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        DisplayScore();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Adds a certain amount of points to the player for bouncing of objects
    /// </summary>
    /// <param name="amount">Amount to add</param>
    public void AddToScore(int amount)
    {
        currentScore += amount;
        DisplayScore();
    }

    /// <summary>
    /// Displays the score to the player
    /// </summary>
    private void DisplayScore()
    {
        scoreText.text = currentScore.ToString();
    }

    /// <summary>
    /// 
    /// </summary>
    public void ResetGame()
    {

    }
}
