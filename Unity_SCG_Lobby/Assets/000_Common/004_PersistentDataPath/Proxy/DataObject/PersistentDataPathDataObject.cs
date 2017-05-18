using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

namespace PersistentDataPathNamespace
{
    public class PersistentDataPathDataObject
    {
        //Old use specific path and file to save data;
        //Start

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
        //End
    }
}