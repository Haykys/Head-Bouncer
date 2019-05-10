using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SecPlayerPrefs;
using System.Linq;

public class PlayerPrefsController : MonoBehaviour
{
    const string BEST_SCORE = "BEST SCORE";
    const string LAST_SCORE = "LAST SCORE";
    const string POINTS = "POINTS";
    const string PLAYER_CHARACTERS = "PLAYER CHARACTERS";
    const string CURRENT_PLAYER_CHARACTER = "CURRENT PLAYER CHARACTER";

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

    public static void SetPoints(int points)
    {
        SecurePlayerPrefs.SetInt(POINTS, points);
    }

    public static int GetPoints()
    {
        return SecurePlayerPrefs.GetInt(POINTS);
    }

    public static void SetCharacters(string characterName)
    {
        if (GetCharacters().Length == 0)
        {
            List<string> characters = new List<string>();
            characters.Add(characterName);
            string[] charactersArray = characters.ToArray();
            PlayerPrefsX.SetStringArray(PLAYER_CHARACTERS, charactersArray);
        } else
        {
            List<string> characters = GetCharacters().ToList();
            characters.Add(characterName);
            string[] charactersArray = characters.ToArray();
            PlayerPrefsX.SetStringArray(PLAYER_CHARACTERS, charactersArray);
        }
    }

    public static string[] GetCharacters()
    {
        return PlayerPrefsX.GetStringArray(PLAYER_CHARACTERS);
    }

    public static void SetCharacter(int characterIndex)
    {
        SecurePlayerPrefs.SetInt(CURRENT_PLAYER_CHARACTER, characterIndex);
    }

    public static int GetCharacter()
    {
        return SecurePlayerPrefs.GetInt(CURRENT_PLAYER_CHARACTER);
    }
}
