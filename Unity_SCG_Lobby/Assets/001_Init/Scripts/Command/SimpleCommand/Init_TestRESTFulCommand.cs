using DefineNamespace;
using PureMVC.Interfaces;
using PureMVC.Patterns;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InitNamespace
{
    public class Init_TestRESTFulCommand : SimpleCommand, ICommand
    {
        private Init_TestRESTFulProxy mRESTFulTestProxy;

        public override void Execute(INotification notification)
        {
            mRESTFulTestProxy = (Init_TestRESTFulProxy)BingoFacadeNamespace.BingoFacade.Instance.RetrieveProxy(Define.Proxy.Init_RESTFulTestProxy);

            mRESTFulTestProxy.RESTFulTest();
        }
    }
}