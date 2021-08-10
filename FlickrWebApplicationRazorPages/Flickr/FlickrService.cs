using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace FlickrWebApplicationRazorPages.Flickr
{
    public static class FlickrService
    {
        public static async Task<PhotosModel> GetImagesByTag(String tag = "")
        {
            //String tag = "";
            //String.Format("https://api.flickr.com/services/rest/?method=flickr.photos.search&api_key=7c754b5ddc905b529d922a6e45fdf486&tags="+"'"+"cat"+"'"+"&format=json&nojsoncallback=1&per_page=10&sort=interestingness-desc&privacy_filter=1",tag);
            //url = "https://api.flickr.com/services/rest/?method=flickr.photos.search&api_key=7c754b5ddc905b529d922a6e45fdf486&tags={tag}&format=json&nojsoncallback=1&per_page=10&sort=interestingness-desc&privacy_filter=1";
            int imagesCount = 24;
            String url = "https://api.flickr.com/services/rest/?method=flickr.photos.search&api_key=7c754b5ddc905b529d922a6e45fdf486&tags=" + "'" + tag + "'" + "&format=json&nojsoncallback=1&per_page=" + imagesCount.ToString() + "&sort=interestingness-desc&privacy_filter=1";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    PhotosModel photos = await response.Content.ReadAsAsync<PhotosModel>();
                    //int numberOfPhotos = photos.Photos.Photo.Count();
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
