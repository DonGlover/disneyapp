using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using System.Json;
using System.Threading.Tasks;
using System.Net;
using System.IO;

using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;

using disneyapp.models;
using Newtonsoft.Json;

namespace disneyapp
{
    public class FetchAsync { 
        public async Task<JsonValue> CallWebService(string url)
        {
            // Create an HTTP web request using the URL:
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(new Uri(url));
            request.ContentType = "application/json";
            request.Method = "GET";

            // Send the request to the server and wait for the response:
            using (WebResponse response = await request.GetResponseAsync())
            {
                // Get a stream representation of the HTTP web response:
                using (Stream stream = response.GetResponseStream())
                {
                    // Use this stream to build a JSON document object:
                    JsonValue jsonDoc = await Task.Run(() => JsonValue.Load(stream));
                    // Return the JSON document:
                    return jsonDoc;
                }
            }
        }
    }
}