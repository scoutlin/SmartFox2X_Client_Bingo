using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InitNamespace
{
    public class RESTFulTestDataObject
    {
        public RESTFulTestDataObject()
        {

        }

        public void RESTFulTest()
        {
            RESTFulNamespace.RESTFul.REQ_TestPOST_JOSN mREQ_TestPOST_JOSN = new RESTFulNamespace.RESTFul.REQ_TestPOST_JOSN();
            mREQ_TestPOST_JOSN.account = "Scott";
            mREQ_TestPOST_JOSN.password = "Fuck!!";

            RESTFulNamespace.RESTFul.RESP_TestPOST_JOSN mRESP_TestPOST_JOSN = RESTFulNamespace.RESTFul.GetInstance().TestPOST_JOSN("http://localhost:8081/scgTest", mREQ_TestPOST_JOSN);

            Debug.Log("RESP_TestPOST_JOSN: " + mRESP_TestPOST_JOSN.account + "/" + mRESP_TestPOST_JOSN.token);
        }
    }
}