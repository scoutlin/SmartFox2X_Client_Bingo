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
        public Init_SettingDataProxy mSettingDataProxy;

        private bool isSettingFileExist = false;
        private bool isFBLogin = false;


        public override void Execute(INotification notification)
        {
            mSettingDataProxy = (Init_SettingDataProxy)BingoFacadeNamespace.BingoFacade.Instance.RetrieveProxy(Define.Proxy.Init_SettingDataProxy);

            isSettingFileExist = mSettingDataProxy.CheckSettingFileExist();


            SendNotification(Define.Notification.Init_LoadLoginNotify);  
        }
    }
}