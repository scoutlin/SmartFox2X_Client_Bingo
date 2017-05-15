using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using PureMVC.Interfaces;
using PureMVC.Patterns;
using System.IO;

using DefineNamespace;

namespace InitNamespace
{
    public class CheckSettingDataCommand : SimpleCommand, ICommand
    {
        public SettingDataProxy mSettingDataProxy;

        private bool isSettingFileExist = false;
        private bool isFBLogin = false;


        public override void Execute(INotification notification)
        {
            mSettingDataProxy = (SettingDataProxy)BingoFacadeNamespace.BingoFacade.Instance.RetrieveProxy(Define.Proxy.SettingDataProxy);

            isSettingFileExist = mSettingDataProxy.CheckSettingFileExist();


            //CheckIsSettingFileExist
            if (isSettingFileExist)
            {
                //Skip Login screen
                SendNotification(Define.Notification.LoadLobbyNotify);
            }
            else
            {
                //Has not login or delete file
                //Go to normal login screen
                SendNotification(Define.Notification.LoadLoginNotify);
            }
        }
    }
}