using UnityEngine;

namespace InitNamespace
{
    public class InitTestView : MonoBehaviour
    {
        void Awake()
        {

        }

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {     

        }

        #region ButtonEvent
        public void OnConnectToServerButtonClicked()
        {
            Debug.Log("OnConnectToServerButtonClicked");
        }

        public void OnDisconnectButton()
        {
            Debug.Log("OnDisconnectButton");
        }

        public void OnSwitchToLoginButtonClicked()
        {
            Debug.Log("OnSwitchToLoginButtonClicked");
        }

        public void OnSendInitPacketButtonClicket()
        {
            Debug.Log("OnSendInitPacketButtonClicket");
        }

        public void OnRESTFulFuckWebsiteClicked()
        {
            RESTFulNamespace.RESTFul.REQ_TestPOST_JOSN mREQ_TestPOST_JOSN = new RESTFulNamespace.RESTFul.REQ_TestPOST_JOSN();
            mREQ_TestPOST_JOSN.account = "Scott";
            mREQ_TestPOST_JOSN.password = "Fuck!!";

            RESTFulNamespace.RESTFul.RESP_TestPOST_JOSN mRESP_TestPOST_JOSN = RESTFulNamespace.RESTFul.GetInstance().TestPOST_JOSN("http://localhost:8081/scgTest", mREQ_TestPOST_JOSN);

            ;

            Debug.Log("RESP_TestPOST_JOSN: " + mRESP_TestPOST_JOSN.account + "/" + mRESP_TestPOST_JOSN.token);
        }

        #endregion

        #region Methold
        public void SetLoadingBarValue(float value)
        {

        }
        #endregion
    }
}