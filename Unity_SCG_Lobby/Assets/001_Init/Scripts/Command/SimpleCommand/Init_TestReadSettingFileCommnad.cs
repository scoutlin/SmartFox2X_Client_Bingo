using DefineNamespace;
using PureMVC.Interfaces;
using PureMVC.Patterns;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InitNamespace
{
    public class Init_TestReadSettingFileCommnad : SimpleCommand, ICommand
    {
        private Init_SettingDataProxy mInitSettingDataProxy;

        public override void Execute(INotification notification)
        {
            Debug.Log("TestReadSettingFileCommnad - Execute()");

            mInitSettingDataProxy = (Init_SettingDataProxy)BingoFacadeNamespace.BingoFacade.Instance.RetrieveProxy(Define.Proxy.Init_SettingDataProxy);


            SettingDataDataObject.InitSettingData mInitSettingData = new SettingDataDataObject.InitSettingData();
            mInitSettingData.token = "Jumbo is Goooooooooooood!!!!!";
            mInitSettingDataProxy.WriteSettingFile(mInitSettingData);

            mInitSettingData.token = string.Empty;

            Debug.Log("mInitSettingData.token_SetEmpty: " + mInitSettingData.token);

            mInitSettingData = mInitSettingDataProxy.ReadSettingFile();

            Debug.Log("mInitSettingData.token_LoadFromSettingData: " + mInitSettingData.token);
        }
    }
}
