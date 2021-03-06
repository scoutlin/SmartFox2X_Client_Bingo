﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using System.Net;
using System.IO;
using System.Text;
using System.Collections.Specialized;

namespace InitNamespace
{
    public class RESTFulTestDataObject
    {
        public RESTFulTestDataObject()
        {

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
        public string WebClient_POST(string webSite, string field, string data)
        {
            using (var client = new WebClient())
            {
                var values = new NameValueCollection();
                values[field] = data;
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
            jsonReplyFromWebsite = WebClient_POST(webSite, "json", json);

            RESP_TestPOST_JOSN mRESP_TestPOST_JOSN = JsonUtility.FromJson<RESP_TestPOST_JOSN>(jsonReplyFromWebsite);

            return mRESP_TestPOST_JOSN;
        }
        #endregion



        public void TestRESTFul()
        {
            REQ_TestPOST_JOSN mREQ_TestPOST_JOSN = new REQ_TestPOST_JOSN();
            mREQ_TestPOST_JOSN.account = "Scott";
            mREQ_TestPOST_JOSN.password = "Fuck!!";

            RESP_TestPOST_JOSN mRESP_TestPOST_JOSN;
            mRESP_TestPOST_JOSN = TestPOST_JOSN("http://localhost:8081/scgTest", mREQ_TestPOST_JOSN);

            Debug.Log("RESP_TestPOST_JOSN: " + mRESP_TestPOST_JOSN.account + "/" + mRESP_TestPOST_JOSN.token);
        }
    }
}