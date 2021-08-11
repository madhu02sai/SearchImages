using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FlickrWebApplicationRazorPages.Flickr
{
    public static class FlickrService
    {
        public static async Task<PhotosModel> GetImagesByTag(String tag = "")
        {
            int imagesCount = 24;
            StringBuilder sb = new StringBuilder("https://api.flickr.com/services/rest/?method=flickr.photos.search&api_key=7c754b5ddc905b529d922a6e45fdf486&tags=");
            sb.Append("'");
            sb.Append(tag);
            sb.Append("'");
            sb.Append("&format=json&nojsoncallback=1&per_page=");
            sb.Append(imagesCount);
            sb.Append("&sort=interestingness-desc&privacy_filter=1");
            
            String url = sb.ToString();
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, url)
            {
                Content = new StringContent("", Encoding.UTF8, "application/json")
            };

            using (HttpResponseMessage response = await ApiHelper.ApiClient.SendAsync(requestMessage))
            {
                
                //HttpResponseMessage response2 = await ApiHelper.ApiClient.SendAsync(requestMessage);

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

    }
}
