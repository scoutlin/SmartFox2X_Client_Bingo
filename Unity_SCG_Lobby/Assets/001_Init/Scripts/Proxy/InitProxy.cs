using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using PureMVC.Interfaces;
using PureMVC.Patterns;

namespace InitNamespace
{
    public class InitProxy : Proxy, IProxy
    {
        private InitDataObject mInitDataObject;

        public InitProxy(string name) : base(name, new InitDataObject())
        {
            mInitDataObject = (InitDataObject)Data;
            
        }
    }
}