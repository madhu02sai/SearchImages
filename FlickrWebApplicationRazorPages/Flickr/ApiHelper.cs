using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace FlickrWebApplicationRazorPages.Flickr
{
    public static class ApiHelper
    {
        public static HttpClient ApiClient { get; set; }

        public static void InitializeApiClient()
        {
            if(ApiClient == null)
            {
                ApiClient = new HttpClient();
                ApiClient.DefaultRequestHeaders.Accept.Clear();
                ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            }
        }
    }
}
