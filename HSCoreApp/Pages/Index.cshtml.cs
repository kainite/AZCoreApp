using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using HSCoreApp.Models;
using Microsoft.Extensions.Caching.Memory;

namespace HSCoreApp.Pages
{
    public class IndexModel : PageModel
    {
        private IMemoryCache cache;
        private readonly ILogger<IndexModel> _logger;
        MovieActions action;

        public IEnumerable<Movie> Movieobj;
        public IndexModel(ILogger<IndexModel> logger,IMemoryCache cache)
        {
            this.cache = cache;
            _logger = logger;
            action = new MovieActions((List<Movie>)cache.Get("dtset"));
        }

        public void OnGet()
        {
            Movieobj = action.GetAllMovies();
        }
    }
}
