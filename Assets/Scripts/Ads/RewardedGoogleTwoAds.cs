using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;

public class RewardedGoogleTwoAds : MonoBehaviour
{
    // reward ads
#if UNITY_ANDROID
            string adUnitId = "ca-app-pub-3940256099942544/5224354917";
#elif UNITY_IPHONE
            string adUnitId = "ca-app-pub-3940256099942544/4411468910";
#else
            string adUnitId = "unexpected_platform";
#endif

    // config params
    private bool watchedFirstTillEnd = false;
    private bool watchedSecondTillEnd = false;

    // cached ref
    private RewardedAd firstAd;
    private RewardedAd secondAd;
    private PlayerHealth playerHealth;
    private GameOverMenuBehavior gameOverMenuBehavior;
    private RewardedGoogleAd rewardedGoogleAd;
    private LevelLoader levelLoader;
    private Floor floor;

    void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
        gameOverMenuBehavior = FindObjectOfType<GameOverMenuBehavior>();
        rewardedGoogleAd = FindObjectOfType<RewardedGoogleAd>();
        levelLoader = FindObjectOfType<LevelLoader>();
        floor = FindObjectOfType<Floor>();

        firstAd = new RewardedAd(adUnitId);
        secondAd = new RewardedAd(adUnitId);

        // Called when the user should be rewarded for interacting with the ad.
        firstAd.OnUserEarnedReward += HandleUserEarnedFirstReward;
        secondAd.OnUserEarnedReward += HandleUserEarnedSecondReward;
        // Called when the ad is closed.
        firstAd.OnAdClosed += HandleFirstRewardedAdClosed;
        secondAd.OnAdClosed += HandleSecondRewardedAdClosed;
        // Called when an ad request has successfully loaded.
        firstAd.OnAdLoaded += HandleFirstRewardedAdLoaded;
        secondAd.OnAdLoaded += HandleSecondRewardedAdLoaded;
        // Called when an ad request failed to load.
        firstAd.OnAdFailedToLoad += HandleFirstRewardedAdFailedToLoad;
        secondAd.OnAdFailedToLoad += HandleSecondRewardedAdFailedToLoad;
        // Called when an ad request failed to show.
        firstAd.OnAdFailedToShow += HandleFirstRewardedAdFailedToShow;
        secondAd.OnAdFailedToShow += HandleSecondRewardedAdFailedToShow;

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the rewarded ad with the request.
        firstAd.LoadAd(request);
        secondAd.LoadAd(request);
    }

    public void UserChoseToWatchAd()
    {
        var go = FindObjectOfType<GameSession>().GetGameOverMenu();
        go.SetActive(false);

        if (firstAd.IsLoaded())
        {
            firstAd.Show();
        }
    }

    private void HandleFirstRewardedAdLoaded(object sender, EventArgs args)
    {
        floor.FailedToloadRewardAdd = false;
    }

    private void HandleSecondRewardedAdLoaded(object sender, EventArgs args)
    {
        floor.FailedToloadRewardAdd = false;
    }

    private void HandleFirstRewardedAdFailedToLoad(object sender, AdErrorEventArgs args)
    {
        floor.FailedToloadRewardAdd = true;
    }

    private void HandleSecondRewardedAdFailedToLoad(object sender, AdErrorEventArgs args)
    {
        floor.FailedToloadRewardAdd = true;
    }

    private void HandleFirstRewardedAdFailedToShow(object sender, AdErrorEventArgs args)
    {
        levelLoader.LoadMainMenu();

    }

    private void HandleSecondRewardedAdFailedToShow(object sender, AdErrorEventArgs args)
    {
        levelLoader.LoadMainMenu();
    }

    public void HandleFirstRewardedAdClosed(object sender, EventArgs args)
    {
        if (!watchedFirstTillEnd)
        {
            levelLoader.LoadMainMenu();
            return;
        }

        if (secondAd.IsLoaded())
        {
            secondAd.Show();
        }
    }

    public void HandleSecondRewardedAdClosed(object sender, EventArgs args)
    {
        if (!watchedSecondTillEnd)
        {
            levelLoader.LoadMainMenu();
        }
    }

    public void HandleUserEarnedFirstReward(object sender, Reward args)
    {
        watchedFirstTillEnd = true;
    }

    public void HandleUserEarnedSecondReward(object sender, Reward args)
    {
        watchedSecondTillEnd = true;

        if (!rewardedGoogleAd.AdShown)
        {
            rewardedGoogleAd.AdShown = true;
        }

        playerHealth.IncreaseHealth(3);
        gameOverMenuBehavior.Continue();
    }

}

