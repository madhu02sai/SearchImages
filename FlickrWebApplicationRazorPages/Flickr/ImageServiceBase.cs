using System;
using System.Threading.Tasks;

namespace FlickrWebApplicationRazorPages.Flickr
{
    public abstract class ImageServiceBase<T>
    {
        public abstract Task<T> GetImagesByTag(string tag);

    }
}