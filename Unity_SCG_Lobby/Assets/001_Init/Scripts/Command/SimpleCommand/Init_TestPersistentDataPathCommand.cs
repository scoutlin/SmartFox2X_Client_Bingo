using PureMVC.Interfaces;
using PureMVC.Patterns;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BingoFacadeNamespace;
using DefineNamespace;

namespace PersistentDataPathNamespace
{
    public class Init_TestPersistentDataPathCommand : SimpleCommand, ICommand
    {
        private PersistentDataPathProxy mInit_PersistentDataPathProxy;

        public override void Execute(INotification notification)
        {
            string token = string.Empty;

            mInit_PersistentDataPathProxy = (PersistentDataPathProxy)BingoFacade.Instance.RetrieveProxy(Define.Proxy.PersistentDataPathProxy);

            PersistentDataPathDataObject.InitSettingData mInitSettingData = new PersistentDataPathDataObject.InitSettingData();

            token = "!!!!!!!!!!!!!!!!!!!!!!!  PersistentDataPath  !!!!!!!!!!!!!!!!!!";

            
            mInitSettingData.token = token;
            mInit_PersistentDataPathProxy.WriteSettingFile(mInitSettingData);
            Debug.Log("Write token into PersistentDataPath: " + token);

            token = string.Empty;
            Debug.Log("Clear token: " + token);

            token = mInit_PersistentDataPathProxy.ReadSettingFile().token;
            Debug.Log("Read token from PersistentDataPath: " + token);
        }
    }
}