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
        private Init_PlayerPrefsProxy mSettingDataProxy;

        public override void Execute(INotification notification)
        {
            mSettingDataProxy = (Init_PlayerPrefsProxy)BingoFacade.Instance.RetrieveProxy(Define.Proxy.Init_PlayerPrefsProxy);

            Debug.Log("mSettingDataProxy.Get_TokenFromServer: " + mSettingDataProxy.Get_TokenFromServer());

            if (mSettingDataProxy.Get_TokenFromServer() != string.Empty)
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