using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using PureMVC.Patterns;
using PureMVC.Interfaces;

using DefineNamespace;
using BingoFacadeNamespace;

namespace InitNamespace
{
    public class Entry : MonoBehaviour
    {
        public InitView mInitView;
        public InitTestView mInitTestView;

        void Awake()
        {
            IFacade mFacade = BingoFacade.Instance;
            
            //RegistProxy
            mFacade.RegisterProxy(new Init_PlayerPrefsProxy(Define.Proxy.Init_PlayerPrefsProxy));
            mFacade.RegisterProxy(new Init_TestRESTFulProxy(Define.Proxy.Init_RESTFulTestProxy));
            mFacade.RegisterProxy(new Init_SmartFox2XClientProxy(Define.Proxy.Init_SmartFox2XClientProxy));
            mFacade.RegisterProxy(new Init_PersistentDataPathProxy(Define.Proxy.Init_PersistentDataPathProxy));

            //RegistMediator
            mFacade.RegisterMediator(new Init_InitMediator(mInitView, Define.Mediator.Init_InitMediator));
            mFacade.RegisterMediator(new Init_TestMediator(mInitTestView, Define.Mediator.Init_TestMediator));

            //RegistCommand
            mFacade.RegisterCommand(Define.Command.Init_SimpleCommnad, typeof(Init_SimpleCommand));
            mFacade.RegisterCommand(Define.Command.Init_MacroCommand, typeof(MacroCommand));

            mFacade.RegisterCommand(Define.Command.Init_TestRESTFulCommand, typeof(Init_TestRESTFulCommand));
            mFacade.RegisterCommand(Define.Command.Init_TestPlayerPrefsCommnad, typeof(Init_TestPlayerPrefsCommnad));
            mFacade.RegisterCommand(Define.Command.Init_CheckSettingDataCommand, typeof(Init_CheckSettingDataCommand));
            mFacade.RegisterCommand(Define.Command.Init_TestPersistentDataPathCommand, typeof(Init_TestPersistentDataPathCommand));
        }

        // Use this for initialization
        void Start()
        {
            BingoFacade.Instance.SendNotification(Define.Notification.Init_InitNotify);
        }

        // Update is called once per frame
        void Update()
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
            }
        }
    }
}
