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
        builder.SetText("I have achived a high score of " + PlayerPrefsController.GetBestScore() + " in #HeadBouncer. Will you do better ? You can find this game on Google Play and App Store");
#if UNITY_ANDROID
        builder.SetUrl("https://play.google.com/");
#elif UNITY_IOS
        builder.SetUrl("https://apps.apple.com");
#endif

        client.ShareToTwitter(builder, (result) => {
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
