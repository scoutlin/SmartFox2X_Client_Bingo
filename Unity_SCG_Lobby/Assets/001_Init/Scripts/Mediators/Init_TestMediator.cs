using DefineNamespace;
using PureMVC.Interfaces;
using PureMVC.Patterns;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PersistentDataPathNamespace
{
    public class Init_TestMediator : Mediator, IMediator
    {
        private InitTestView mInitTestView;

        public Init_TestMediator(InitTestView mInitTestView, string name) : base(name, mInitTestView)
		{
            this.mInitTestView = ((InitTestView)m_viewComponent);
            this.mInitTestView.SetMediatorRef(this);
        }

        #region EventFromView
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
            SendNotification(Define.Command.Init_TestRESTFulCommand);
            Debug.Log("OnRESTFulFuckWebsiteClick");
        }

        public void OnTestWriteReadFileClick()
        {
            SendNotification(Define.Command.Init_TestPersistentDataPathCommand);
            Debug.Log("OnTestWriteReadFileClick");
        }

        public void OnTestPlayerPrefsClick()
        {
            SendNotification(Define.Command.Init_TestPlayerPrefsCommnad);
            Debug.Log("OnReadSettingFileClick");
        }
        #endregion



        public override IList<string> ListNotificationInterests()
        {
            IList<string> list = new List<string>();
            //list.Add(Define.Notification.TestRESTFulNotify);
            return list;
        }

        public override void HandleNotification(INotification note)
        {
            switch (note.Name)
            {
                default:
                    {

                    }
                    break;
                //case Define.Notification.TestRESTFulNotify:
                //   {
                //        
                //   }
                //   break;
            }
        }
    }
}