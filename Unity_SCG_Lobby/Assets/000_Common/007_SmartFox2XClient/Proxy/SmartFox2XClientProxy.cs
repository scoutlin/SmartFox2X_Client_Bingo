using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using PureMVC.Interfaces;
using PureMVC.Patterns;
using Sfs2X;
using Sfs2X.Core;
using Sfs2X.Entities;
using Sfs2X.Entities.Data;
using DefineNamespace;
using System;

namespace SmartFox2XClientNamespace
{
    public class SmartFox2XClientProxy : Proxy, IProxy
    {
        private SmartFox2XClientDataObject mSmartFox2XClientDataObject;

        private string loginType;

        public SmartFox2XClientProxy(string name) : base(name, new SmartFox2XClientDataObject())
        {
            mSmartFox2XClientDataObject = (SmartFox2XClientDataObject)Data;
            mSmartFox2XClientDataObject.SetReference(this);
        }

        public bool IsSmartFoxinitialized()
        {
            bool rt = false;

            if(mSmartFox2XClientDataObject.GetSmartFox() == null)
            {
                rt = false;
            }
            else
            {
                rt = true;
            }

            return rt;
        }

        public void ProcessEvents()
        {
            mSmartFox2XClientDataObject.ProcessEvents();
        }

        public bool InitSmartFox2XClient()
        {
            bool rt = false;

            mSmartFox2XClientDataObject.InitSmartFox();
            mSmartFox2XClientDataObject.RegistSmartFoxEvents();

            return rt;
        }

        public bool GetIsConnected()
        {
            return mSmartFox2XClientDataObject.GetIsConnected();
        }

        public string GetLoginType()
        {
            return loginType;
        }

        public void SetLoginType(string loginType)
        {
            this.loginType = loginType;
        }

        public bool Connect()
        {
            bool rt = false; 

            rt = mSmartFox2XClientDataObject.Connect();

            return rt;
        }

        //CallBack
        public void OnConnection(bool isConnect)
        {
            Debug.Log("OnConnect");

            if (isConnect)
            {
                Debug.Log("Connection established successfully");
            }
            else
            {
                Debug.Log("Connection failed; is the server running at all?");
            }

            //Three type Login Select
            switch(loginType)
            {
                default:
                    {
                        throw new NotImplementedException();
                    }
                    break;

                case "Quick":
                    {
                        SendNotification(Define.Command.Login_REQ_QuickLoginCommnad);
                    }
                    break;

                case "FB":
                    {
                        SendNotification(Define.Command.Login_REQ_FBLoginCommnad);
                    }
                    break;

                case "Token":
                    {
                        SendNotification(Define.Command.Login_REQ_TokenLoginCommand);
                    }
                    break;
            }         
        }

        public void OnConnectionLost(string reason)
        {
            Debug.Log("Connection was lost; reason is: " + reason);
        }

        public void Disconnect()
        {
            mSmartFox2XClientDataObject.Disconnect();
        }

        public void Login(string serverToken, string fbToken)
        {
            mSmartFox2XClientDataObject.Login(serverToken, fbToken);
        }

        public void OnLogin(string msg)
        {
            Debug.Log("OnLogin - msg: " + msg);
            Debug.Log("Login Type: " + loginType);

            //Three type Login Select
            switch (loginType)
            {
                default:
                    {
                        throw new NotImplementedException();
                    }
                    break;

                case "Quick":
                    {
                        SendNotification(Define.Command.Login_RESP_QuickLoginCommnad);
                    }
                    break;

                case "FB":
                    {
                        SendNotification(Define.Command.Login_RESP_FBLoginCommnad);
                    }
                    break;

                case "Token":
                    {
                        SendNotification(Define.Command.Login_RESP_TokenLoginCommand);
                    }
                    break;
            }
        }

        public void OnLoginError(string errorMessage)
        {
            Debug.Log("OnLoginError");

            // Disconnect
            mSmartFox2XClientDataObject.Disconnect();

            // Show error message
            Debug.Log("Login failed: " + errorMessage);
        }

        public void JoinRoom()
        {
            mSmartFox2XClientDataObject.JoinRoom();
        }

        public void OnRoomAdd()
        {
            Debug.Log("OnRoomAdd");
        }

        public void OnRoomJoin(string msg)
        {
            Debug.Log(msg);
        }

        public void OnRoomJoinError(string errorMsg)
        {
            Debug.Log("OnRoomJoinError");

            // Show error message
            Debug.Log("Room join failed: " + errorMsg);
        }

        public void OnRoomVariablesUpate()
        {
            Debug.Log("OnRoomVariablesUpate");
        }

        public void OnPublicMessage(string msg)
        {
            Debug.Log("OnPublicMessage");

            Debug.Log("PublicMessage: " + msg);
        }

        public void OnUserEnterRoom(string msg)
        {
            Debug.Log(msg);
        }

        public void OnUserExitRoom(string msg)
        {
            Debug.Log(msg);
        }












        #region Message
        public void OnInfoMessage(string msg)
        {
            Debug.Log(msg);
        }

        public void OnWarnMessage(string msg)
        {
            Debug.Log(msg);
        }

        public void OnErrorMessage(string msg)
        {
            Debug.Log(msg);
        }
        #endregion




        #region Send And Receive
        /// <summary>
        /// For Everyone use to send packet to Server
        /// Call by User
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="json"></param>
        public void PutSendExenteionRequestIntoQueue(string cmd, string json)
        {
            mSmartFox2XClientDataObject.PutSendExenteionRequestIntoQueue(cmd, json);
        }



        /// <summary>
        /// Auto Checke if SendExtensionRequestQueue needs get and send to server
        /// Call by Update
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="json"></param>
        public void AutoProcessSendExtensionRequestQueue()
        {
            mSmartFox2XClientDataObject.SendExtensionRequest();
        }

        /// <summary>
        /// Auto Checke if ReceiveExtensionRequestQueue needs get and send to server
        /// </summary>
        public void AutoProcessReceiveExtensionRequestQueue()
        {
            SmartFox2XClientDataObject.ReceiveExtensionPacketStruct mReceiveExtensionPacketStruct = new SmartFox2XClientDataObject.ReceiveExtensionPacketStruct();

            mReceiveExtensionPacketStruct = mSmartFox2XClientDataObject.GetRecieveExtentionRequestFromQueue();

            //Call Parser
            
        }
        #endregion
    }
}