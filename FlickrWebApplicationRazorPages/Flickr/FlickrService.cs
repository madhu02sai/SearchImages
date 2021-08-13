using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FlickrWebApplicationRazorPages.Flickr
{
    public class FlickrService : ImageServiceBase<PhotosModel>
    {

        public override async Task<PhotosModel> GetImagesByTag(string tag)
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

        private String GenerateUrl(string tag, int imagesCount)
        {
            var apiKey = Environment.GetEnvironmentVariable("FlickrApiKey");
            StringBuilder sb = new StringBuilder("https://api.flickr.com/services/rest/?method=flickr.photos.search&api_key=");
            sb.Append(apiKey);
            sb.Append("&tags=");
            sb.Append("'");
            sb.Append(tag);
            sb.Append("'");
            sb.Append("&format=json&nojsoncallback=1&per_page=");
            sb.Append(imagesCount);
            sb.Append("&sort=interestingness-desc&privacy_filter=1");
            return sb.ToString();
        }
    }
}
