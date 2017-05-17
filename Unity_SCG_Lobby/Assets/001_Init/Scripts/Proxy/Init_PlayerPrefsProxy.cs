﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using PureMVC.Interfaces;
using PureMVC.Patterns;

namespace InitNamespace
{
    public class Init_PlayerPrefsProxy : Proxy, IProxy
    {
        private PlayerPrefsDataObject mPlayerPrefsDataObject;

        public Init_PlayerPrefsProxy(string name) : base(name, new PlayerPrefsDataObject())
        {
            mPlayerPrefsDataObject = (PlayerPrefsDataObject)Data;
            
        }

        public bool Set_TokenFromServer(string data)
        {
            bool rt = false;

            rt = mPlayerPrefsDataObject.SetPlayerPrefsData(PlayerPrefsDataObject.Enum_PlayerPrefs.tokenFromServer, data);

            return rt;
        }

        public string Get_TokenFromServer()
        {
            string data = string.Empty;

            data = mPlayerPrefsDataObject.GetPlayerPrefsData(PlayerPrefsDataObject.Enum_PlayerPrefs.tokenFromServer);

            return data;
        }
    }
}