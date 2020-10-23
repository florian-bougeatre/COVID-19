using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace COVID_19.DAL
{
    public class ApiHelper
    {
        public static HttpClient ApiClient { get; set; }

        public static void InitializeClient()
        {
            ApiClient = new HttpClient();
            ApiClient.BaseAddress = new Uri("https://api.covid19api.com/");
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}