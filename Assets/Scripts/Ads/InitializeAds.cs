/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using System;

public class InitializeAds : MonoBehaviour
{
    //config params
#if UNITY_ANDROID
    string gameId = "3176581";
#elif UNITY_IOS
    string gameId = "3176580";
#endif

    //If we should show ads or not
    public static bool showAds = true;

    // Nulllable type
    public static DateTime? nextNonRewardAddTime = null;

    private static InitializeAds instance;

    public static InitializeAds Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<InitializeAds>();
            }

            return instance;
        }
    }

    bool testMode = true;
    public string placementId = "banner";

    void Awake()
    {
        SetUpSingleton();
    }

    void Start()
    {
        Advertisement.Initialize(gameId, testMode);
        StartCoroutine(ShowBannerWhenReady());
    }

    private void SetUpSingleton()
    {
        if (instance != null && instance != this)
            Destroy(gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    IEnumerator ShowBannerWhenReady()
    {
        while (!Advertisement.IsReady(placementId))
        {
            yield return new WaitForSeconds(0.5f);
        }
        Advertisement.Banner.Show(placementId);
    }
}
*/
