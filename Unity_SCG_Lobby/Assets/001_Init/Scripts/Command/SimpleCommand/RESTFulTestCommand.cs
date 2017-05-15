using DefineNamespace;
using PureMVC.Interfaces;
using PureMVC.Patterns;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InitNamespace
{
    public class TestRESTFulCommand : SimpleCommand, ICommand
    {
        private RESTFulTestProxy mRESTFulTestProxy;

        public override void Execute(INotification notification)
        {
            mRESTFulTestProxy = (RESTFulTestProxy)BingoFacadeNamespace.BingoFacade.Instance.RetrieveProxy(Define.Proxy.RESTFulTestProxy);

            mRESTFulTestProxy.RESTFulTest();
        }
    }
}