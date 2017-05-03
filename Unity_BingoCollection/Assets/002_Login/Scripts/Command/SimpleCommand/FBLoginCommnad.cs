using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using PureMVC.Interfaces;
using PureMVC.Patterns;
using Facebook.Unity;

using LoginNamespace;
using DefineNamespace;

public class FBLoginCommnad : SimpleCommand, ICommand
{
    public override void Execute(INotification notification)
    {
        FBLogin();
    }

    private void InitCallback()
    {
        if (FB.IsInitialized)
        {
            // Signal an app activation App Event
            FB.ActivateApp();
            // Continue with Facebook SDK
            // ...
            var perms = new List<string>() { "public_profile", "email", "user_friends" };
            FB.LogInWithReadPermissions(perms, AuthCallback);
        }
        else
        {
            Debug.Log("Failed to Initialize the Facebook SDK");
        }
    }

    private void OnHideUnity(bool isGameShown)
    {
        if (!isGameShown)
        {
            // Pause the game - we will need to hide
            Time.timeScale = 0;
        }
        else
        {
            // Resume the game - we're getting focus again
            Time.timeScale = 1;
        }
    }

    private void AuthCallback(ILoginResult result)
    {
        if (FB.IsLoggedIn)
        {
            // AccessToken class will have session details
            var aToken = Facebook.Unity.AccessToken.CurrentAccessToken;
            // Print current access token's User ID
            Debug.Log(aToken.UserId);
            // Print current access token's granted permissions
            foreach (string perm in aToken.Permissions)
            {
                Debug.Log(perm);
            }

            FB.API("me/picture?width=200", HttpMethod.GET, delegate (IGraphResult graphResult)
            {
                if (string.IsNullOrEmpty(result.Error))
                {
                    Debug.Log("received texture with resolution " + graphResult.Texture.width + "x" + graphResult.Texture.height);

                    SendNotification(Define.Notification.Login_FBLoginNotify, Sprite.Create(graphResult.Texture, new Rect(0, 0, 200, 200), new Vector2(0, 0)));
                }
                else
                {
                    Debug.LogWarning("received error=" + result.Error);
                }
            });
        }
        else
        {
            Debug.Log("User cancelled login");
        }
    }

    private void FBLogin()
    {
        if (!FB.IsInitialized)
        {
            // Initialize the Facebook SDK
            FB.Init(InitCallback, OnHideUnity);
        }
        else
        {
            // Already initialized, signal an app activation App Event
            FB.ActivateApp();
            // Continue with Facebook SDK
            // ...
            var perms = new List<string>() { "public_profile", "email", "user_friends" };
            FB.LogInWithReadPermissions(perms, AuthCallback);
        }
    }
}
