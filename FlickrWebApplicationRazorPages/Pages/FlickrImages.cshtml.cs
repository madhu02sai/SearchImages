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
        public PhotosModel Photos { get; set; }

        public String Tag { get; set; }

        public List<String> urls { get; set; }

        public async Task OnGet(string tag)
        {
            Tag = tag;
            urls = new List<string>();

            Photos = await FlickrService.GetImagesByTag(tag);
            var allPhotos = Photos.Photos.Photo;

            foreach(var photo in allPhotos)
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
