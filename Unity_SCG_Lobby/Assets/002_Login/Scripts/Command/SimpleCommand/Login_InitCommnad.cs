using PureMVC.Interfaces;
using PureMVC.Patterns;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using InitNamespace;
using BingoFacadeNamespace;
using DefineNamespace;

namespace LoginNamespace
{
    public class Login_LoginInitCommnad : SimpleCommand, ICommand
    {
        private Init_SettingDataProxy mSettingDataProxy;

        public override void Execute(INotification notification)
        {
            mSettingDataProxy = (Init_SettingDataProxy)BingoFacade.Instance.RetrieveProxy(Define.Proxy.Init_SettingDataProxy);

            if(mSettingDataProxy.GetIsFileExist())
            {
                //Not First Login
                //No need display Buttons, start do init connect to server process!!
                SendNotification(Define.Notification.Login_NoNeedLoginNotify);
            }
            else
            {
                //First Login or user settingFile has be delete
                //show login button then by the result of user and do process!!
                SendNotification(Define.Notification.Login_NeedLoginNotify);
            }
        }
    }
}