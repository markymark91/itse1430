using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itse1430.MovieLib
{
    /// <summary> Represents movie data. </summary>
    public class Movie
    {
        //Fields - data to be stored
        //never make fields public
        public string title = "";
        public string description = "";
        public int releaseYear =1900;
        public string rating = "";
        public bool hasSeen;
        public int runLength;

        //can new up other objects, however this wont have access to any of the cool stuff above
        //private Movie originalMovie = new Movie ();
    }
}
