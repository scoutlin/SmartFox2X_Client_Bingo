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
            mFacade.RegisterMediator(new LoginMediator(mLoginView, Define.Mediator.LoginMediator));

            //RegistCommand
            //mFacade.RegisterCommand(Define.Command.InitSimpleCommnad, typeof(InitSimpleCommand));
            //mFacade.RegisterCommand(Define.Command.InitMacroCommand, typeof(MacroCommand));
        }

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}