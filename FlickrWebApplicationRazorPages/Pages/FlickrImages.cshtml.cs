using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using FlickrWebApplicationRazorPages.Flickr;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace FlickrWebApplicationRazorPages.Pages
{
    public class FlickrImagesModel : PageModel
    {
        public string Tag { get; set; }

        public List<string> urls { get; set; }

        private IContainer container = ContainerConfig.Configure();

        private Task<PhotosModel> PhotosModelResult;

        public async Task OnGet(string tag)
        {
            Tag = tag;
            if(urls == null)
            {
                urls = new List<string>();
            }

            using (var scope = container.BeginLifetimeScope())
            {
                var photoService = scope.Resolve<IPhotoService<PhotosModel>>();
                PhotosModelResult = photoService.GetPhotosByTag(tag);
            }

            //https://stackoverflow.com/questions/25174974/cast-a-taskt-to-a-t
            PhotosModel photosModel = await PhotosModelResult;
            var allPhotos = photosModel.Photos.Photo;

            foreach (var photo in allPhotos)
            {
                string url = GetPhotoUrl(photo);
                urls.Add(url);
            }
        }

        public string GetPhotoUrl(PhotoDetails photo)
        {
            return $"https://live.staticflickr.com/{photo.Server}/{photo.Id}_{photo.Secret}_q.jpg";
        }
    }
}
