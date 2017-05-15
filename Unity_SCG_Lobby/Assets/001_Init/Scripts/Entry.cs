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
            mFacade.RegisterProxy(new SettingDataProxy(Define.Proxy.SettingDataProxy));
            mFacade.RegisterProxy(new TestRESTFulProxy(Define.Proxy.RESTFulTestProxy));
            mFacade.RegisterProxy(new SmartFox2XClientProxy(Define.Proxy.SmartFox2XClientProxy));

            //RegistMediator
            mFacade.RegisterMediator(new InitMediator(mInitView, Define.Mediator.InitMediator));
            mFacade.RegisterMediator(new InitTestMediator(mInitTestView, Define.Mediator.InitTestMediator));

            //RegistCommand
            mFacade.RegisterCommand(Define.Command.InitSimpleCommnad, typeof(InitSimpleCommand));
            mFacade.RegisterCommand(Define.Command.InitMacroCommand, typeof(MacroCommand));

            mFacade.RegisterCommand(Define.Command.TestRESTFulCommand, typeof(TestRESTFulCommand));
            mFacade.RegisterCommand(Define.Command.TestReadSettingFileCommnad, typeof(TestReadSettingFileCommnad));
            mFacade.RegisterCommand(Define.Command.CheckSettingDataCommand, typeof(CheckSettingDataCommand));
        }

        // Use this for initialization
        void Start()
        {
            BingoFacade.Instance.SendNotification(Define.Notification.InitNotify);
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
