using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SA.Foundation.Utility;
using SA.CrossPlatform.Social;

public class ShareOnTwitter : MonoBehaviour
{
    public void OnClickShare()
    {
        var client = UM_SocialService.SharingClient;
        var builder = new UM_ShareDialogBuilder();
#if PLATFORM_ANDROID
        builder.SetUrl("https://play.google.com/store/apps/details?id=com.saiked.headbouncer");
        builder.SetText("I have achived a high score of " + PlayerPrefsController.GetBestScore() + " in #HeadBouncer. Will you do better ? You can find this game on Google Play");
#elif PLATFORM_UNITY
        builder.SetUrl("https://apps.apple.com/us/app/head-bouncer/id1471767673");
        builder.SetText("I have achived a high score of " + PlayerPrefsController.GetBestScore() + " in #HeadBouncer. Will you do better ? You can find this game on App Store");
#endif

        client.SystemSharingDialog(builder, (result) => {
            if (result.IsSucceeded)
            {
                Debug.Log("Sharing started ");
            }
            else
            {
                Debug.Log("Failed to share: " + result.Error.FullMessage);
            }
        });
    }
}