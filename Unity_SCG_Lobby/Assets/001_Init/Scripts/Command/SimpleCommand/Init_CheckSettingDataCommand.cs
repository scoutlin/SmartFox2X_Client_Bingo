using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using PureMVC.Interfaces;
using PureMVC.Patterns;
using System.IO;

using DefineNamespace;

namespace InitNamespace
{
    public class Init_CheckSettingDataCommand : SimpleCommand, ICommand
    {
        public Init_PlayerPrefsProxy mSettingDataProxy;

        private string tokenFromServer = string.Empty;


        public override void Execute(INotification notification)
        {
            //mSettingDataProxy = (Init_SettingDataProxy)BingoFacadeNamespace.BingoFacade.Instance.RetrieveProxy(Define.Proxy.Init_SettingDataProxy);

            //tokenFromServer = mSettingDataProxy.Get_TokenFromServer();

            SendNotification(Define.Notification.Init_LoadLoginNotify);
        }
    }
}