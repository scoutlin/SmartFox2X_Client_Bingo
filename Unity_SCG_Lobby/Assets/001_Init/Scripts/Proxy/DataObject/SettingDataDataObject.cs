using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using PureMVC.Interfaces;
using PureMVC.Patterns;
using System.Text;
using System.IO;

namespace InitNamespace
{
    public class SettingDataDataObject
    {
        public class InitSettingData
        {
            public string token;
        }

        private string filePath = Application.persistentDataPath + "/settings.txt";
        private bool isFileExist = false;


        //Example
        void SaveTextureToFile(Texture2D texture, string filename)
        {
            System.IO.File.WriteAllBytes(filename, texture.EncodeToPNG());
        }

        public bool GetIsFileExist()
        {
            return isFileExist;
        }

        public bool CheckSettingFileExist()
        {
            isFileExist = File.Exists(filePath);

            return isFileExist;
        }

        public void WriteSettingData(InitSettingData mInitSettingData)
        {
            //Test
            string json = JsonUtility.ToJson(mInitSettingData);

            byte[] jsonToBytes = Encoding.ASCII.GetBytes(json);

            File.WriteAllBytes(filePath, jsonToBytes);
        }

        public InitSettingData ReadSettingData()
        {
            InitSettingData mInitSettingData = new InitSettingData();

            byte[] jsonToBytes = File.ReadAllBytes(filePath);

            string json = Encoding.ASCII.GetString(jsonToBytes);

            mInitSettingData = JsonUtility.FromJson<InitSettingData>(json);

            return mInitSettingData;
        }
    }
}