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
        //private readonly IConfiguration _config;

        //public FlickrImagesModel(IConfiguration config)
        //{
        //    _config = config;
        //}

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
            //var apiKey = _config["FlickrKey"];
            //var yolo = Environment.GetEnvironmentVariable("FlickrApiKey");
            //var lol = Environment.GetEnvironmentVariables();
            //var apiKey = "7c754b5ddc905b529d922a6e45fdf486";

            var container = ContainerConfig.Configure();
            Task<PhotosModel> Photos;
            using (var scope = container.BeginLifetimeScope())
            {
                var imageorch = scope.Resolve<ImageServiceBase<PhotosModel>>();
                Photos = imageorch.GetImagesByTag(tag);
            }

            //ImageServiceOrchstrator imageServiceOrchestrator = new ImageServiceOrchstrator(new FlickrService());
            //https://stackoverflow.com/questions/25174974/cast-a-taskt-to-a-t
            //Task<PhotosModel> Photos = imageServiceOrchestrator.GetImages(tag);
            PhotosModel Photos2 = await Photos;
            var allPhotos = Photos2.Photos.Photo;

            //PhotosModel PhotosResult = new FlickrService().GetImagesByTag(tag);
            //var allPhotos = PhotosResult.Photos.Photo;

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
