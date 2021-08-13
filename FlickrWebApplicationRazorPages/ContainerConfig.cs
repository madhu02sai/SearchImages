using Autofac;
using FlickrWebApplicationRazorPages.Flickr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlickrWebApplicationRazorPages
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            //builder.RegisterType<ImageServiceOrchstrator>().As<IImageServiceOrchstrator<PhotosModel>>();
            //builder.RegisterType<FlickrService>().As<ImageServiceBase<PhotosModel>();
            builder.RegisterType(typeof(FlickrService)).As(typeof(ImageServiceBase<PhotosModel>));

            return builder.Build();
        }
    }
}
