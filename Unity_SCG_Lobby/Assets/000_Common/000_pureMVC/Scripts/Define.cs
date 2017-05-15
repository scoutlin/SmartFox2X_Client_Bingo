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
            public const string InitNotify = "InitNotify";

            //Login
            public const string Login_FBLoginNotify = "Login_FBLoginNotify";

            //Lobby
        }

        public class Proxy
        {
            //Init
            public const string SettingDataProxy = "SettingDataProxy";
            public const string RESTFulTestProxy = "RESTFulTestProxy";
            public const string SmartFox2XClientProxy = "SmartFox2XClientProxy";

            //Login
            //public const string InitProxy = "Login.InitProxy";

            //Lobby
        }

        public class Mediator
        {
            //Init
            public const string InitTestMediator = "InitTestMediator";
            public const string InitMediator = "InitMediator";

            //Login
            public const string LoginMediator = "LoginMediator";

            //Lobby
            public const string LobbyMediator = "LobbyMediator";
        }

        public class Command
        {
            //Init
            public const string InitSimpleCommnad = "InitSimpleCommnad";
            public const string InitMacroCommand = "InitMacroCommand";
            public const string TestRESTFulCommand = "TestRESTFulCommand";
            public const string TestReadSettingFileCommnad = "TestReadSettingFileCommnad";

            //Login
            public const string FBLoginCommnad = "FBLoginCommnad";
            public const string FBLogoutCommnad = "FBLogoutCommnad";
            //Lobby
        }
    }
}