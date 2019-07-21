using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BouncingSpreeDisplay : MonoBehaviour
{
    // cached ref
    GameSession gameSession;

    // Start is called before the first frame update
    void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
        gameSession.CurrentBouncingSpree = 0;
        DisplayBouncingSpree();
    }

    /// <summary>
    /// Displays the score to the player
    /// </summary>
    public void DisplayBouncingSpree()
    {
        gameObject.GetComponent<TextMeshProUGUI>().text = gameSession.CurrentBouncingSpree.ToString();
    }
}
