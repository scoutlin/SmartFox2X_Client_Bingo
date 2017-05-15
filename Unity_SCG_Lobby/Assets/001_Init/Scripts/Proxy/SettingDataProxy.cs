using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using PureMVC.Interfaces;
using PureMVC.Patterns;

namespace InitNamespace
{
    public class SettingDataProxy : Proxy, IProxy
    {
        private SettingDataDataObject mInitSettingDataDataObject;

        public SettingDataProxy(string name) : base(name, new SettingDataDataObject())
        {
            mInitSettingDataDataObject = (SettingDataDataObject)Data;
            
        }


        public bool CheckSettingFileExist()
        {
            bool isFileExist;

            isFileExist = mInitSettingDataDataObject.CheckSettingFileExist();

            return isFileExist;
        }

        public SettingDataDataObject.InitSettingData ReadSettingFile()
        {
            SettingDataDataObject.InitSettingData mInitSettingData;

            mInitSettingData = mInitSettingDataDataObject.ReadSettingData();

            return mInitSettingData;
        }

        public bool WriteSettingFile(SettingDataDataObject.InitSettingData mInitSettingData)
        {
            mInitSettingDataDataObject.WriteSettingData(mInitSettingData);

            return false;
        }
    }
}