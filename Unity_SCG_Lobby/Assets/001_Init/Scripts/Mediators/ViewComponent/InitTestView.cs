using DefineNamespace;
using UnityEngine;

namespace InitNamespace
{
    public class InitTestView : MonoBehaviour
    {
        private Init_TestMediator mInitTestMediator;

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

        public void SetMediatorRef(Init_TestMediator mInitTestMediator)
        {
            this.mInitTestMediator = mInitTestMediator;
        }



        #region ButtonEvent
        public void OnConnectToServerButtonClick()
        {
            Debug.Log("OnConnectToServerButtonClick");
        }

        public void OnDisconnectButton()
        {
            Debug.Log("OnDisconnectButton");
        }

        public void OnSwitchToLoginButtonClick()
        {
            Debug.Log("OnSwitchToLoginButtonClick");
        }

        public void OnSendInitPacketButtonClick()
        {
            Debug.Log("OnSendInitPacketButtonClick");
        }

        public void OnRESTFulFuckWebsiteClick()
        {
            mInitTestMediator.OnRESTFulFuckWebsiteClick();
            Debug.Log("OnRESTFulFuckWebsiteClick");
        }

        public void OnTestWriteReadFileClick()
        {
            Debug.Log("OnTestPlayerPrefsClick");
            mInitTestMediator.OnTestWriteReadFileClick();
        }

        public void OnTestPlayerPrefsClick()
        {
            Debug.Log("OnTestPlayerPrefsClick");
            mInitTestMediator.OnTestPlayerPrefsClick();
        }
        #endregion



        #region Methold
        public void SetLoadingBarValue(float value)
        {

        }
        #endregion
    }
}