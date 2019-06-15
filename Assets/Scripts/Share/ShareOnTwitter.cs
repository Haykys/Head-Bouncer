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
        builder.SetText("Hello world!");
        builder.SetUrl("https://stansassets.com/");

        Texture2D sampleRedTexture = SA_IconManager.GetIcon(Color.red, 32, 32);
        builder.AddImage(sampleRedTexture);

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
