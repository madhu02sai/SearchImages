using System.Collections.Generic;
using System.Threading.Tasks;
using Autofac;
using FlickrWebApplicationRazorPages.Flickr;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FlickrWebApplicationRazorPages.Pages
{
    public class DisplayPhotosModel : PageModel
    {
        public string Tag { get; set; }

        public List<string> Urls { get; set; }

        private readonly IContainer Container = ContainerConfig.Configure();

        public async Task OnGet(string tag)
        {
            Tag = tag;

            using (var scope = Container.BeginLifetimeScope())
            {
                var photoService = scope.Resolve<IPhotoService>();
                Urls = await photoService.GetPhotosListByTag(tag);
            }
        }

    }
}
