namespace DefineNamespace
{
    public static class Define
    {
        public class Scene
        {
            //Init
            public const string InitScene = "InitScene";

            //Login
            public const string LoginSceneLoader = "LoginSceneLoader";

            //Lobby
            public const string LobbySceneLoader = "LobbySceneLoader";
        }

        public class Notification
        {
            //RESTFul

            //Init
            public const string Init_InitNotify = "Init_InitNotify";
            public const string Init_LoadLoginNotify = "Init_LoadLoginNotify";
            public const string Init_LoadLobbyNotify = "Init_LoadLobbyNotify";

            //Login
            public const string Login_NeedLoginNotify = "Login_NeedLoginNotify";
            public const string Login_NoNeedLoginNotify = "Login_NoNeedLoginNotify";
            public const string Login_QuickLoginCompleteNotify = "Login_QuickLoginCompleteNotify";
            public const string Login_FBLoginCompleteNotify = "Login_FBLoginCompleteNotify";
            public const string Login_DoLoginProcessNotify = "Login_DoLoginProcessNotify";
            
            //Lobby


        }

        public class Proxy
        {
            //Common
            public const string PlayerPrefsProxy = "PlayerPrefsProxy";
            public const string RESTFulProxy = "RESTFulProxy";
            public const string SmartFox2XClientProxy = "SmartFox2XClientProxy";
            public const string PersistentDataPathProxy = "PersistentDataPathProxy";
            public const string FBClientProxy = "FBClientProxy";

            //Init


            //Login
            //public const string Init_InitProxy = "Init_InitProxy";

            //Lobby
        }

        public class Mediator
        {
            //Init
            public const string Init_TestMediator = "Init_TestMediator";
            public const string Init_InitMediator = "Init_InitMediator";

            //Login
            public const string Login_LoginMediator = "Login_LoginMediator";

            //Lobby
            public const string Lobby_LobbyMediator = "Lobby_LobbyMediator";
        }

        public class Command
        {
            //Init
            public const string Init_SimpleCommnad = "Init_SimpleCommnad";
            public const string Init_MacroCommand = "Init_MacroCommand";
            public const string Init_TestRESTFulCommand = "Init_TestRESTFulCommand";
            public const string Init_TestPlayerPrefsCommnad = "Init_TestPlayerPrefsCommnad";
            public const string Init_TestPersistentDataPathCommand = "Init_TestPersistentDataPathCommand";
            public const string Init_CheckSettingDataCommand = "Init_CheckSettingDataCommand";
            

            //Login
            
            
            public const string Login_InitCommnad = "Login_InitCommnad";

            public const string Login_InitialSmartFox2XClientCommnad = "Login_InitialSmartFox2XClientCommnad";

            public const string Login_REQ_QuickLoginCommnad = "Login_REQ_QuickLoginCommnad";
            public const string Login_RESP_QuickLoginCommnad = "Login_RESP_QuickLoginCommnad";

            public const string Login_REQ_FBLoginCommnad = "Login_REQ_FBLoginCommnad";
            public const string Login_RESP_FBLoginCommnad = "Login_RESP_FBLoginCommnad";

            public const string Login_REQ_TokenLoginCommand = "Login_REQ_TokenLoginCommand";
            public const string Login_RESP_TokenLoginCommand = "Login_RESP_TokenLoginCommand";

            public const string Login_FBLogoutCommnad = "Login_FBLogoutCommnad";
            //Lobby
        }
    }
}