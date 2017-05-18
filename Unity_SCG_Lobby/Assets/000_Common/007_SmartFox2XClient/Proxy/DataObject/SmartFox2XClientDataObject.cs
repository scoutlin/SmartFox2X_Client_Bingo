using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Sfs2X;
using Sfs2X.Core;
using Sfs2X.Util;
using System;
using Sfs2X.Logging;
using Sfs2X.Entities.Data;
using Sfs2X.Entities;

namespace SmartFox2XClientNamespace
{
    public class SmartFox2XClientDataObject
    {
        private SmartFox2XClientProxy mSmartFox2XClientProxy;

        public class SendExtensionPacketStruct
        {
            public string cmd;
            public ISFSObject mSFSObject;
        }

        public class ReceiveExtensionPacketStruct
        {
            public string cmd;
            public string json;
        }


        public SmartFox2XClientDataObject()
        {

        }

        public void SetReference(SmartFox2XClientProxy mSmartFox2XClientProxy)
        {
            this.mSmartFox2XClientProxy = mSmartFox2XClientProxy;
        }

        private SmartFox smartFox;


        #region GameType
        private string gameType = "SCG";
        #endregion



        #region Candyland
        private string defaultHost = "192.168.122.97";   // Default host
        private string defaultZone = "brbingo";          // Default zone
        private int defaultTcpPort = 9933;               // Default TCP port
        private int defaultWsPort = 8888;                // Default WebSocket port

        private const string GAMENAME = "candyland";
        private const string KEY_GN = "gameName";
        private const string CMD_GP_GAME = "cmd.game";
        private const string CMD_GP_OTHER = "cmd.other";
        #endregion



        #region SCG
        private string SCG_Host = "localhost";       // Default host
        private string SCG_Zone = "brbingo";   // Default zone
        private string SCG_Room = "The Lobby";
        private int SCG_TcpPort = 9933;              // Default TCP port
        private int SCG_WsPort = 8888;               // Default WebSocket port
        #endregion



        #region Queue
        private object lockOfReceiveExtensionQueue = new object();
        private Queue<ReceiveExtensionPacketStruct> receiveExtensionQueue = new Queue<ReceiveExtensionPacketStruct>();

        private object lockOfSendExtensionQueue = new object();
        private Queue<SendExtensionPacketStruct> sendExtensionQueue = new Queue<SendExtensionPacketStruct>();

        
        #endregion


        public SmartFox GetSmartFox()
        {
            return smartFox;
        }

        public void ProcessEvents()
        {
            smartFox.ProcessEvents();
        }

        //Functions
        public void InitSmartFox()
        {
            // CONNECT
#if UNITY_WEBPLAYER
			// Socket policy prefetch can be done if the client-server communication is not encrypted only (read link provided in the note above)
			if (!Security.PrefetchSocketPolicy(hostInput.text, Convert.ToInt32(portInput.text), 500))
            {
			    Debug.LogError("Security Exception. Policy file loading failed!");
			}
#endif

            // Initialize SFS2X client and add listeners
            // WebGL build uses a different constructor
#if !UNITY_WEBGL
            smartFox = new SmartFox();
#else
			        sfs = new SmartFox(UseWebSocket.WS);
#endif
            // Set ThreadSafeMode explicitly, or Windows Store builds will get a wrong default value (false)
            smartFox.ThreadSafeMode = true;
        }

        public void RegistSmartFoxEvents()
        {
            //Connect
            smartFox.AddEventListener(SFSEvent.CONNECTION, OnConnection);
            smartFox.AddEventListener(SFSEvent.CONNECTION_LOST, OnConnectionLost);
            //System Message
            smartFox.AddLogListener(LogLevel.INFO, OnInfoMessage);
            smartFox.AddLogListener(LogLevel.WARN, OnWarnMessage);
            smartFox.AddLogListener(LogLevel.ERROR, OnErrorMessage);
            //Lobby
            smartFox.AddEventListener(SFSEvent.LOGIN, OnLogin);
            smartFox.AddEventListener(SFSEvent.LOGIN_ERROR, OnLoginError);
            smartFox.AddEventListener(SFSEvent.ROOM_ADD, OnRoomAdd);
            smartFox.AddEventListener(SFSEvent.ROOM_JOIN, OnRoomJoin);
            smartFox.AddEventListener(SFSEvent.ROOM_JOIN_ERROR, OnRoomJoinError);
            smartFox.AddEventListener(SFSEvent.ROOM_VARIABLES_UPDATE, OnRoomVariablesUpate);
            smartFox.AddEventListener(SFSEvent.PUBLIC_MESSAGE, OnPublicMessage);
            smartFox.AddEventListener(SFSEvent.USER_ENTER_ROOM, OnUserEnterRoom);
            smartFox.AddEventListener(SFSEvent.USER_EXIT_ROOM, OnUserExitRoom);
            smartFox.AddEventListener(SFSEvent.USER_COUNT_CHANGE, OnUserCountChange);
            smartFox.AddEventListener(SFSEvent.EXTENSION_RESPONSE, OnExtensionResponse);
        }

