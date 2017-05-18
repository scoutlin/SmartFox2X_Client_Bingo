using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using PureMVC.Patterns;
using PureMVC.Interfaces;

using DefineNamespace;
using BingoFacadeNamespace;
using SmartFox2XClientNamespace;

namespace LoginNamespace
{
    public class Entry : MonoBehaviour
    {
        public LoginView mLoginView;

        private SmartFox2XClientProxy mSmartFox2XClientProxy;

        void Awake()
        {
            IFacade mFacade = BingoFacade.Instance;

            //RegistProxy
            //mFacade.RegisterProxy(new InitProxy(Define.Proxy.InitProxy));

            //RegistMediator
            mFacade.RegisterMediator(new Login_LoginMediator(mLoginView, Define.Mediator.Login_LoginMediator));

            //RegistCommand
            //mFacade.RegisterCommand(Define.Command.InitMacroCommand, typeof(MacroCommand));
            mFacade.RegisterCommand(Define.Command.Login_InitCommnad, typeof(Login_LoginInitCommnad));

            mFacade.RegisterCommand(Define.Command.Login_InitialSmartFox2XClientCommnad, typeof(Login_InitialSmartFox2XClientCommnad));

            mFacade.RegisterCommand(Define.Command.Login_REQ_QuickLoginCommnad, typeof(Login_REQ_QuickLoginCommnad));
            mFacade.RegisterCommand(Define.Command.Login_RESP_QuickLoginCommnad, typeof(Login_RESP_QuickLoginCommnad));

            mFacade.RegisterCommand(Define.Command.Login_REQ_FBLoginCommnad, typeof(Login_REQ_FBLoginCommnad));
            mFacade.RegisterCommand(Define.Command.Login_RESP_FBLoginCommnad, typeof(Login_RESP_FBLoginCommnad));

            mFacade.RegisterCommand(Define.Command.Login_REQ_TokenLoginCommand, typeof(Login_REQ_TokenLoginCommnad));
            mFacade.RegisterCommand(Define.Command.Login_RESP_TokenLoginCommand, typeof(Login_RESP_TokenLoginCommand));

            mFacade.RegisterCommand(Define.Command.Login_FBLogoutCommnad, typeof(Login_FBLogoutCommnad));
            
        }

        // Use this for initialization
        void Start()
        {
            mSmartFox2XClientProxy = (SmartFox2XClientProxy)BingoFacade.Instance.RetrieveProxy(Define.Proxy.SmartFox2XClientProxy);
            BingoFacade.Instance.SendNotification(Define.Command.Login_InitCommnad);
            Debug.Log("Login_InitCommnad Finished Out");
            BingoFacade.Instance.SendNotification(Define.Command.Login_InitialSmartFox2XClientCommnad);
            Debug.Log("Login_InitialSmartFox2XClientCommnad Finished Out");
        }

        // Update is called once per frame
        void Update()
        {
            if(mSmartFox2XClientProxy.IsSmartFoxinitialized())
            {
                //Ture
                mSmartFox2XClientProxy.ProcessEvents();
                mSmartFox2XClientProxy.AutoProcessReceiveExtensionRequestQueue();
                mSmartFox2XClientProxy.AutoProcessSendExtensionRequestQueue();
            }
            else
            {
                //False
            }
        }
    }
}