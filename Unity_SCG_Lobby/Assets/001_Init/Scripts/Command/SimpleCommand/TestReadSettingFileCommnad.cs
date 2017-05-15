using DefineNamespace;
using PureMVC.Interfaces;
using PureMVC.Patterns;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InitNamespace
{
    public class TestReadSettingFileCommnad : SimpleCommand, ICommand
    {
        private SettingDataProxy mInitSettingDataProxy;

        public override void Execute(INotification notification)
        {
            Debug.Log("TestReadSettingFileCommnad - Execute()");

            mInitSettingDataProxy = (SettingDataProxy)BingoFacadeNamespace.BingoFacade.Instance.RetrieveProxy(Define.Proxy.SettingDataProxy);


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
