using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using PureMVC.Patterns;
using PureMVC.Interfaces;

using DefineNamespace;
using BingoFacadeNamespace;
using PlayerPrefsNamespace;
using RESTFulNamespace;
using SmartFox2XClientNamespace;
using PersistentDataPathNamespace;
using FBClientAPINamespace;

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
            mFacade.RegisterProxy(new PlayerPrefsProxy(Define.Proxy.PlayerPrefsProxy));
            mFacade.RegisterProxy(new RESTFulProxy(Define.Proxy.RESTFulProxy));
            mFacade.RegisterProxy(new SmartFox2XClientProxy(Define.Proxy.SmartFox2XClientProxy));
            mFacade.RegisterProxy(new PersistentDataPathProxy(Define.Proxy.PersistentDataPathProxy));
            mFacade.RegisterProxy(new FBClientProxy(Define.Proxy.FBClientProxy));

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



            Application.runInBackground = true;
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
