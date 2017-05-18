using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using PersistentDataPathNamespace;
using BingoFacadeNamespace;
using DefineNamespace;
using PureMVC.Patterns;
using PureMVC.Interfaces;
using SmartFox2XClientNamespace;

namespace LoginNamespace
{
    public class Login_REQ_QuickLoginCommnad : SimpleCommand, ICommand
    {
        private SmartFox2XClientProxy mSmartFox2XClientProxy;

        public override void Execute(INotification notification)
        {
            mSmartFox2XClientProxy = (SmartFox2XClientProxy)BingoFacade.Instance.RetrieveProxy(Define.Proxy.SmartFox2XClientProxy);

            //Call SFS2XProxy to login server
            
        }
    }
}