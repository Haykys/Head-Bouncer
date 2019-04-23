using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SecPlayerPrefs;

public class PlayerPrefsController : MonoBehaviour
{
    const string BEST_SCORE = "BEST SCORE";
    const string LAST_SCORE = "LAST SCORE";

    public static void SetBestScore(int score)
    {
        SecurePlayerPrefs.SetInt(BEST_SCORE, score);
    }

    public static int GetBestScore()
    {
        return SecurePlayerPrefs.GetInt(BEST_SCORE);
    }

    public static void SetLastScore(int score)
    {
        SecurePlayerPrefs.SetInt(LAST_SCORE, score);
    }

    public static int GetLastScore()
    {
        return SecurePlayerPrefs.GetInt(LAST_SCORE);
    }
}
