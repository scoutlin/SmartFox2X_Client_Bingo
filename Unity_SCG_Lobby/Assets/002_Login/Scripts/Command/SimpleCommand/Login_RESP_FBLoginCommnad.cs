﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using PureMVC.Patterns;
using PureMVC.Interfaces;

namespace LoginNamespace
{
    public class Login_RESP_FBLoginCommnad : SimpleCommand, ICommand
    {
        public override void Execute(INotification notification)
        {
            //
        }
    }
}