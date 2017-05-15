using PureMVC.Interfaces;
using PureMVC.Patterns;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InitNamespace
{
    public class TestRESTFulProxy : Proxy, IProxy
    {
        private RESTFulTestDataObject mRESTFulTestDataObject;

        public TestRESTFulProxy(string name) : base(name, new RESTFulTestDataObject())
        {
            mRESTFulTestDataObject = (RESTFulTestDataObject)Data;

        }

        public void RESTFulTest()
        {
            mRESTFulTestDataObject.TestRESTFul();
        }
    }
}