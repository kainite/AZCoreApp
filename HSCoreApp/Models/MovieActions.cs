using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HSCoreApp.Models
{
    
    public class MovieActions
    {
        
        List<Movie> Movieobj;

        public MovieActions(List<Movie> p_Movieobj)
        {            
            Movieobj= p_Movieobj;
        }

        public List<Movie> GetAllMovies()
        {
            return Movieobj;
        }

        public Movie GetMovie(int id)
        {
            return Movieobj.FirstOrDefault(c => c.Id == id);
        }

        public Movie UpdateMovie(Movie newobj)
        {
            Movie obj;
            obj = GetMovie(newobj.Id);
            if (obj != null)
            {
                obj.Name = newobj.Name;
                obj.Link = newobj.Link;                
            }
            return obj;
           }

        public void AddMovie(Movie p_obj)
        {
            List<Movie> l_obj = GetAllMovies();

            l_obj.Add(p_obj);
        }
    }
}
