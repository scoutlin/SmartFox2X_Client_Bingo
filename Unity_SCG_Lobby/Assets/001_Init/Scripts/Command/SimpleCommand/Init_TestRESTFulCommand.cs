using DefineNamespace;
using PureMVC.Interfaces;
using PureMVC.Patterns;
using RESTFulNamespace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PersistentDataPathNamespace
{
    public class Init_TestRESTFulCommand : SimpleCommand, ICommand
    {
        private RESTFulProxy mRESTFulTestProxy;

        public override void Execute(INotification notification)
        {
            mRESTFulTestProxy = (RESTFulProxy)BingoFacadeNamespace.BingoFacade.Instance.RetrieveProxy(Define.Proxy.RESTFulProxy);

            mRESTFulTestProxy.RESTFulTest();
        }
    }
}