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

namespace InitNamespace
{
    public class SmartFox2XClientDataObject
    {
        public SmartFox2XClientDataObject()
        {

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
        private string SCG_Host = "192.168.122.97";       // Default host
        private string SCG_Zone = "brbingo";   // Default zone
        private string SCG_Room = "The Lobby";
        private int SCG_TcpPort = 9933;              // Default TCP port
        private int SCG_WsPort = 8888;               // Default WebSocket port
        #endregion



        #region Queue
        private object lockOfReceiveExtensionQueue = new object();
        private Queue<string> receiveExtensionQueue = new Queue<string>();

        private object lockOfSendExtensionQueue = new object();
        private Queue<string> sendExtensionQueue = new Queue<string>();
        #endregion


        public SmartFox GetSmartFox()
        {
            return smartFox;
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

        public void Connect()
        {
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
            }
            else
            {
                // DISCONNECT

                // Disconnect from SFS2X
                smartFox.Disconnect();
            }
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

            if ((bool)evt.Params["success"])
            {
                Debug.Log("Connection established successfully");
                Debug.Log("SFS2X API version: " + smartFox.Version);
                Debug.Log("Connection mode is: " + smartFox.ConnectionMode);


                Login();
            }
            else
            {
                Debug.Log("Connection failed; is the server running at all?");
            }
        }

        private void OnConnectionLost(BaseEvent evt)
        {
            Debug.Log("Connection was lost; reason is: " + (string)evt.Params["reason"]);

            // Remove SFS2X listeners and re-enable interface
            Disconnect();
        }

        //----------------------------------------------------------
        // SmartFoxServer log event listeners
        //----------------------------------------------------------

        public void OnInfoMessage(BaseEvent evt)
        {
            Debug.Log("OnInfoMessage");

            string message = (string)evt.Params["message"];
            ShowLogMessage("INFO", message);
        }

        public void OnWarnMessage(BaseEvent evt)
        {
            Debug.Log("OnWarnMessage");

            string message = (string)evt.Params["message"];
            ShowLogMessage("WARN", message);
        }

        public void OnErrorMessage(BaseEvent evt)
        {
            Debug.Log("OnErrorMessage");

            string message = (string)evt.Params["message"];
            ShowLogMessage("ERROR", message);
        }

        private void ShowLogMessage(string level, string message)
        {
            Debug.Log("ShowLogMessage");

            message = "[SFS > " + level + "] " + message;
            Debug.Log(message);
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


            // Join first Room in Zone
            if (smartFox.RoomList.Count > 0)
            {
                //smartFox.Send(new Sfs2X.Requests.JoinRoomRequest(smartFox.RoomList[0].Name));
                smartFox.Send(new Sfs2X.Requests.JoinRoomRequest(SCG_Room));
            }
        }

        private void OnLoginError(BaseEvent evt)
        {
            Debug.Log("OnLoginError");

            // Disconnect
            smartFox.Disconnect();

            // Remove SFS2X listeners and re-enable interface
            Disconnect();

            // Show error message
            Debug.Log("Login failed: " + (string)evt.Params["errorMessage"]);
        }

        private void OnRoomAdd(BaseEvent evt)
        {
            Debug.Log("OnRoomAdd");
        }

        private void OnRoomJoin(BaseEvent evt)
        {
            Debug.Log("OnRoomJoin");

            Room room = (Room)evt.Params["room"];

            // Show system message
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

            //Move to CandylandExtraBetController
            //Start
            //Debug.Log("User Name List: " + userNameListString);

            //SFSObject mSFSObject = SFSObject.NewInstance();

            //string data = string.Format("{\"type\":\"REQ_CA\",\"timestamp\":%d,\"status\":\"NONE\",\"typePL\":\"REQ_INIT\",\"payload\":\"%s\",\"isCompressed\":\"false\"}", DateTime.Now.Ticks, "{\\\"type\\\":\\\"REQ_INIT\\\",\\\"gameName\\\":\\\"candyland\\\"}");

            //mSFSObject.PutText("data", data);

            //smartFox.Send(new Sfs2X.Requests.ExtensionRequest("cmd.game", mSFSObject));
            //End
        }

        private void OnRoomJoinError(BaseEvent evt)
        {
            Debug.Log("OnRoomJoinError");

            // Show error message
            Debug.Log("Room join failed: " + (string)evt.Params["errorMessage"]);
        }

        private void OnRoomVariablesUpate(BaseEvent evt)
        {
            Debug.Log("OnRoomVariablesUpate");
        }

        private void OnPublicMessage(BaseEvent evt)
        {
            Debug.Log("OnPublicMessage");

            User sender = (User)evt.Params["sender"];
            string message = (string)evt.Params["message"];

            Debug.Log("PublicMessage: " + sender + ", " + message);
        }

        private void OnUserEnterRoom(BaseEvent evt)
        {
            Debug.Log("OnUserEnterRoom");

            User user = (User)evt.Params["user"];
            Room room = (Room)evt.Params["room"];

            // Show system message
            Debug.Log("User " + user.Name + " entered the room");

            // Populate users list
            string roomListString = string.Empty;
            foreach (Room room2 in smartFox.RoomList)
            {
                int roomId = room2.Id;
                roomListString += room2.Id.ToString() + ", ";
            }

            Debug.Log("roomList: " + roomListString);
        }

        private void OnUserExitRoom(BaseEvent evt)
        {
            Debug.Log("OnUserExitRoom");

            User user = (User)evt.Params["user"];

            if (user != smartFox.MySelf)
            {
                Room room = (Room)evt.Params["room"];

                // Show system message
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

                string cmd = (string)evt.Params["cmd"];
                ISFSObject respParams = (SFSObject)evt.Params["params"];

                Debug.Log("Current cmd:" + cmd);

                if (CMD_GP_GAME.Equals(cmd))
                {
                    Debug.Log("RespMsg: " + respParams.GetText("data"));
                }
                else if (CMD_GP_OTHER.Equals(cmd))
                {
                    Debug.Log("RespMsg: other test");
                }


                receiveExtensionQueue.Enqueue(respParams.GetText("data"));

                // ----------------------------------------------------------------------------------------------
                // 房間變數測試
                // ----------------------------------------------------------------------------------------------
                //RoomVariable rv = sfs.getLastJoinedRoom().getVariable("CandylandRoomSubject");
                //if (rv != null && !rv.isNull())
                //	logger.info("CandylandRoomSubject: " + rv.getValue().toString());
                //// ----------------------------------------------------------------------------------------------

                //this.gameDealing();
            }
        }

        public long GetExtensionPacketQueueLength()
        {
            return receiveExtensionQueue.Count;
        }

        public string GetExtensionPacket()
        {
            lock (lockOfReceiveExtensionQueue)
            {
                if (receiveExtensionQueue.Count > 0)
                {
                    return receiveExtensionQueue.Dequeue();
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        public void SendExtensionPacket(string cmd, SFSObject mSFSObject)
        {
            //For Test Candyland
            //SFSObject mSFSObject = SFSObject.NewInstance();
            ////string data = string.Format("{\"type\":\"REQ_CA\",\"timestamp\":%d,\"status\":\"NONE\",\"typePL\":\"REQ_INIT\",\"payload\":\"%s\",\"isCompressed\":\"false\"}", DateTime.Now.Ticks, "{\\\"type\\\":\\\"REQ_INIT\\\",\\\"gameName\\\":\\\"candyland\\\"}");
            //mSFSObject.PutText("data", jsonString);   
            //smartFox.Send(new Sfs2X.Requests.ExtensionRequest("cmd.game", mSFSObject));
            lock (lockOfSendExtensionQueue)
            {
                smartFox.Send(new Sfs2X.Requests.ExtensionRequest(cmd, mSFSObject));
            }
        }
        #endregion
    
    }
}

