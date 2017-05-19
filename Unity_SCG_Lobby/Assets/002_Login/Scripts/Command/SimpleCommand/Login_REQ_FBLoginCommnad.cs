using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using PureMVC.Interfaces;
using PureMVC.Patterns;
using Facebook.Unity;

using LoginNamespace;
using DefineNamespace;
using SmartFox2XClientNamespace;
using BingoFacadeNamespace;
using FBClientAPINamespace;

namespace LoginNamespace
{
    public class Login_REQ_FBLoginCommnad : SimpleCommand, ICommand
    {
        private SmartFox2XClientProxy mSmartFox2XClientProxy;
        private FBClientProxy mFBClientProxy;

        public override void Execute(INotification notification)
        {
            mSmartFox2XClientProxy = (SmartFox2XClientProxy)BingoFacade.Instance.RetrieveProxy(Define.Proxy.SmartFox2XClientProxy);
            mFBClientProxy = (FBClientProxy)BingoFacade.Instance.RetrieveProxy(Define.Proxy.FBClientProxy);

            //First Check if FB Login
            if (mFBClientProxy.GetIsLogin() == false)
            {
                //Get Token from FB
                mFBClientProxy.Login();
            }
            else
            {

                //Second Check is connected with SFS
                if (mSmartFox2XClientProxy.GetIsConnected() == false)
                {
                    //Connect server
                    mSmartFox2XClientProxy.Connect();
                    mSmartFox2XClientProxy.SetLoginType("FB");
                    Debug.Log("Login_REQ_FBLoginCommnad - Execute - mSmartFox2XClientProxy.Login()!!");
                }
                else
                {
                    //FB Login
                    mSmartFox2XClientProxy.Login(null, mFBClientProxy.GetFBToken());
                }
            }
        }
    }
}