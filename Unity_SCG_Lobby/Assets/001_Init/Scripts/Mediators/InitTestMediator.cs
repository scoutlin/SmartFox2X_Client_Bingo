using DefineNamespace;
using PureMVC.Interfaces;
using PureMVC.Patterns;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InitNamespace
{
    public class InitTestMediator : Mediator, IMediator
    {
        private InitTestView mInitTestView;

        public InitTestMediator(InitTestView mInitTestView, string name) : base(name, mInitTestView)
		{
            this.mInitTestView = ((InitTestView)m_viewComponent);
        }

        public override IList<string> ListNotificationInterests()
        {
            IList<string> list = new List<string>();
            list.Add(Define.Notification.RESTFulTestNotify);
            return list;
        }

        public override void HandleNotification(INotification note)
        {
            switch (note.Name)
            {
                case Define.Notification.RESTFulTestNotify:
                   {
                        SendNotification(Define.Command.InitTestSimpleCommnad);
                   }
                   break;
            }
        }
    }
}