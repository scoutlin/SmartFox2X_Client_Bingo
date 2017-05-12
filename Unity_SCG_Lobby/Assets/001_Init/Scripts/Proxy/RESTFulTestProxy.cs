using PureMVC.Interfaces;
using PureMVC.Patterns;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InitNamespace
{
    public class RESTFulTestProxy : Proxy, IProxy
    {
        private RESTFulTestDataObject mRESTFulTestDataObject;

        public RESTFulTestProxy(string name) : base(name, new RESTFulTestDataObject())
        {
            mRESTFulTestDataObject = (RESTFulTestDataObject)Data;

        }

        public void RESTFulTest()
        {
            mRESTFulTestDataObject.RESTFulTest();
        }
    }
}