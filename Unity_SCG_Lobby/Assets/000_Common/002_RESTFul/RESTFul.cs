using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Text;  // for class Encoding
using UnityEngine;

namespace RESTFulNamespace
{

    public class RESTFul
    {
        public static RESTFul mRESTFul;

        public RESTFul()
        {

        }

        public static RESTFul GetInstance()
        {
            if (mRESTFul != null)
            {
                return mRESTFul;
            }
            else
            {
                mRESTFul = new RESTFul();
                return mRESTFul;
            }
        }

        /*
        //using System.Net.Http;
        //It is recommended to instantiate one HttpClient for your application's lifetime and share it.
        private static readonly HttpClient client = new HttpClient();
        //POST
        var values = new Dictionary<string, string>
        {
            { "thing1", "hello" },
            { "thing2", "world" }
        };

        var content = new FormUrlEncodedContent(values);

        var response = await client.PostAsync("http://www.example.com/recepticle.aspx", content);

        var responseString = await response.Content.ReadAsStringAsync();

        //GET
        var responseString = await client.GetStringAsync("http://www.example.com/recepticle.aspx");
        */

        //Method C: Legacy
        private string LegacyPOST_fuckWebServer(string toServer)
        {
            var request = (HttpWebRequest)WebRequest.Create("http://localhost:8081/scgTest");

            var postData = "thing1=hello";
            postData += "&thing2=world";
            var data = Encoding.ASCII.GetBytes(postData);

            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;

            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            var response = (HttpWebResponse)request.GetResponse();

            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

            return responseString;
        }

        //Method C: Legacy
        private void LegacyGET()
        {
            var request = (HttpWebRequest)WebRequest.Create("http://www.example.com/recepticle.aspx");

            var response = (HttpWebResponse)request.GetResponse();

            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
        }

        //POST WebClient (Also now legacy)
        private string WebClient_POST(string webSite, string json)
        {
            using (var client = new WebClient())
            {
                var values = new NameValueCollection();
                values["json"] = json;
                //values["thing2"] = "world";

                var response = client.UploadValues(webSite, values);
                var responseString = Encoding.Default.GetString(response);
                return responseString;
            }
        }


        //GET WebClient (Also now legacy)
        private string WebClient_GET(string webSite, string json)
        {
            using (var client = new WebClient())
            {
                var responseString = client.DownloadString(webSite);
            }

            return null;
        }

        #region Scott
        public class REQ_TestPOST_JOSN
        {
            public string account;
            public string password;
        }

        public class RESP_TestPOST_JOSN
        {
            public string account;
            public string token;
        }

        public RESP_TestPOST_JOSN TestPOST_JOSN(string webSite, REQ_TestPOST_JOSN mTestPOST_JOSN)
        {
            string json = JsonUtility.ToJson(mTestPOST_JOSN);
            string jsonReplyFromWebsite = string.Empty;
            jsonReplyFromWebsite = WebClient_POST(webSite, json);

            RESP_TestPOST_JOSN mRESP_TestPOST_JOSN = JsonUtility.FromJson<RESP_TestPOST_JOSN>(jsonReplyFromWebsite);

            return mRESP_TestPOST_JOSN;
        }
        #endregion

        #region Jumbo
        public void FuckWebServerByQL(string website, string account, string password, string action, string accessingToken)
        {




        }

        public void FuckWebServerByFB(string website, string account, string password, string action, string accessingToken)
        {




        }
        #endregion
    }
}
