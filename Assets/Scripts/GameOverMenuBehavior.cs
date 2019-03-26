using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenuBehavior : MonoBehaviour
{
    private static bool paused;

    [Tooltip("Reference to the pause menu object to tun on/off")]
    [SerializeField] GameObject gameOverMenu;

    public static bool Paused { get => paused; set => paused = value; }

    private void Start()
    {
       Paused = false;

       SetPauseMenu(false);
    }

    /// <summary>
    /// Reloads our current level, effectively "restarting" the game
    /// </summary>
    public void Restart()
    {
        Time.timeScale = 1;

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    /// <summary>
    /// Will turn our pause menu on or off
    /// </summary>
    /// <param name="isPaused"></param>
    public void SetPauseMenu(bool isPaused)
    {
        Paused = isPaused;

        // If the game is paused, timeScale is 0, otherwise 1
        Time.timeScale = (Paused) ? 0 : 1;

    }
}
