using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using PureMVC.Interfaces;
using PureMVC.Patterns;

namespace LobbyNamespace
{
    public class LobbyMediator : Mediator, IMediator
    {
        private LobbyView mLobbyView;

        public LobbyMediator(LobbyView mLobbyView, string name) : base(name, mLobbyView)
		{
            this.mLobbyView = ((LobbyView)m_viewComponent);
        }

        public override IList<string> ListNotificationInterests()
        {
            IList<string> list = new List<string>();
            //list.Add(Init.Define.Notification.InitNotify);
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
            }
        }
    }
}