        public bool Connect()
        {
            bool rt = false;
            Debug.Log("Connect");

            if (smartFox == null || !smartFox.IsConnected)
            {
                // Set connection parameters
                ConfigData cfg = new ConfigData();

                cfg.Host = SCG_Host;

#if !UNITY_WEBGL
                cfg.Port = Convert.ToInt32(SCG_TcpPort);
#else
		        cfg.Port = Convert.ToInt32(SCG_WsPort);
#endif

                cfg.Zone = SCG_Zone;

                cfg.Debug = true;

                // Connect to SFS2X
                smartFox.Connect(cfg);

                rt = true;
            }
            else
            {
                // DISCONNECT

                // Disconnect from SFS2X
                smartFox.Disconnect();

                rt = false;
            }

            return rt;
        }


        public void Disconnect()
        {
            Debug.Log("Disconnect");

            // Remove SFS2X listeners
            //Connect
            smartFox.RemoveEventListener(SFSEvent.CONNECTION, OnConnection);
            smartFox.RemoveEventListener(SFSEvent.CONNECTION_LOST, OnConnectionLost);
            //System Message
            smartFox.RemoveLogListener(LogLevel.INFO, OnInfoMessage);
            smartFox.RemoveLogListener(LogLevel.WARN, OnWarnMessage);
            smartFox.RemoveLogListener(LogLevel.ERROR, OnErrorMessage);
            //Lobby
            smartFox.RemoveEventListener(SFSEvent.LOGIN, OnLogin);
            smartFox.RemoveEventListener(SFSEvent.LOGIN_ERROR, OnLoginError);
            smartFox.RemoveEventListener(SFSEvent.ROOM_JOIN, OnRoomJoin);
            smartFox.RemoveEventListener(SFSEvent.ROOM_JOIN_ERROR, OnRoomJoinError);
            smartFox.RemoveEventListener(SFSEvent.PUBLIC_MESSAGE, OnPublicMessage);
            smartFox.RemoveEventListener(SFSEvent.USER_ENTER_ROOM, OnUserEnterRoom);
            smartFox.RemoveEventListener(SFSEvent.USER_EXIT_ROOM, OnUserExitRoom);

            smartFox.Disconnect();

            smartFox = null;
        }

        //----------------------------------------------------------
        // SmartFoxServer event listeners
        //----------------------------------------------------------
        private void OnConnection(BaseEvent evt)
        {
            Debug.Log("OnConnect");
            bool isConnect = false;

            if ((bool)evt.Params["success"])
            {
                Debug.Log("Connection established successfully");
                Debug.Log("SFS2X API version: " + smartFox.Version);
                Debug.Log("Connection mode is: " + smartFox.ConnectionMode);

                isConnect = true;
            }
            else
            {
                Debug.Log("Connection failed; is the server running at all?");

                isConnect = false;
            }

            mSmartFox2XClientProxy.OnConnection(isConnect);
        }

        private void OnConnectionLost(BaseEvent evt)
        {
            string reason = (string)evt.Params["reason"];
            Disconnect();
            Debug.Log("Connection was lost; reason is: " + reason);

            mSmartFox2XClientProxy.OnConnectionLost(reason);
            // Remove SFS2X listeners and re-enable interface

        }

        //----------------------------------------------------------
        // SmartFoxServer log event listeners
        //----------------------------------------------------------

        public void OnInfoMessage(BaseEvent evt)
        {
            Debug.Log("OnInfoMessage");

            string message = (string)evt.Params["message"];
            ShowLogMessage("INFO", message);

            mSmartFox2XClientProxy.OnInfoMessage(message);
        }

        public void OnWarnMessage(BaseEvent evt)
        {
            Debug.Log("OnWarnMessage");

            string message = (string)evt.Params["message"];
            ShowLogMessage("WARN", message);

            mSmartFox2XClientProxy.OnWarnMessage(message);
        }

        public void OnErrorMessage(BaseEvent evt)
        {
            Debug.Log("OnErrorMessage");

            string message = (string)evt.Params["message"];
            ShowLogMessage("ERROR", message);

            mSmartFox2XClientProxy.OnErrorMessage(message);
        }

