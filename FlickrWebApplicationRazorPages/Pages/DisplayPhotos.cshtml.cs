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

        public List<string> urls { get; set; }

        private IContainer container = ContainerConfig.Configure();

        public async Task OnGet(string tag)
        {
            Tag = tag;
            if (urls == null)
            {
                urls = new List<string>();
            }

            using (var scope = container.BeginLifetimeScope())
            {
                var photoService = scope.Resolve<IPhotoService>();
                urls = await photoService.GetPhotosListByTag(tag);
            }
        }

    }
}
