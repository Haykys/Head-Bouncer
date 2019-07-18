using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;

public class InitializeGoogleAds : MonoBehaviour
{

    //If we should show ads or not
    private static bool adInitialized = false;

    // config params
    public static DateTime? nextNonRewardAddTime = null;
    private BannerView bannerView;

    // ad config
#if UNITY_ANDROID
            string appId = "ca-app-pub-7950062407728228~6584771914";
#elif UNITY_IPHONE
            string appId = "ca-app-pub-7950062407728228~5215849921";
#else
            string appId = "unexpected_platform";
#endif

    // banner ads
#if UNITY_ANDROID
            // real ads
            string adUnitId = "ca-app-pub-7950062407728228/8598182427";
            // testing ads
            //string adUnitId = "ca-app-pub-3940256099942544/6300978111";
#elif UNITY_IPHONE
            string adUnitId = "ca-app-pub-3940256099942544/2934735716";
#else
            string adUnitId = "unexpected_platform";
#endif

    public static bool AdInitialized { get => adInitialized; set => adInitialized = value; }

    private void Start()
    {
        if (Application.internetReachability != NetworkReachability.NotReachable && !AdInitialized)
        {
            AdInitialized = true;
            MobileAds.Initialize(appId);
        }

        if (Application.internetReachability != NetworkReachability.NotReachable)
        {
            RequestBanner();
        }
    }

    private void RequestBanner()
    {
        // Create a 320x50 banner at the top of the screen.
        bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Bottom);

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();

        // Load the banner with the request.
        bannerView.LoadAd(request);
    }

}
