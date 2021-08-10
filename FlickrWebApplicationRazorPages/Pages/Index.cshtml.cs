using FlickrWebApplicationRazorPages.Flickr;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlickrWebApplicationRazorPages.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        [BindProperty]
        public String Tag { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            ApiHelper.InitializeApiClient();
        }

        public async Task<IActionResult> OnPost()
        {
            //var Photos = await FlickrService.GetResponse(Tag);
            return Redirect("/FlickrImages?tag=" + Tag);
            //return RedirectToPage("FlickrImages");
            //Tag = "Dog";
            //return Page();
        }
    }
}
