using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using PureMVC.Interfaces;
using PureMVC.Patterns;
using System.Text;

namespace InitNamespace
{
    public class SettingDataDataObject
    {
        public class InitSettingData
        {
            public string token;
        }

        private string filePath = Application.persistentDataPath + "/settings.txt";



        //Example
        void SaveTextureToFile(Texture2D texture, string filename)
        {
            System.IO.File.WriteAllBytes(filename, texture.EncodeToPNG());
        }

        public void WriteSettingData(InitSettingData mInitSettingData)
        {
            //Test
            string json = JsonUtility.ToJson(mInitSettingData);

            byte[] jsonToBytes = Encoding.ASCII.GetBytes(json);

            System.IO.File.WriteAllBytes(filePath, jsonToBytes);
        }

        public InitSettingData ReadSettingData()
        {
            InitSettingData mInitSettingData = new InitSettingData();

            byte[] jsonToBytes = System.IO.File.ReadAllBytes(filePath);

            string json = Encoding.ASCII.GetString(jsonToBytes);

            mInitSettingData = JsonUtility.FromJson<InitSettingData>(json);

            return mInitSettingData;
        }
    }
}