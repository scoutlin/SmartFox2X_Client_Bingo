using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using PureMVC.Interfaces;
using PureMVC.Patterns;

using DefineNamespace;
using BingoFacadeNamespace;

namespace LobbyNamespace
{
    public class Entry : MonoBehaviour
    {
        public LobbyView mLobbyView;

        void Awake()
        {
            IFacade mFacade = BingoFacade.Instance;

            //RegistProxy
            //mFacade.RegisterProxy(new InitProxy(Define.Proxy.InitProxy));

            //RegistMediator
            mFacade.RegisterMediator(new Lobby_LobbyMediator(mLobbyView, Define.Mediator.Lobby_LobbyMediator));

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