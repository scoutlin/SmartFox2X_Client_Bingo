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
            mFacade.RegisterCommand(Define.Command.Login_FBLoginCommnad, typeof(Login_FBLoginCommnad));
            mFacade.RegisterCommand(Define.Command.Login_FBLogoutCommnad, typeof(Login_FBLogoutCommnad));
            mFacade.RegisterCommand(Define.Command.Login_InitCommnad, typeof(Login_LoginInitCommnad));
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