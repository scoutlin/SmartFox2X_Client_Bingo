﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using PureMVC.Interfaces;
using PureMVC.Patterns;

namespace Init
{
    public class InitSimpleCommand : SimpleCommand, ICommand
    {
        public override void Execute(INotification notification)
        {

        }
    }
}