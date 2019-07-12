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
    const string VOLUME = "VOLUME";
    const string VIBRATION = "VIBRATION";
    const string RATE_APP = "RATE_APP";

    const string POINTS_25 = "POINTS_25";
    const string POINTS_50 = "POINTS_50";
    const string POINTS_100 = "POINTS_100";
    const string POINTS_200 = "POINTS_200";
    const string POINTS_500 = "POINTS_500";
    const string CHARACTERS_2 = "CHARACTERS_2";
    const string CHARACTERS_5 = "CHARACTERS_5";
    const string CHARACTERS_10 = "CHARACTERS_10";
    const string CHARACTERS_20 = "CHARACTERS_20";
    const string CHARACTERS_30 = "CHARACTERS_30";

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
        }
        else
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

    public static void SetVolume(bool volume)
    {
        SecurePlayerPrefs.SetBool(VOLUME, volume);
    }

    public static bool GetVolume()
    {
        return SecurePlayerPrefs.GetBool(VOLUME);
    }

    public static void SetVibration(bool vibration)
    {
        SecurePlayerPrefs.SetBool(VIBRATION, vibration);
    }

    public static bool GetVibration()
    {
        return SecurePlayerPrefs.GetBool(VIBRATION);
    }

    public static void SetRateApp(bool hasRated)
    {
        SecurePlayerPrefs.SetBool(RATE_APP, hasRated);
    }

    public static bool GetRateApp()
    {
        return SecurePlayerPrefs.GetBool(RATE_APP);
    }

    public static void SetPoints25(bool hasAchieved)
    {
        SecurePlayerPrefs.SetBool(POINTS_25, hasAchieved);
    }

    public static bool GetPoints25()
    {
        return SecurePlayerPrefs.GetBool(POINTS_25);
    }

    public static void SetPoints50(bool hasAchieved)
    {
        SecurePlayerPrefs.SetBool(POINTS_50, hasAchieved);
    }

    public static bool GetPoints50()
    {
        return SecurePlayerPrefs.GetBool(POINTS_50);
    }

    public static void SetPoints100(bool hasAchieved)
    {
        SecurePlayerPrefs.SetBool(POINTS_100, hasAchieved);
    }

    public static bool GetPoints100()
    {
        return SecurePlayerPrefs.GetBool(POINTS_100);
    }

    public static void SetPoints200(bool hasAchieved)
    {
        SecurePlayerPrefs.SetBool(POINTS_200, hasAchieved);
    }

    public static bool GetPoints200()
    {
        return SecurePlayerPrefs.GetBool(POINTS_200);
    }

    public static void SetPoints500(bool hasAchieved)
    {
        SecurePlayerPrefs.SetBool(POINTS_500, hasAchieved);
    }

    public static bool GetPoints500()
    {
        return SecurePlayerPrefs.GetBool(POINTS_500);
    }

    public static void SetCharacters2(bool hasAchieved)
    {
        SecurePlayerPrefs.SetBool(CHARACTERS_2, hasAchieved);
    }

    public static bool GetCharacters2()
    {
        return SecurePlayerPrefs.GetBool(CHARACTERS_2);
    }

    public static void SetCharacters5(bool hasAchieved)
    {
        SecurePlayerPrefs.SetBool(CHARACTERS_5, hasAchieved);
    }

    public static bool GetCharacters5()
    {
        return SecurePlayerPrefs.GetBool(CHARACTERS_5);
    }

    public static void SetCharacters10(bool hasAchieved)
    {
        SecurePlayerPrefs.SetBool(CHARACTERS_10, hasAchieved);
    }

    public static bool GetCharacters10()
    {
        return SecurePlayerPrefs.GetBool(CHARACTERS_10);
    }

    public static void SetCharacters20(bool hasAchieved)
    {
        SecurePlayerPrefs.SetBool(CHARACTERS_20, hasAchieved);
    }

    public static bool GetCharacters20()
    {
        return SecurePlayerPrefs.GetBool(CHARACTERS_20);
    }

    public static void SetCharacters30(bool hasAchieved)
    {
        SecurePlayerPrefs.SetBool(CHARACTERS_30, hasAchieved);
    }

    public static bool GetCharacters30()
    {
        return SecurePlayerPrefs.GetBool(CHARACTERS_30);
    }
}