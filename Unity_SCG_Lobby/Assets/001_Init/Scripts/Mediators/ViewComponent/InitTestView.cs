using DefineNamespace;
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
            BingoFacadeNamespace.BingoFacade.Instance.SendNotification(Define.Notification.RESTFulTestNotify);
        }

        #endregion

        #region Methold
        public void SetLoadingBarValue(float value)
        {

        }
        #endregion
    }
}