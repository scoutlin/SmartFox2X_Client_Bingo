using PureMVC.Interfaces;
using PureMVC.Patterns;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InitNamespace
{
    public class Init_PersistentDataPathProxy : Proxy, IProxy
    {
        private PersistentDataPathDataObject mPersistentDataPathDataObject;

        public Init_PersistentDataPathProxy(string name) : base(name, new PersistentDataPathDataObject())
        {
            mPersistentDataPathDataObject = (PersistentDataPathDataObject)Data;


        }


        //Old use specific path and file to save data;
        //Start
        public bool GetIsFileExist()
        {
            bool isFileExist;

            isFileExist = mPersistentDataPathDataObject.GetIsFileExist();

            return isFileExist;
        }

        public bool CheckSettingFileExist()
        {
            bool isFileExist;

            isFileExist = mPersistentDataPathDataObject.CheckSettingFileExist();

            return isFileExist;
        }

        public PersistentDataPathDataObject.InitSettingData ReadSettingFile()
        {
            PersistentDataPathDataObject.InitSettingData mInitSettingData;

            mInitSettingData = mPersistentDataPathDataObject.ReadSettingData();

            return mInitSettingData;
        }

        public bool WriteSettingFile(PersistentDataPathDataObject.InitSettingData mInitSettingData)
        {
            mPersistentDataPathDataObject.WriteSettingData(mInitSettingData);

            return false;
        }
        //END
    }
}