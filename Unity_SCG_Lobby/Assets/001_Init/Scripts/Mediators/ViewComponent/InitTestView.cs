using DefineNamespace;
using UnityEngine;

namespace InitNamespace
{
    public class InitTestView : MonoBehaviour
    {
        private InitTestMediator mInitTestMediator;

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

        public void SetMediatorRef(InitTestMediator mInitTestMediator)
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

        public void OnReadSettingFileClick()
        {
            Debug.Log("OnReadSettingFileClick");
            mInitTestMediator.OnReadSettingFileClick();
        }
        #endregion



        #region Methold
        public void SetLoadingBarValue(float value)
        {

        }
        #endregion
    }
}