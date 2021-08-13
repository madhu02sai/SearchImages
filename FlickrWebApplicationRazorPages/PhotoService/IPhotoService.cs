using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlickrWebApplicationRazorPages.Flickr
{
    public interface IPhotoService
    {
        public Task<List<string>> GetPhotosListByTag(string tag);
    }
}