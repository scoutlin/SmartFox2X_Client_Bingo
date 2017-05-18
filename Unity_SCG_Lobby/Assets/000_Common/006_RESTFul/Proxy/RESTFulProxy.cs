using PureMVC.Interfaces;
using PureMVC.Patterns;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RESTFulNamespace
{
    public class RESTFulProxy : Proxy, IProxy
    {
        private RESTFulDataObject mRESTFulTestDataObject;

        public RESTFulProxy(string name) : base(name, new RESTFulDataObject())
        {
            mRESTFulTestDataObject = (RESTFulDataObject)Data;

        }

        public void RESTFulTest()
        {
            mRESTFulTestDataObject.TestRESTFul();
        }
    }
}