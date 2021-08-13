using Autofac;
using FlickrWebApplicationRazorPages.Flickr;

namespace FlickrWebApplicationRazorPages
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType(typeof(FlickrPhotoService)).As(typeof(IPhotoService));

            return builder.Build();
        }
    }
}
