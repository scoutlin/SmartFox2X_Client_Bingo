using DefineNamespace;
using Facebook.Unity;
using PureMVC.Interfaces;
using PureMVC.Patterns;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FBClientAPINamespace
{
    public class FBClientProxy : Proxy, IProxy
    {
        private FBClientDataObject mFBClientDataObject;

        private string fbToken;

        public FBClientProxy(string name) : base(name, new FBClientDataObject())
        {
            mFBClientDataObject = (FBClientDataObject)Data;
            mFBClientDataObject.SetReference(this);
        }

        public bool GetIsLogin()
        {
            return mFBClientDataObject.GetIsFBLoggedIn();
        }

        public void Login()
        {
            mFBClientDataObject.Login();
        }

        public void OnLogin(string token)
        {
            if(token == null)
            {
                //User Cancel Login
                fbToken = null;
            }
            else
            {
                //User login and get token
                fbToken = token;
                SendNotification(Define.Command.Login_REQ_FBLoginCommnad);
            }
        }

        public string GetFBToken()
        {
            return fbToken;
        }
    }
}