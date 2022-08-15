using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DesignPatternsRepo1.Pages
{
    public class RandomModel : PageModel
    {
        [BindProperty(SupportsGet =true)]
        public string Pattern { get; set; }
        public void OnGet()
        {
        }
    }
}
