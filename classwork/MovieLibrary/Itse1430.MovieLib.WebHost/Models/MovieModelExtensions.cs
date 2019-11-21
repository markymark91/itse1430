using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Itse1430.MovieLib.WebHost.Models
{
    public static class MovieModelExtensions
    {
        public static MovieModel ToModel ( this Movie source )
        {
            if (source == null)
                return null;

            return new MovieModel () {
                Id = source.Id,
                Title = source.Title,
                Description = source.Description,
                HasSeen = source.HasSeen,
                Rating = source.Rating,
                ReleaseYear = source.ReleaseYear,
                RunLength = source.RunLength
            };
        }
    }
}