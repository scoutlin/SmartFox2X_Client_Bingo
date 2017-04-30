using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using PureMVC.Patterns;
using PureMVC.Interfaces;

namespace Init
{
    public class Entry : MonoBehaviour
    {
        public InitView mInitView;

        void Awake()
        {
             IFacade mFacade = InitFacade.Instance;

            //RegistProxy
            mFacade.RegisterProxy(new InitProxy(Define.Proxy.InitProxy));

            //RegistMediator
            mFacade.RegisterMediator(new InitMediator(mInitView, Define.Mediator.InitMediator));

            //RegistCommand
            mFacade.RegisterCommand(Define.Command.InitSimpleCommnad, typeof(InitSimpleCommand));
            mFacade.RegisterCommand(Define.Command.InitMacroCommand, typeof(MacroCommand));
        }

        // Use this for initialization
        void Start()
        {
            InitFacade.Instance.SendNotification(Define.Notification.InitNotify);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
