using FlickrWebApplicationRazorPages.Flickr;
using FlickrWebApplicationRazorPages.Pages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlickrWebApplicationRazorPages.Tests.Pages
{
    class FlickrImagesTests
    {
        [Test]
        public async Task GetPhotoUrl_WhenCalled_GivesCorrectUrl()
        {
            //Arrange
            FlickrPhoto photo = new FlickrPhoto { Id = "49668662988", Secret = "f0dd701674", Server = "65535" };

            //Act
            String url = new FlickrImagesModel().GetPhotoUrl(photo);

            //Assert
            Assert.AreEqual("https://live.staticflickr.com/65535/49668662988_f0dd701674_q.jpg", url);
        }
    }
}