        private void ShowLogMessage(string level, string message)
        {
            Debug.Log("ShowLogMessage");

            message = "[SFS > " + level + "] " + message;
            Debug.Log(message);
        }

        #region Lobby
        public void Login()
        {
            Debug.Log("SFS Logining...");
            ISFSObject loginInData = SFSObject.NewInstance();
            loginInData.PutText(KEY_GN, GAMENAME);
            //smartFox.Send(new Sfs2X.Requests.LoginRequest("", "", smartFox.getCurrentZone(), loginInData));
            smartFox.Send(new Sfs2X.Requests.LoginRequest("", "", smartFox.CurrentZone, loginInData));
        }


        private void OnLogin(BaseEvent evt)
        {
            Debug.Log("OnLogin");

            User user = (User)evt.Params["user"];

            // Show system message
            string msg = "Connection established successfully\n";
            msg += "SFS2X API version: " + smartFox.Version + "\n";
            msg += "Connection mode is: " + smartFox.ConnectionMode + "\n";
            msg += "Logged in as " + user.Name;
            Debug.Log("System Message: " + msg);

            // Populate Room list
            // For the roomlist we use a scrollable area containing a separate prefab button for each Room
            // Buttons are clickable to join Rooms
            string roomListString = string.Empty;
            foreach (Room room in smartFox.RoomList)
            {
                int roomId = room.Id;
                roomListString += room.Id.ToString() + ", ";
            }

            Debug.Log("roomList: " + roomListString);

            mSmartFox2XClientProxy.OnLogin(msg);
        }


        private void OnLoginError(BaseEvent evt)
        {
            Debug.Log("OnLoginError");
            string errorMessage;
            // Disconnect
            smartFox.Disconnect();

            // Remove SFS2X listeners and re-enable interface
            Disconnect();

            // Show error message
            errorMessage = (string)evt.Params["errorMessage"];
            Debug.Log("Login failed: " + errorMessage);

            mSmartFox2XClientProxy.OnLoginError(errorMessage);
        }

        public void JoinRoom()
        {
            smartFox.Send(new Sfs2X.Requests.JoinRoomRequest(SCG_Room));
        }

        private void OnRoomAdd(BaseEvent evt)
        {
            Debug.Log("OnRoomAdd");
            mSmartFox2XClientProxy.OnRoomAdd();
        }

        private void OnRoomJoin(BaseEvent evt)
        {
            Debug.Log("OnRoomJoin");

            string msg;

            Room room = (Room)evt.Params["room"];

            // Show system message
            msg = "\nYou joined room '" + room.Name + "'\n";
            Debug.Log("\nYou joined room '" + room.Name + "'\n");

            // Populate users list
            // For the userlist we use a simple text area, with a user name in each row
            // No interaction is possible in this example

            // Get user names
            List<string> userNames = new List<string>();
            string userNameListString = string.Empty;

            foreach (User user in room.UserList)
            {
                if (user != smartFox.MySelf)
                {
                    userNames.Add(user.Name);
                    userNameListString += user.Name + ", ";
                }
            }

            mSmartFox2XClientProxy.OnRoomJoin(msg);
        }

        private void OnRoomJoinError(BaseEvent evt)
        {
            Debug.Log("OnRoomJoinError");

            string errorMsg;

            // Show error message
            errorMsg = (string)evt.Params["errorMessage"];
            Debug.Log("Room join failed: " + errorMsg);

            mSmartFox2XClientProxy.OnRoomJoinError(errorMsg);
        }

        private void OnRoomVariablesUpate(BaseEvent evt)
        {
            Debug.Log("OnRoomVariablesUpate");
            mSmartFox2XClientProxy.OnRoomVariablesUpate();
        }

        private void OnPublicMessage(BaseEvent evt)
        {
            Debug.Log("OnPublicMessage");

            string msg;

            User sender = (User)evt.Params["sender"];
            string message = (string)evt.Params["message"];

            msg = sender + (string)evt.Params["message"];

            Debug.Log("PublicMessage: " + sender + ", " + message);

            mSmartFox2XClientProxy.OnPublicMessage(msg);
        }

        private void OnUserEnterRoom(BaseEvent evt)
        {
            Debug.Log("OnUserEnterRoom");

            string msg;

            User user = (User)evt.Params["user"];
            Room room = (Room)evt.Params["room"];

            // Show system message
            msg = "User " + user.Name + " entered the room";
            Debug.Log("User " + user.Name + " entered the room");

            // Populate users list
            string roomListString = string.Empty;
            foreach (Room room2 in smartFox.RoomList)
            {
                int roomId = room2.Id;
                roomListString += room2.Id.ToString() + ", ";
            }

            msg += "roomList: " + roomListString;

            Debug.Log("roomList: " + roomListString);

            mSmartFox2XClientProxy.OnUserEnterRoom(msg);
        }

