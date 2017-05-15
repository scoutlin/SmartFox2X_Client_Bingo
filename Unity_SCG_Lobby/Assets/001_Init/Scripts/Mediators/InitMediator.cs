using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using PureMVC.Interfaces;
using PureMVC.Patterns;

using DefineNamespace;

namespace InitNamespace
{
    public class InitMediator : Mediator, IMediator
    {
        private InitView mInitView;

        public InitMediator(InitView mInitView, string name) : base(name, mInitView)
		{
            this.mInitView = ((InitView)m_viewComponent);
        }




        public override IList<string> ListNotificationInterests()
        {
            IList<string> list = new List<string>();
            list.Add(Define.Notification.InitNotify);
            list.Add(Define.Notification.LoadLoginNotify);
            list.Add(Define.Notification.LoadLobbyNotify);
            return list;
        }

        public override void HandleNotification(INotification note)
        {
            switch (note.Name)
            {
                case Define.Notification.InitNotify:
                    {
                        mInitView.StartRunLoadingBar();
                    }
                    break;

                case Define.Notification.LoadLoginNotify:
                    {
                        mInitView.LoadLoadingSceneAddtive();
                    }
                    break;

                case Define.Notification.LoadLobbyNotify:
                    {
                        mInitView.LoadLobbySceneAddtive();
                    }
                    break;
            }
        }
    }
}