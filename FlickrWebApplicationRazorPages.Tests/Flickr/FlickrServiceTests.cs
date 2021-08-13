using FlickrWebApplicationRazorPages.Flickr;
using Moq;
using Moq.Protected;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FlickrWebApplicationRazorPages.Tests.Flickr
{
    class FlickrServiceTests
    {
        private const string SendAsync = "SendAsync";

        [SetUp]
        public void Setup()
        {
            //ApiHelper.InitializeApiClient();
        }

        [Test]
        public async Task GetImagesByTag_WhenCalled_GivesCorrectResponseAsync()
        {
            String tag = "randomTag";
            String apiKey = "randomapiKey";
            StringBuilder content = new StringBuilder();
            content.Append("{\"photos\":{\"page\":1,\"pages\":172304,\"perpage\":10,\"total\":1723040,\"photo\":[{\"id\":\"51352778937\",\"owner\":\"40499097@N05\",\"secret\":\"1964531968\",\"server\":\"65535\",\"farm\":66,\"title\":\"Too Close - RAPS XT9537e\",\"ispublic\":1,\"isfriend\":0,\"isfamily\":0},{\"id\":\"51323623623\",\"owner\":\"11436011@N03\",\"secret\":\"f452f1c270\",\"server\":\"65535\",\"farm\":66,\"title\":\"Naima et John with cats and dust\",\"ispublic\":1,\"isfriend\":0,\"isfamily\":0},{\"id\":\"51294377321\",\"owner\":\"48646584@N00\",\"secret\":\"d078e6de59\",\"server\":\"65535\",\"farm\":66,\"title\":\"Munich - The Neighbours' Cat\",\"ispublic\":1,\"isfriend\":0,\"isfamily\":0},{\"id\":\"51276776092\",\"owner\":\"7156765@N05\",\"secret\":\"936c104979\",\"server\":\"65535\",\"farm\":66,\"title\":\"Scranton Pennsylvania  - The Radisson Lackawanna Station Hotel - Rooms  - Former Railroad Station\",\"ispublic\":1,\"isfriend\":0,\"isfamily\":0},{\"id\":\"51263793501\",\"owner\":\"8070463@N03\",\"secret\":\"67b0d5ee69\",\"server\":\"65535\",\"farm\":66,\"title\":\"A portrait of Louis looking proud\",\"ispublic\":1,\"isfriend\":0,\"isfamily\":0},{\"id\":\"51259662555\",\"owner\":\"91324182@N00\",\"secret\":\"f03fe544cb\",\"server\":\"65535\",\"farm\":66,\"title\":\"Heat plagued!\",\"ispublic\":1,\"isfriend\":0,\"isfamily\":0},{\"id\":\"51182841617\",\"owner\":\"185798515@N08\",\"secret\":\"58bdc983f6\",\"server\":\"65535\",\"farm\":66,\"title\":\"Hazel\",\"ispublic\":1,\"isfriend\":0,\"isfamily\":0},{\"id\":\"51181566039\",\"owner\":\"149999673@N08\",\"secret\":\"b6795ec849\",\"server\":\"65535\",\"farm\":66,\"title\":\"Mon chat et ma femme \u2764\ufe0f\",\"ispublic\":1,\"isfriend\":0,\"isfamily\":0},{\"id\":\"51159858618\",\"owner\":\"9854050@N06\",\"secret\":\"9de9f2cf32\",\"server\":\"65535\",\"farm\":66,\"title\":\"Crescuda del Ter a Camprodon (Ripoll\u00e8s)\",\"ispublic\":1,\"isfriend\":0,\"isfamily\":0},{\"id\":\"51176669817\",\"owner\":\"20879504@N05\",\"secret\":\"0f195e8da0\",\"server\":\"65535\",\"farm\":66,\"title\":\"Nap time\",\"ispublic\":1,\"isfriend\":0,\"isfamily\":0}]},\"stat\":\"ok\"}");

            // Create the response message
            HttpResponseMessage message = new HttpResponseMessage();
            message.StatusCode = System.Net.HttpStatusCode.OK;
            message.Content = new StringContent(content.ToString());
            message.Content.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");

            // Create the HttpClient Message Handler mock
            Mock<HttpMessageHandler> handlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            handlerMock
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    SendAsync,
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(message)
                .Verifiable();

            // Create the HttpClient Object to be used
            var httpClient = new HttpClient(handlerMock.Object);
            ApiHelper.ApiClient = httpClient;

            //Act
            Task<PhotosModel> Photos = new FlickrService().GetImagesByTag(tag);
            //Task<PhotosModel> Photos = imageServiceOrchestrator.GetImages(tag);
            PhotosModel Photos2 = await Photos;
            var allPhotos = Photos2.Photos.Photo;

            //Assertions
            handlerMock.Protected().Verify(
                    SendAsync,
                    Times.Exactly(1), // we expected a single request
                    ItExpr.Is<HttpRequestMessage>(req =>
                            req.Method == HttpMethod.Get  // we expected a GET request
                    ),
                    ItExpr.IsAny<CancellationToken>()
                );
            Assert.AreEqual(10, Photos2.Photos.Photo.Count());
            Assert.AreEqual("51352778937", Photos2.Photos.Photo[0].Id);
            Assert.AreEqual("1964531968", Photos2.Photos.Photo[0].Secret);
            Assert.AreEqual("65535", Photos2.Photos.Photo[0].Server);
        }
    }
}
