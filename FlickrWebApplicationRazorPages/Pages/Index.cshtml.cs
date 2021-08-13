using FlickrWebApplicationRazorPages.Flickr;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

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

        public IActionResult OnPost()
        {
            return Redirect("/DisplayPhotos?tag=" + Tag);
        }
    }
}
