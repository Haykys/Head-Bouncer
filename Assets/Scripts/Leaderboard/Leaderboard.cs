using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SA.CrossPlatform.GameServices;

public class Leaderboard : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var client = UM_GameService.LeaderboardsClient;
        var signInClient = UM_GameService.SignInClient;
        var leaderboardId = "CgkItt_m-csZEAIQAA";
        int bestScore = PlayerPrefsController.GetBestScore();
        int context = 0;

        if (bestScore >= 5)
        {

            if (signInClient.PlayerInfo.State == UM_PlayerState.SignedIn)
            {
                client.SubmitScore(leaderboardId, bestScore, context, (result) => {
                    if (result.IsSucceeded)
                    {
                        Debug.Log("Score submitted successfully");
                    }
                    else
                    {
                        Debug.Log("Failed to submit score: " + result.Error.FullMessage);
                    }
                });
            }
        }
    }

    public void DisplayLeaderboard()
    {
        var client = UM_GameService.LeaderboardsClient;
        var leaderboardId = "CgkItt_m-csZEAIQAA";

        client.ShowUI(leaderboardId, (result) => {
            if (result.IsSucceeded)
            {
                Debug.Log("User closed Leaderboards native view");
            }
            else
            {
                Debug.Log("Failed to start Leaderboards native view: " + result.Error.FullMessage);
            }
        });
    }
}
