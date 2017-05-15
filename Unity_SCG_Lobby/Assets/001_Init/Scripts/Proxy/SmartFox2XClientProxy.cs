using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using PureMVC.Interfaces;
using PureMVC.Patterns;

namespace InitNamespace
{
    public class SmartFox2XClientProxy : Proxy, IProxy
    {
        private SmartFox2XClientDataObject mSmartFox2XClientDataObject;

        public SmartFox2XClientProxy(string name) : base(name, new SmartFox2XClientDataObject())
        {
            mSmartFox2XClientDataObject = (SmartFox2XClientDataObject)Data;
        }
    }
}