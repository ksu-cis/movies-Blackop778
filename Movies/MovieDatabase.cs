using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace Movies
{
    /// <summary>
    /// A class representing a database of movies
    /// </summary>
    public static class MovieDatabase
    {
        private static List<Movie> movies;

        public static ReadOnlyCollection<Movie> All {
            get {
                if (movies == null)
                {
                    using (StreamReader file = File.OpenText("movies.json"))
                    {
                        string json = file.ReadToEnd();
                        movies = JsonConvert.DeserializeObject<List<Movie>>(json);
                    }
                }

                return movies.AsReadOnly();
            }
        }

        public static List<Movie> Search(IEnumerable<Movie> moviesArg, string toFind)
        {
            List<Movie> results = new List<Movie>();

            foreach (Movie m in moviesArg)
            {
                if (m.Title.Contains(toFind, StringComparison.OrdinalIgnoreCase) || (m.Director != null && m.Director.Contains(toFind, StringComparison.OrdinalIgnoreCase)))
                    results.Add(m);
            }

            return results;
        }

        public static List<Movie> FilterByMPAA(IEnumerable<Movie> moviesArg, List<string> mpaa_ratings)
        {
            List<Movie> results = new List<Movie>();

            foreach (Movie m in moviesArg)
            {
                if (m.MPAA_Rating != null && mpaa_ratings.Contains(m.MPAA_Rating))
                    results.Add(m);
            }

            return results;
        }

        public static List<Movie> FilterByMinIMDB(IEnumerable<Movie> moviesArg, float rating)
        {
            List<Movie> results = new List<Movie>();

            foreach (Movie m in moviesArg)
            {
                if (m.IMDB_Rating != null && m.IMDB_Rating >= rating)
                    results.Add(m);
            }

            return results;
        }
    }
}
