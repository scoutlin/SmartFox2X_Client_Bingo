using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using InitNamespace;
using BingoFacadeNamespace;
using DefineNamespace;
using PureMVC.Patterns;
using PureMVC.Interfaces;

namespace LoginNamespace
{
    public class Login_REQ_QuickLoginCommnad : SimpleCommand, ICommand
    {
        public override void Execute(INotification notification)
        {
            //
        }
    }
}