using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DifficultyLevel : MonoBehaviour
{
    // cached ref
    GameSession gameSession;

    // Start is called before the first frame update
    void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
        gameSession.DifficultyLevel = 1;
        DisplayDifficulty();
    }

    /// <summary>
    /// Displays the current difficulty
    /// </summary>
    public void DisplayDifficulty()
    {
        gameObject.GetComponent<TextMeshProUGUI>().text = gameSession.DifficultyLevel.ToString();
    }
}
