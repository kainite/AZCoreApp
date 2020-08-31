using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HSCoreApp.Models;
using Microsoft.Extensions.Caching.Memory;

namespace HSCoreApp.Pages
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Movie obj { get; set; }
        MovieActions action;
        int count;
        private IMemoryCache cache;

        public CreateModel(IMemoryCache cache)
        {
            this.cache = cache;
            action = new MovieActions((List<Movie>)cache.Get("dtset"));
            count = (int)cache.Get("count");
        }
        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            count++;
            cache.Set("count", count);
            obj.Id = count;
            action.AddMovie(obj);
            return RedirectToPage("./Details", new { Id = obj.Id });
        }
    }
}