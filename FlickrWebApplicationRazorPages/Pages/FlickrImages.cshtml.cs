using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlickrWebApplicationRazorPages.Flickr;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FlickrWebApplicationRazorPages.Pages
{
    public class FlickrImagesModel : PageModel
    {
        public String Tag { get; set; }

        public List<String> urls { get; set; }

        public async Task OnGet(string tag)
        {
            Tag = tag;
            if(urls == null)
            {
                urls = new List<string>();
            }

            //ImageServiceOrchestrator imageServiceOrchestrator = new ImageServiceOrchestrator(new FlickrService(ApiHelper.ApiClient));
            ////https://stackoverflow.com/questions/25174974/cast-a-taskt-to-a-t
            //Task<PhotosModel> Photos = imageServiceOrchestrator.GetPhotos(tag);
            //PhotosModel Photos2 = await Photos;
            //var allPhotos = Photos2.Photos.Photo;

            PhotosModel Photos = await FlickrService.GetImagesByTag(tag);
            var allPhotos = Photos.Photos.Photo;

            foreach (var photo in allPhotos)
            {
                var url = GetPhotoUrl(photo);
                urls.Add(url);
            }
        }

        public String GetPhotoUrl(PhotoDetails photo)
        {
            return "https://live.staticflickr.com/" + photo.Server + "/" + photo.Id + "_" + photo.Secret + "_q.jpg";
        }
    }
}
