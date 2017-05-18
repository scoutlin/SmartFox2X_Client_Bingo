using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using PureMVC.Interfaces;
using PureMVC.Patterns;

namespace PersistentDataPathNamespace
{
    public class Init_SimpleCommand : SimpleCommand, ICommand
    {
        public override void Execute(INotification notification)
        {

        }
    }
}