        private void OnUserExitRoom(BaseEvent evt)
        {
            Debug.Log("OnUserExitRoom");

            string msg = string.Empty;

            User user = (User)evt.Params["user"];


            if (user != smartFox.MySelf)
            {
                Room room = (Room)evt.Params["room"];

                // Show system message
                msg = "User " + user.Name + " left the room";
                Debug.Log("User " + user.Name + " left the room");

                // Populate users list
                // For the userlist we use a simple text area, with a user name in each row
                // No interaction is possible in this example

                // Get user names
                List<string> userNames = new List<string>();
                string userNameListString = string.Empty;

                foreach (User user2 in room.UserList)
                {
                    if (user2 != smartFox.MySelf)
                    {
                        userNames.Add(user2.Name);
                        userNameListString += user2.Name + ", ";
                    }
                }

                Debug.Log("User Name List: " + userNameListString);
            }

            mSmartFox2XClientProxy.OnUserExitRoom(msg);
        }

        private void OnUserCountChange(BaseEvent evt)
        {
            //An object representing the Room in which the users count changed.
            //Room room = (Room)evt.Params["room"];
            //The new users count(players in case of Game Room).
            //int uCount = (int)evt.Params["uCount"];
            //The new spectators count(Game Rooms only).
            //int sCount = (int)evt.Params["sCount"];
            Debug.Log("OnUserCountChange: " + evt.Params["uCount"]);
        }

        private void OnExtensionResponse(BaseEvent evt)
        {
            lock (lockOfReceiveExtensionQueue)
            {
                Debug.Log("OnExtensionResponse");

                ReceiveExtensionPacketStruct mExtensionPacketStruct = new ReceiveExtensionPacketStruct();
                string cmd = (string)evt.Params["cmd"];
                ISFSObject mSFSObject = (SFSObject)evt.Params["params"];

                mExtensionPacketStruct.cmd = cmd;
                mExtensionPacketStruct.json = mSFSObject.GetText("json");

                Debug.Log("Current cmd:" + cmd);

                if (CMD_GP_GAME.Equals(cmd))
                {
                    Debug.Log("RespMsg: " + mSFSObject.GetText("data"));
                }
                else if (CMD_GP_OTHER.Equals(cmd))
                {
                    Debug.Log("RespMsg: other test");
                }

                PutReceiveExtensionPacketIntoQueue(mExtensionPacketStruct);
            }
        }



        #region ReceiveQueue related
        public long GetReceiveExtensionQueueLength()
        {
            lock (lockOfReceiveExtensionQueue)
            {
                return receiveExtensionQueue.Count;
            }
        }

        public void PutReceiveExtensionPacketIntoQueue(ReceiveExtensionPacketStruct mSendPacketStruct)
        {
            lock (lockOfReceiveExtensionQueue)
            {
                receiveExtensionQueue.Enqueue(mSendPacketStruct);
            }
        }

        public ReceiveExtensionPacketStruct GetRecieveExtentionRequestFromQueue()
        {
            lock (lockOfReceiveExtensionQueue)
            {
                if (receiveExtensionQueue.Count > 0)
                {
                    return receiveExtensionQueue.Dequeue();
                }
                else
                {
                    return null;
                }
            }
        }
        #endregion

        #region SendQueueRelated
        public long GetSendExtensionQueueQueueLength()
        {
            lock (lockOfReceiveExtensionQueue)
            {
                return sendExtensionQueue.Count;
            }
        }

        public void PutSendExenteionRequestIntoQueue(string cmd, string json)
        {
            lock (lockOfSendExtensionQueue)
            {
                ISFSObject mSFSObject = new SFSObject();
                mSFSObject.PutText("data", json);

                SendExtensionPacketStruct mSendPacketStruct = new SendExtensionPacketStruct();
                mSendPacketStruct.cmd = cmd;
                mSendPacketStruct.mSFSObject = mSFSObject;

                sendExtensionQueue.Enqueue(mSendPacketStruct);
            }
        }

        public void SendExtensionRequest()
        {
            lock (lockOfSendExtensionQueue)
            {
                SendExtensionPacketStruct mSendPacketStruct = new SendExtensionPacketStruct();

                if (sendExtensionQueue.Count > 0)
                {
                    mSendPacketStruct = sendExtensionQueue.Dequeue();

                    smartFox.Send(new Sfs2X.Requests.ExtensionRequest(mSendPacketStruct.cmd,
                                                                      mSendPacketStruct.mSFSObject));
                }
            }
        }
        #endregion
        #endregion
    }
}
