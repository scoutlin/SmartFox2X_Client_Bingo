using Facebook.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FBClientAPINamespace
{
    public class FBClientDataObject
    {
        private FBClientProxy mFBClientProxy;

        public void SetReference(FBClientProxy mFBClientProxy)
        {
            this.mFBClientProxy = mFBClientProxy;
        }

        public bool GetIsFBLoggedIn()
        {
            return FB.IsLoggedIn;
        }

        public void Login()
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
                FB.LogInWithReadPermissions(perms, OnLogin);
            }
        }

        private void OnLogin(ILoginResult result)
        {
            if (FB.IsLoggedIn)
            {
                // AccessToken class will have session details
                AccessToken aToken = AccessToken.CurrentAccessToken;
                // Print current access token's User ID
                Debug.Log("UserID: " + aToken.UserId);
                Debug.Log("ExpirationTime: " + aToken.ExpirationTime);
                Debug.Log("LastRefresh:" + aToken.LastRefresh);
                Debug.Log("TokenString: " + aToken.TokenString);

                // Print current access token's granted permissions
                foreach (string perm in aToken.Permissions)
                {
                    Debug.Log(perm);
                }

                ////Get Profile Picture
                //FB.API("me/picture?width=200", HttpMethod.GET, delegate (IGraphResult graphResult)
                //{
                //    if (string.IsNullOrEmpty(result.Error))
                //    {
                //        Debug.Log("received texture with resolution " + graphResult.Texture.width + "x" + graphResult.Texture.height);

                //        SendNotification(Define.Notification.Login_FBLoginCompleteNotify, Sprite.Create(graphResult.Texture, new Rect(0, 0, 200, 200), new Vector2(0, 0)));
                //    }
                //    else
                //    {
                //        Debug.LogWarning("received error=" + result.Error);
                //    }
                //});

                mFBClientProxy.OnLogin(aToken.TokenString);
            }
            else
            {
                Debug.Log("User cancelled login");
                mFBClientProxy.OnLogin(null);
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

        private void InitCallback()
        {
            if (FB.IsInitialized)
            {
                // Signal an app activation App Event
                FB.ActivateApp();
                // Continue with Facebook SDK
                // ...
                var perms = new List<string>() { "public_profile", "email", "user_friends" };
                FB.LogInWithReadPermissions(perms, OnLogin);
            }
            else
            {
                Debug.Log("Failed to Initialize the Facebook SDK");
            }
        }
    }
}