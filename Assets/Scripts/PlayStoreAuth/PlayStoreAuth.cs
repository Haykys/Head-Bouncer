using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SA.CrossPlatform.GameServices;

public class PlayStoreAuth : MonoBehaviour
{
    [SerializeField] GameObject SignInButton;
    [SerializeField] GameObject SignOutButton;

    private static bool hasTriedToSignInOnStart = false;

    void Start()
    {
        var client = UM_GameService.SignInClient;

        if (client.PlayerInfo.State != UM_PlayerState.SignedIn && !hasTriedToSignInOnStart)
        {
            hasTriedToSignInOnStart = true;

            client.SingIn((result) => {
                if (result.IsSucceeded)
                {
                    Debug.Log("Player is signed");
                }
                else
                {
                    Debug.Log("Sing in failed: " + result.Error.FullMessage);
                }
            });
        }
    }

    private void Update()
    {
        var client = UM_GameService.SignInClient;

        if (client.PlayerInfo.State == UM_PlayerState.SignedIn)
        {
            SignOutButton.SetActive(true);
            SignInButton.SetActive(false);
        } else
        {
            SignOutButton.SetActive(false);
            SignInButton.SetActive(true);
        }
    }

        public void SignIn()
    {
        UM_GameService.SignInClient.SingIn((result) => {
            if (result.IsSucceeded)
            {
                Debug.Log("Player just sign in");
            }
            else
            {
                Debug.Log("Sing out failed: " + result.Error.FullMessage);
            }
        });
    }

    public void SignOut()
    {
        UM_GameService.SignInClient.SingOut((result) => {
            if (result.IsSucceeded)
            {
                Debug.Log("Player is just out");
            }
            else
            {
                Debug.Log("Sing out failed: " + result.Error.FullMessage);
            }
        });
    }
}
