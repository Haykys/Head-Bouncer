using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    // cached ref
    GameSession gameSession;

    // Start is called before the first frame update
    void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
        gameSession.CurrentScore = 0;
        DisplayScore();
    }

    /// <summary>
    /// Displays the score to the player
    /// </summary>
    public void DisplayScore()
    {
        gameObject.GetComponent<TextMeshProUGUI>().text = gameSession.CurrentScore.ToString();
    }
}
