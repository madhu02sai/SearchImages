﻿using System.Net.Http;
using System.Net.Http.Headers;

namespace FlickrWebApplicationRazorPages.Flickr
{
    public static class ApiHelper
    {
        public static HttpClient ApiClient { get; set; }

        public static void InitializeApiClient()
        {
            if (ApiClient == null)
            {
                ApiClient = new HttpClient();
                ApiClient.DefaultRequestHeaders.Accept.Clear();
                ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            }
        }
    }
}
