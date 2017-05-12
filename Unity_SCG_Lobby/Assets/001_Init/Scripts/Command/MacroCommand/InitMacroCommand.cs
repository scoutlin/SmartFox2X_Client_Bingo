using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using PureMVC.Interfaces;
using PureMVC.Patterns;

namespace InitNamespace
{
    public class InitMacroCommand : MacroCommand, ICommand
    {
        // Initialize MyMacroCommand
        protected override void InitializeMacroCommand()
        {
            //AddSubCommand(typeof(PrototypeSimpleCommnad));
            Debug.Log("PrototypeMacroCommnad");
        }
    }
}