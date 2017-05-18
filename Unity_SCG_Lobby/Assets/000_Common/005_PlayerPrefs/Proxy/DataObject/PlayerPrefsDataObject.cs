using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using PureMVC.Interfaces;
using PureMVC.Patterns;
using System.Text;
using System.IO;

namespace PlayerPrefsNamespace
{
    public class PlayerPrefsDataObject
    {
        public enum Enum_PlayerPrefs
        {
            tokenFromServer,
            LoadingSceneAssetBundle_EN,
            LobbySceneAssetBundle_EN,
            LoadingSceneAssetBundle_TD,
            LobbySceneAssetBundle_TD,
        }
            
        public bool SetPlayerPrefsData(Enum_PlayerPrefs enum_PlayerPrefs, string data)
        {
            bool rt = false;
            string checkData = string.Empty;

            PlayerPrefs.SetString(enum_PlayerPrefs.ToString(), data);
            checkData = PlayerPrefs.GetString(enum_PlayerPrefs.ToString());

            if(data == checkData)
            {
                rt = true;
            }
            else
            {
                rt = false;
            }

            return rt;
        }

        public string GetPlayerPrefsData(Enum_PlayerPrefs enum_PlayerPrefs)
        {
            string data = string.Empty;

            data = PlayerPrefs.GetString(enum_PlayerPrefs.ToString());

            return data;
        }

    }
}