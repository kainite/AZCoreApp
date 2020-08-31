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
    public class DetailsModel : PageModel
    {
        public Movie obj;
        private IMemoryCache cache;
        public MovieActions action;
        public DetailsModel(IMemoryCache cache)
        {
            this.cache = cache;
            action = new MovieActions((List<Movie>)cache.Get("dtset"));
        }
        
        public IActionResult OnGet(int Id)
        {
            obj = action.GetMovie(Id);
            if (obj == null)
            {
                return RedirectToPage("./DetailsError");
            }
            return Page();
        }
    }
}