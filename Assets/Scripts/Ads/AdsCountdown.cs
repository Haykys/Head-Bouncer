using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using SA.CrossPlatform.UI;

public class AdsCountdown : MonoBehaviour
{
    // connfig params
    public static DateTime? adCountdown = null;

    private static int staticAdCountDown = 4;

    // cached ref
    LevelLoader levelLoader;
    StaticGoogleAd staticGoogleAd;

    public static int StaticAdCountDown { get => staticAdCountDown; set => staticAdCountDown = value; }

    // Start is called before the first frame update
    void Start()
    {
        levelLoader = FindObjectOfType<LevelLoader>();
        staticGoogleAd = FindObjectOfType<StaticGoogleAd>();

        adCountdown = DateTime.Now.AddSeconds(5);
    }

    private void Update()
    {
        StartCoroutine(NavigateToMainMenu());
    }

    public IEnumerator NavigateToMainMenu()
    {
        while (true)
        {
            if (adCountdown.HasValue && DateTime.Now < adCountdown.Value)
            {
                // Get the time remaining until navigation to main menu
                TimeSpan remaining = adCountdown.Value - DateTime.Now;

                // Get the time left in the following format 99:99
                var countdownText = string.Format("{0}", remaining.Seconds);

                gameObject.GetComponent<TextMeshProUGUI>().text = countdownText;

                yield return new WaitForSeconds(1f);
            }
            else
            {
                StaticAdCountDown = StaticAdCountDown - 1;

                if (StaticAdCountDown <= 0)
                {
                    StaticAdCountDown = 3;
                    staticGoogleAd.DisplayStaticAd();
                }

                if (PlayerPrefsController.GetBestScore() > 60 && PlayerPrefsController.GetRateApp() == false)
                {
                    PlayerPrefsController.SetRateApp(true);
                    UM_ReviewController.RequestReview();
                }

                levelLoader.LoadMainMenu();
                break;
            }
        }
    }
}
