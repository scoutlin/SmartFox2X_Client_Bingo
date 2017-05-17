using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using PureMVC.Interfaces;
using PureMVC.Patterns;

using Facebook.Unity;
using Facebook.Unity.Example;
using DefineNamespace;
using System;

namespace LoginNamespace
{
    public class Login_LoginMediator : Mediator, IMediator
    {
        private LoginView mLoginView;

        public Login_LoginMediator(LoginView mLoginView, string name) : base(name, mLoginView)
		{
            this.mLoginView = ((LoginView)m_viewComponent);
            this.mLoginView.SetMediatorRef(this);
        }

        #region EventFromView
        public void OnLoginClick()
        {
            Debug.Log("LoginMediator - OnLoginClick");
            mLoginView.SetQuickLoginButtonActice(false);
            mLoginView.SetFBLoginButtonActive(false);
            mLoginView.SetLoginingTextActive(true);    
            SendNotification(Define.Command.Login_REQ_QuickLoginCommnad);
        }

        public void OnFBLoginClick()
        {
            Debug.Log("LoginMediator - OnFBLoginClick");
            mLoginView.SetQuickLoginButtonActice(false);
            mLoginView.SetFBLoginButtonActive(false);
            mLoginView.SetLoginingTextActive(true);
            SendNotification(Define.Command.Login_REQ_FBLoginCommnad);
        }

        public void OnFBLogoutClick()
        {
            Debug.Log("LoginMediator - OnFBLogoutClick");
            SendNotification(Define.Command.Login_FBLogoutCommnad);
        }

        public void OnDonateClick()
        {

        }
        #endregion




        public override IList<string> ListNotificationInterests()
        {
            IList<string> list = new List<string>();
            list.Add(Define.Notification.Login_NeedLoginNotify);
            list.Add(Define.Notification.Login_NoNeedLoginNotify);
            list.Add(Define.Notification.Login_QuickLoginCompleteNotify);
            list.Add(Define.Notification.Login_FBLoginCompleteNotify);  
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

                case Define.Notification.Login_QuickLoginCompleteNotify:
                    {
                        QuickLoginComplete();
                    }
                    break;

                case Define.Notification.Login_FBLoginCompleteNotify:
                    {
                        FBLoginComplete(notify.Body);
                    }
                    break;

                case Define.Notification.Login_NeedLoginNotify:
                    {
                        NeedLogin();
                    }
                    break;

                case Define.Notification.Login_NoNeedLoginNotify:
                    {
                        NoNeedLogin();
                    }
                    break;                
            }
        }

        private void QuickLoginComplete()
        {
            
        }

        private void FBLoginComplete(object sprite)
        {
            mLoginView.Login_FBLogin((Sprite)sprite);
        }

        private void NeedLogin()
        {
            mLoginView.SetFBLoginButtonActive(true);
            mLoginView.SetQuickLoginButtonActice(true);
        }

        private void NoNeedLogin()
        {
            mLoginView.SetLoginingTextActive(true);
        }
    }
}