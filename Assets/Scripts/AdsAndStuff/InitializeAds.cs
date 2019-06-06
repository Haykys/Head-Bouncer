using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SA.CrossPlatform.Advertisement;

public class InitializeAds : MonoBehaviour
{
    private void Awake()
    {
        var settings = UM_UnityAdsSettings.Instance;
        var android = settings.AndroidIds;
        var ios = settings.IOSIds;

        android.AppId = "3176580";
        android.BannerId = "banner";
        android.RewardedId = "rewardVideo";
        android.NonRewardedId = "video";

        ios.AppId = "3176581";
        ios.BannerId = "banner";
        ios.RewardedId = "rewardVideo";
        ios.NonRewardedId = "video";

    }

    // Start is called before the first frame update
    void Start()
    {
        UM_iAdsClient client = UM_AdvertisementService.GetClient(UM_AdPlatform.Unity);
        client.Initialize((result) => {
            if (result.IsSucceeded)
            {
                Debug.Log("Advertesment platfrom is ready to be used.");
                client.Banner.Load((bannerResult) => {
                    if (bannerResult.IsSucceeded)
                    {
                        Debug.Log("Banner ad loaded");
                        bool ready = client.Banner.IsReady;

                        if (ready)
                        {
                            client.Banner.Show(() => {
                                Debug.Log("Banner Appeared");
                            });
                        }
                    }
                    else
                    {
                        Debug.Log("Failed to load banner ads: " + bannerResult.Error.Message);
                    }
                });
            }
            else
            {
                Debug.Log("Failed to init " + result.Error.FullMessage);
            }
        });
    }
}
