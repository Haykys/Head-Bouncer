using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NextDifficultyIn : MonoBehaviour
{
    // cached ref
    GameSession gameSession;

    private void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
    }

    /// <summary>
    /// Displays how many points are left to get to next difficulty
    /// </summary>
    public void DisplayNextDifficultyIn()
    {
        gameObject.GetComponent<TextMeshProUGUI>().text = gameSession.NextDifficultyIn.ToString();
    }
}
