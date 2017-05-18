using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CommonProtocolNamespace
{
    public class CommondProtocol
    {
        public class Common
        {
            public class Login
            {
                public const string CmdLoginQuick = "cmd.common.login.quick";
                public const string CmdLoginFB = "cmd.common.login.quick";
                public const string CmdLoginToken = "cmd.common.login.quick";
            }

            public class Initial
            {
                public const string CmdInitial = "cmd.common.initial";
            }
        }
    }
}