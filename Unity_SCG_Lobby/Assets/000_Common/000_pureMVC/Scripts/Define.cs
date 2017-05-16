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
            //Init
            public const string Init_SettingDataProxy = "Init_SettingDataProxy";
            public const string Init_RESTFulTestProxy = "Init_RESTFulTestProxy";
            public const string Init_SmartFox2XClientProxy = "Init_SmartFox2XClientProxy";

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
            public const string Init_TestReadSettingFileCommnad = "Init_TestReadSettingFileCommnad";
            public const string Init_CheckSettingDataCommand = "Init_CheckSettingDataCommand";

            //Login
            public const string Login_FBLoginCommnad = "Login_FBLoginCommnad";
            public const string Login_FBLogoutCommnad = "Login_FBLogoutCommnad";
            public const string Login_InitCommnad = "Login_InitCommnad";
            public const string Login_QuickLoginCommnad = "Login_QuickLoginCommnad";
            //Lobby
        }
    }
}