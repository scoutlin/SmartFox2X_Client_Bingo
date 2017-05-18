using BingoFacadeNamespace;
using DefineNamespace;
using PureMVC.Interfaces;
using PureMVC.Patterns;
using SmartFox2XClientNamespace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LoginNamespace
{
    public class Login_InitialSmartFox2XClientCommnad : SimpleCommand, ICommand
    {
        private SmartFox2XClientProxy mSmartFox2XClientProxy;

        public override void Execute(INotification notification)
        {
            mSmartFox2XClientProxy = (SmartFox2XClientProxy)BingoFacade.Instance.RetrieveProxy(Define.Proxy.SmartFox2XClientProxy);

            //Init Server and notify sucess or fail
            mSmartFox2XClientProxy.InitSmartFox2XClient();
        }
    }
}