using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlickrWebApplicationRazorPages.Flickr
{
    public class PhotosModel
    {
        public PhotoModel Photos { get; set; }

        public static explicit operator PhotosModel(Task<PhotosModel> v)
        {
            throw new NotImplementedException();
        }
    }
}
