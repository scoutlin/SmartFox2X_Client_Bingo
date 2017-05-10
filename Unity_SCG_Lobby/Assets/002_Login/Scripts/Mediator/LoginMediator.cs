using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using PureMVC.Interfaces;
using PureMVC.Patterns;

using Facebook.Unity;
using Facebook.Unity.Example;
using DefineNamespace;

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

        public void OnFBLoginClick()
        {
            Debug.Log("LoginMediator - OnFBLoginClick");
            SendNotification(Define.Command.FBLoginCommnad);
        }

        public void OnFBLogoutClick()
        {
            Debug.Log("LoginMediator - OnFBLogoutClick");
            SendNotification(Define.Command.FBLogoutCommnad);
        }

        public void OnDonateClick()
        {

        }
        #endregion




        public override IList<string> ListNotificationInterests()
        {
            IList<string> list = new List<string>();
            list.Add(Define.Notification.Login_FBLoginNotify);
            return list;
        }

        public override void HandleNotification(INotification notify)
        {
            switch (notify.Name)
            {
                default:
                    {

                    }
                    break;

                case Define.Notification.Login_FBLoginNotify:
                    {
                        Login_FBLogin(notify.Body);
                    }
                    break;
            }
        }



        private void Login_FBLogin(object sprite)
        {
            mLoginView.Login_FBLogin((Sprite)sprite);
        }
    }
}