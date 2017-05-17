using DefineNamespace;
using PureMVC.Interfaces;
using PureMVC.Patterns;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InitNamespace
{
    public class Init_TestPlayerPrefsCommnad : SimpleCommand, ICommand
    {
        private Init_PlayerPrefsProxy mInitSettingDataProxy;

        public override void Execute(INotification notification)
        {
            string tokenFromServer = string.Empty;

            Debug.Log("TestReadSettingFileCommnad - Execute()");

            mInitSettingDataProxy = (Init_PlayerPrefsProxy)BingoFacadeNamespace.BingoFacade.Instance.RetrieveProxy(Define.Proxy.Init_PlayerPrefsProxy);

            tokenFromServer = "!!!!!!!!!!!!!  PlayerPrefs  !!!!!!!!!!!!!";

            if(mInitSettingDataProxy.Get_TokenFromServer() == string.Empty)
            {
                //Is empty write something in 
                Debug.Log("Is empty!!");
                mInitSettingDataProxy.Set_TokenFromServer(tokenFromServer);
            }
            else
            {
                //Is not empty clean it
                Debug.Log("Is not empty");
                mInitSettingDataProxy.Set_TokenFromServer(string.Empty);
            }
            

            tokenFromServer = mInitSettingDataProxy.Get_TokenFromServer();

            Debug.Log("mInitSettingDataProxy.Get_TokenFromServer: " + tokenFromServer);
        }
    }
}
