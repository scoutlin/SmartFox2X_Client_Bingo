using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using PureMVC.Interfaces;
using PureMVC.Patterns;
using Facebook.Unity;

using LoginNamespace;
using DefineNamespace;

public class Login_FBLogoutCommnad : SimpleCommand, ICommand
{
    public override void Execute(INotification notification)
    {
        Debug.Log("FBLogoutCommnad - FB.LogOur()");
        FB.LogOut();
    }
}
