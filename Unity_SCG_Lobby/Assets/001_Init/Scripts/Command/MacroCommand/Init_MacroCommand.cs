using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using PureMVC.Interfaces;
using PureMVC.Patterns;

namespace PersistentDataPathNamespace
{
    public class Init_MacroCommand : MacroCommand, ICommand
    {
        // Initialize MyMacroCommand
        protected override void InitializeMacroCommand()
        {
            //AddSubCommand(typeof(PrototypeSimpleCommnad));
            Debug.Log("PrototypeMacroCommnad");
        }
    }
}