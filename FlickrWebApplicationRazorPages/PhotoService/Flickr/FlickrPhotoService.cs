using System;
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
            string url = GenerateFlickrPhotoServiceUrl(tag);
            HttpRequestMessage requestMessage = GenerateRequestMessage(url);

            using (HttpResponseMessage response = await ApiHelper.ApiClient.SendAsync(requestMessage))
            {
                if (response.IsSuccessStatusCode)
                {
                    FlickrPhotosResult flickrPhotosResult = await response.Content.ReadAsAsync<FlickrPhotosResult>();
                    List<string> urls = new List<string>();
                    if (flickrPhotosResult.Code != null && flickrPhotosResult.Code == 100)
                    {
                        //urls.Add(flickrPhotosResult.Code);
                        urls.Add(flickrPhotosResult.Message);
                        return urls;
                    }
                    var allPhotos = flickrPhotosResult.Photos.Photo;

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

        private string GenerateFlickrPhotoServiceUrl(string tag)
        {
            var flickrApiKey = Environment.GetEnvironmentVariable("FlickrApiKey");
            flickrApiKey = "wrongKey";
            var photosCount = Environment.GetEnvironmentVariable("photosCount");
            return $"https://api.flickr.com/services/rest/?method=flickr.photos.search&api_key={flickrApiKey}&tags='{tag}'&format=json&nojsoncallback=1&per_page={photosCount}&sort=interestingness-desc&privacy_filter=1";
        }

    }
}
