using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using PureMVC.Interfaces;
using PureMVC.Patterns;

using DefineNamespace;

namespace PersistentDataPathNamespace
{
    public class Init_InitMediator : Mediator, IMediator
    {
        private InitView mInitView;

        public Init_InitMediator(InitView mInitView, string name) : base(name, mInitView)
		{
            this.mInitView = ((InitView)m_viewComponent);
        }




        public override IList<string> ListNotificationInterests()
        {
            IList<string> list = new List<string>();
            list.Add(Define.Notification.Init_InitNotify);
            list.Add(Define.Notification.Init_LoadLoginNotify);
            return list;
        }

        public override void HandleNotification(INotification note)
        {
            switch (note.Name)
            {
                case Define.Notification.Init_InitNotify:
                    {
                        mInitView.StartRunLoadingBar();
                    }
                    break;

                case Define.Notification.Init_LoadLoginNotify:
                    {
                        mInitView.LoadLoadingSceneAddtive();
                    }
                    break;
            }
        }
    }
}