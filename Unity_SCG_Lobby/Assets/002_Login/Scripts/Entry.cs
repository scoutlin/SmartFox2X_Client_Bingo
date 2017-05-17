using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using PureMVC.Patterns;
using PureMVC.Interfaces;

using DefineNamespace;
using BingoFacadeNamespace;

namespace LoginNamespace
{
    public class Entry : MonoBehaviour
    {
        public LoginView mLoginView;

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
            BingoFacade.Instance.SendNotification(Define.Command.Login_InitCommnad);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}