using BingoFacadeNamespace;
using DefineNamespace;
using FBClientAPINamespace;
using PlayerPrefsNamespace;
using PureMVC.Interfaces;
using PureMVC.Patterns;
using SmartFox2XClientNamespace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LoginNamespace
{
    public class Login_REQ_TokenLoginCommnad : SimpleCommand, ICommand
    {
        private SmartFox2XClientProxy mSmartFox2XClientProxy;
        private FBClientProxy mFBClientProxy;
        private PlayerPrefsProxy mPlayerPrefsProxy;

        public override void Execute(INotification notification)
        {
            mSmartFox2XClientProxy = (SmartFox2XClientProxy)BingoFacade.Instance.RetrieveProxy(Define.Proxy.SmartFox2XClientProxy);
            mFBClientProxy = (FBClientProxy)BingoFacade.Instance.RetrieveProxy(Define.Proxy.FBClientProxy);
            mPlayerPrefsProxy = (PlayerPrefsProxy)BingoFacade.Instance.RetrieveProxy(Define.Proxy.PlayerPrefsProxy);

            //First Check if FB Login
            if (mFBClientProxy.GetIsLogin() == false)
            {
                //Get Token from FB
                mFBClientProxy.Login();
            }
            else
            {
                //Check is connected with SFS
                if (mSmartFox2XClientProxy.GetIsConnected() == false)
                {
                    //Connect server
                    mSmartFox2XClientProxy.Connect();
                    mSmartFox2XClientProxy.SetLoginType("Token");
                    Debug.Log("Login_REQ_TokenLoginCommnad - Execute - mSmartFox2XClientProxy.Login()!!");
                }
                else
                {
                    //Quick Login
                    mSmartFox2XClientProxy.Login(mPlayerPrefsProxy.Get_TokenFromServer(), mFBClientProxy.GetFBToken());
                }
            }
        }
    }
}