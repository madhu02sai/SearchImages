using System;
using System.Threading.Tasks;

namespace FlickrWebApplicationRazorPages.Flickr
{
    public interface IPhotoService<T>
    {
        public Task<T> GetPhotosByTag(string tag);

    }
}