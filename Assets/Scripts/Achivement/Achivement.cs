using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SA.CrossPlatform.GameServices;

public class Achivement : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefsController.GetBestScore() >= 25
            && PlayerPrefsController.GetPoints25() == false
            && Application.internetReachability != NetworkReachability.NotReachable)
        {
            Unlock25Points();
        }
        else if (PlayerPrefsController.GetBestScore() >= 50
          && PlayerPrefsController.GetPoints50() == false
          && Application.internetReachability != NetworkReachability.NotReachable)
        {
            Unlock50Points();
        }
        else if (PlayerPrefsController.GetBestScore() >= 100
          && PlayerPrefsController.GetPoints100() == false
          && Application.internetReachability != NetworkReachability.NotReachable)
        {
            Unlock100Points();
        }
        else if (PlayerPrefsController.GetBestScore() >= 200
          && PlayerPrefsController.GetPoints200() == false
          && Application.internetReachability != NetworkReachability.NotReachable)
        {
            Unlock200Points();
        }
        else if (PlayerPrefsController.GetBestScore() >= 500
          && PlayerPrefsController.GetPoints500() == false
          && Application.internetReachability != NetworkReachability.NotReachable)
        {
            Unlock500Points();
        }
        else if (PlayerPrefsController.GetCharacters().Length >= 3
          && PlayerPrefsController.GetCharacters2() == false
          && Application.internetReachability != NetworkReachability.NotReachable)
        {
            Unlock2Characters();
        }
        else if (PlayerPrefsController.GetCharacters().Length >= 6
          && PlayerPrefsController.GetCharacters5() == false
          && Application.internetReachability != NetworkReachability.NotReachable)
        {
            Unlock5Characters();
        }
        else if (PlayerPrefsController.GetCharacters().Length >= 11
          && PlayerPrefsController.GetCharacters10() == false
          && Application.internetReachability != NetworkReachability.NotReachable)
        {
            Unlock10Characters();
        }
        else if (PlayerPrefsController.GetCharacters().Length >= 21
          && PlayerPrefsController.GetCharacters20() == false
          && Application.internetReachability != NetworkReachability.NotReachable)
        {
            Unlock20Characters();
        }
        else if (PlayerPrefsController.GetCharacters().Length >= 31
          && PlayerPrefsController.GetCharacters30() == false
          && Application.internetReachability != NetworkReachability.NotReachable)
        {
            Unlock30Characters();
        }
    }

    private void Unlock25Points()
    {
#if PLATFORM_IOS
        string achievementId = "grp.points25";
#elif PLATFORM_ANDROID
        string achievementId = "CgkItt_m-csZEAIQAg";
#endif

        PlayerPrefsController.SetPoints25(true);

        var client = UM_GameService.AchievementsClient;
        client.Unlock(achievementId, (result) => {
            if (result.IsSucceeded)
            {
                Debug.Log("Unlocked");
            }
            else
            {
                Debug.Log("Failed: " + result.Error.FullMessage);
            }
        });
    }

    private void Unlock50Points()
    {
#if PLATFORM_IOS
        string achievementId = "grp.points50";
#elif PLATFORM_ANDROID
        string achievementId = "CgkItt_m-csZEAIQAw";
#endif
        PlayerPrefsController.SetPoints50(true);

        var client = UM_GameService.AchievementsClient;
        client.Unlock(achievementId, (result) => {
            if (result.IsSucceeded)
            {
                Debug.Log("Unlocked");
            }
            else
            {
                Debug.Log("Failed: " + result.Error.FullMessage);
            }
        });
    }

    private void Unlock100Points()
    {
#if PLATFORM_IOS
        string achievementId = "grp.points_100";
#elif PLATFORM_ANDROID
        string achievementId = "CgkItt_m-csZEAIQBA";
#endif
        PlayerPrefsController.SetPoints100(true);

        var client = UM_GameService.AchievementsClient;
        client.Unlock(achievementId, (result) => {
            if (result.IsSucceeded)
            {
                Debug.Log("Unlocked");
            }
            else
            {
                Debug.Log("Failed: " + result.Error.FullMessage);
            }
        });
    }

    private void Unlock200Points()
    {
#if PLATFORM_IOS
        string achievementId = "grp.points_200";
#elif PLATFORM_ANDROID
        string achievementId = "CgkItt_m-csZEAIQBQ";
#endif
        PlayerPrefsController.SetPoints200(true);

        var client = UM_GameService.AchievementsClient;
        client.Unlock(achievementId, (result) => {
            if (result.IsSucceeded)
            {
                Debug.Log("Unlocked");
            }
            else
            {
                Debug.Log("Failed: " + result.Error.FullMessage);
            }
        });
    }

    private void Unlock500Points()
    {
#if PLATFORM_IOS
        string achievementId = "grp.points_500";
#elif PLATFORM_ANDROID
        string achievementId = "CgkItt_m-csZEAIQBg";
#endif
        PlayerPrefsController.SetPoints500(true);

        var client = UM_GameService.AchievementsClient;
        client.Unlock(achievementId, (result) => {
            if (result.IsSucceeded)
            {
                Debug.Log("Unlocked");
            }
            else
            {
                Debug.Log("Failed: " + result.Error.FullMessage);
            }
        });
    }

    private void Unlock2Characters()
    {
#if PLATFORM_IOS
        string achievementId = "grp.characters_2";
#elif PLATFORM_ANDROID
        string achievementId = "CgkItt_m-csZEAIQBw";
#endif
        PlayerPrefsController.SetCharacters2(true);

        var client = UM_GameService.AchievementsClient;
        client.Unlock(achievementId, (result) => {
            if (result.IsSucceeded)
            {
                Debug.Log("Unlocked");
            }
            else
            {
                Debug.Log("Failed: " + result.Error.FullMessage);
            }
        });
    }

    private void Unlock5Characters()
    {
#if PLATFORM_IOS
        string achievementId = "grp.characters_5";
#elif PLATFORM_ANDROID
        string achievementId = "CgkItt_m-csZEAIQCA";
#endif
        PlayerPrefsController.SetCharacters5(true);

        var client = UM_GameService.AchievementsClient;
        client.Unlock(achievementId, (result) => {
            if (result.IsSucceeded)
            {
                Debug.Log("Unlocked");
            }
            else
            {
                Debug.Log("Failed: " + result.Error.FullMessage);
            }
        });
    }

    private void Unlock10Characters()
    {
#if PLATFORM_IOS
        string achievementId = "grp.characters_10";
#elif PLATFORM_ANDROID
        string achievementId = "CgkItt_m-csZEAIQCQ";
#endif
        PlayerPrefsController.SetCharacters10(true);

        var client = UM_GameService.AchievementsClient;
        client.Unlock(achievementId, (result) => {
            if (result.IsSucceeded)
            {
                Debug.Log("Unlocked");
            }
            else
            {
                Debug.Log("Failed: " + result.Error.FullMessage);
            }
        });
    }

    private void Unlock20Characters()
    {
#if PLATFORM_IOS
        string achievementId = "grp.characters_20";
#elif PLATFORM_ANDROID
        string achievementId = "CgkItt_m-csZEAIQCg";
#endif
        PlayerPrefsController.SetCharacters20(true);

        var client = UM_GameService.AchievementsClient;
        client.Unlock(achievementId, (result) => {
            if (result.IsSucceeded)
            {
                Debug.Log("Unlocked");
            }
            else
            {
                Debug.Log("Failed: " + result.Error.FullMessage);
            }
        });
    }

    private void Unlock30Characters()
    {
#if PLATFORM_IOS
        string achievementId = "grp.characters_30";
#elif PLATFORM_ANDROID
        string achievementId = "CgkItt_m-csZEAIQCw";
#endif
        PlayerPrefsController.SetCharacters30(true);

        var client = UM_GameService.AchievementsClient;
        client.Unlock(achievementId, (result) => {
            if (result.IsSucceeded)
            {
                Debug.Log("Unlocked");
            }
            else
            {
                Debug.Log("Failed: " + result.Error.FullMessage);
            }
        });
    }

    // check if condition is met and unlock achievement

    public void DisplayAchievement()
    {
        UM_GameService.AchievementsClient.ShowUI();
    }
}