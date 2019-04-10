using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsController : MonoBehaviour
{
    const string BEST_SCORE = "BEST SCORE";
    const string LAST_SCORE = "LAST SCORE";

    public static void SetBestScore(int score)
    {
        PlayerPrefs.SetInt(BEST_SCORE, score);
    }

    public static int GetBestScore()
    {
        return PlayerPrefs.GetInt(BEST_SCORE);
    }

    public static void SetLastScore(int score)
    {
        PlayerPrefs.SetInt(LAST_SCORE, score);
    }

    public static int GetLastScore()
    {
        return PlayerPrefs.GetInt(LAST_SCORE);
    }
}
