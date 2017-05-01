using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using PureMVC.Interfaces;
using PureMVC.Patterns;

using Facebook.Unity;

namespace LoginNamespace
{
    public class LoginMediator : Mediator, IMediator
    {
        private LoginView mLoginView;

        public LoginMediator(LoginView mLoginView, string name) : base(name, mLoginView)
		{
            this.mLoginView = ((LoginView)m_viewComponent);
            this.mLoginView.SetMediatorRef(this);
        }

        #region EventFromView
        public void OnLoginClick()
        {

        }


        private void InitCallback()
        {
            if(FB.IsInitialized)
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
            }
            else
            {
                Debug.Log("User cancelled login");
            }
        }


        public void OnFBLoginClick()
        {
            Debug.Log("LoginMediator - OnFBLoginClick");

            if(!FB.IsInitialized)
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

        public void OnDonateClick()
        {

        }
        #endregion




        public override IList<string> ListNotificationInterests()
        {
            IList<string> list = new List<string>();
            //list.Add(Init.Define.Notification.InitNotify);
            return list;
        }

        public override void HandleNotification(INotification note)
        {
            switch (note.Name)
            {

            }
        }
    }
}