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
        [BindProperty]
        public string Tag { get; set; }

        public void OnGet()
        {
            ApiHelper.InitializeApiClient();
        }

        public async Task<IActionResult> OnPost()
        {
            return Redirect("/FlickrImages?tag=" + Tag);
        }
    }
}
