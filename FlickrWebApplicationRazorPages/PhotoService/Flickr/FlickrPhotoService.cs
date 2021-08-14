﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FlickrWebApplicationRazorPages.Flickr
{
    public class FlickrPhotoService : IPhotoService
    {
        public async Task<List<string>> GetPhotosListByTag(string tag)
        {
            int imagesCount = 28;
            string url = GenerateFlickrPhotoServiceUrl(tag, imagesCount);
            HttpRequestMessage requestMessage = GenerateRequestMessage(url);

            using (HttpResponseMessage response = await ApiHelper.ApiClient.SendAsync(requestMessage))
            {
                if (response.IsSuccessStatusCode)
                {
                    FlickrPhotosResult flickrPhotosResult = await response.Content.ReadAsAsync<FlickrPhotosResult>();
                    var allPhotos = flickrPhotosResult.Photos.Photo;

                    List<string> urls = new List<string>();
                    foreach (var photo in allPhotos)
                    {
                        string photoUrl = GeneratePhotoUrl(photo);
                        urls.Add(photoUrl);
                    }
                    return urls;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public string GeneratePhotoUrl(FlickrPhoto photo)
        {
            return $"https://live.staticflickr.com/{photo.Server}/{photo.Id}_{photo.Secret}_q.jpg";
        }

        private HttpRequestMessage GenerateRequestMessage(string url)
        {
            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, url)
            {
                Content = new StringContent("", Encoding.UTF8, "application/json")
            };
            return requestMessage;
        }

        private string GenerateFlickrPhotoServiceUrl(string tag, int imagesCount)
        {
            var apiKey = Environment.GetEnvironmentVariable("FlickrApiKey");
            return $"https://api.flickr.com/services/rest/?method=flickr.photos.search&api_key={apiKey}&tags='{tag}'&format=json&nojsoncallback=1&per_page={imagesCount}&sort=interestingness-desc&privacy_filter=1";
        }

    }
}
