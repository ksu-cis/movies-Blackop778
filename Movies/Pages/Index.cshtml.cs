using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Movies.Pages
{
    public class IndexModel : PageModel
    {
        public IEnumerable<Movie> Movies { get; protected set; }

        [BindProperty]
        public string Search { get; set; }
        [BindProperty]
        public List<string> mpaa { get; set; } = new List<string>();

        [BindProperty]
        public float? minIMDB { get; set; } = null;

        public void OnGet()
        {
            Movies = MovieDatabase.All;
        }

        public void OnPost()
        {
            Movies = MovieDatabase.All;

            if (Search != null)
                Movies = MovieDatabase.Search(Movies, Search);

            if (mpaa.Count > 0)
                Movies = MovieDatabase.FilterByMPAA(Movies, mpaa);

            if (minIMDB is float nonNullMinIMDB)
                Movies = MovieDatabase.FilterByMinIMDB(Movies, nonNullMinIMDB);
        }
    }
}
