using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FlickrWebApplicationRazorPages.Flickr
{
    public class FlickrPhotoService : IPhotoService<PhotosModel>
    {

        public async Task<PhotosModel> GetPhotosByTag(string tag)
        {
            int imagesCount = 24;
            string url = GenerateUrl(tag, imagesCount);
            HttpRequestMessage requestMessage = GenerateRequestMessage(url);

            using (HttpResponseMessage response = await ApiHelper.ApiClient.SendAsync(requestMessage))
            {
                if (response.IsSuccessStatusCode)
                {
                    PhotosModel photos = await response.Content.ReadAsAsync<PhotosModel>();
                    return photos;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        private HttpRequestMessage GenerateRequestMessage(string url)
        {
            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, url)
            {
                Content = new StringContent("", Encoding.UTF8, "application/json")
            };
            return requestMessage;
        }

        private string GenerateUrl(string tag, int imagesCount)
        {
            var apiKey = Environment.GetEnvironmentVariable("FlickrApiKey");
            return $"https://api.flickr.com/services/rest/?method=flickr.photos.search&api_key={apiKey}&tags=" +
                $"'{tag}'&format=json&nojsoncallback=1&per_page={imagesCount}&sort=interestingness-desc&privacy_filter=1";
        }
    }
}
