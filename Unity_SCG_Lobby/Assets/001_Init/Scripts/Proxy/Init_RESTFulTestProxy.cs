using PureMVC.Interfaces;
using PureMVC.Patterns;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InitNamespace
{
    public class Init_TestRESTFulProxy : Proxy, IProxy
    {
        private RESTFulTestDataObject mRESTFulTestDataObject;

        public Init_TestRESTFulProxy(string name) : base(name, new RESTFulTestDataObject())
        {
            mRESTFulTestDataObject = (RESTFulTestDataObject)Data;

        }

        public void RESTFulTest()
        {
            mRESTFulTestDataObject.TestRESTFul();
        }
    }
}