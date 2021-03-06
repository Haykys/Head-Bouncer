﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;

public class RewardedGoogleAd : MonoBehaviour
{
    // reward ads
#if UNITY_ANDROID
            // real ads
            string adUnitId = "ca-app-pub-7950062407728228/4130246388";
            // testing ads
            // string adUnitId = "ca-app-pub-3940256099942544/5224354917";
#elif UNITY_IPHONE
            string adUnitId = "ca-app-pub-3940256099942544/4411468910";
#else
            string adUnitId = "unexpected_platform";
#endif

    // config params
    private bool adShown = false;
    private bool watchedTillEnd = false;

    // cached ref
    private RewardedAd rewardedAd;
    private PlayerHealth playerHealth;
    private GameOverMenuBehavior gameOverMenuBehavior;
    private LevelLoader levelLoader;
    private Floor floor;

    public bool AdShown { get => adShown; set => adShown = value; }

    void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
        gameOverMenuBehavior = FindObjectOfType<GameOverMenuBehavior>();
        levelLoader = FindObjectOfType<LevelLoader>();
        floor = FindObjectOfType<Floor>();

        rewardedAd = new RewardedAd(adUnitId);

        // Called when an ad request failed to load.
        rewardedAd.OnAdFailedToLoad += HandleRewardedAdFailedToLoad;
        // Called when an ad is shown.
        rewardedAd.OnAdOpening += HandleRewardedAdOpening;
        // Called when an ad request failed to show.
        rewardedAd.OnAdFailedToShow += HandleRewardedAdFailedToShow;
        // Called when the user should be rewarded for interacting with the ad.
        rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
        // Called when the ad is closed.
        rewardedAd.OnAdClosed += HandleRewardedAdClosed;

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the rewarded ad with the request.
        rewardedAd.LoadAd(request);
    }

    public void UserChoseToWatchAd()
    {
        if (rewardedAd.IsLoaded())
        {
            var go = FindObjectOfType<GameSession>().GetGameOverMenu();
            go.SetActive(false);

            rewardedAd.Show();
        }
    }

    public void HandleRewardedAdFailedToLoad(object sender, AdErrorEventArgs args)
    {
        floor.FailedToloadRewardAdd = true;

    }

    public void HandleRewardedAdOpening(object sender, EventArgs args)
    {
        print("HandleRewardedAdOpening event received");
    }

    public void HandleRewardedAdFailedToShow(object sender, AdErrorEventArgs args)
    {
        levelLoader.LoadMainMenu();

    }

    public void HandleRewardedAdClosed(object sender, EventArgs args)
    {
        if (!watchedTillEnd)
        {
            levelLoader.LoadMainMenu();
        } else
        {
            playerHealth.IncreaseHealth(2);
            gameOverMenuBehavior.Continue();
        }
    }

    public void HandleUserEarnedReward(object sender, Reward args)
    {
        AdShown = true;
        watchedTillEnd = true;
    }

}
