using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itse1430.MovieLib
{
    /// <summary> Represents movie data. </summary>
    public class Movie : IValidatableObject
    {
        public int Id { get; set; }
        /// <summary>Gets or sets the title of the movie.</summary>
        [RequiredAttribute(AllowEmptyStrings = false)]
        public string Title
        {
            get => _title ?? "";
            set => _title = value;
        }
        public string Description
        {
            get => _description ?? ""; 
            set => _description = value; 
        }
        [Required(AllowEmptyStrings = false)]
        public string Rating
        {
            get => _rating ?? ""; 
            set => _rating = value; 
        }

        [Display(Name = "Release Year")]
        [Range(1900, Int32.MaxValue, ErrorMessage = "Release year must be equal to or greater than 1900")]
        public int ReleaseYear { get; set; } = 1900; //Auto property
        /*
         * full property
        public int ReleaseYear
        {
            get { return _releaseYear; }
            set { _releaseYear = value; }
        }*/

        [RangeAttribute(0, Int32.MaxValue, ErrorMessage = "Run length must be equal to or greater than 0")]
        public int RunLength { get; set; }
        //{
        //    get { return _runLength; }
        //    set { _runLength = value; }
        //}
        public bool HasSeen { get; set; }
        //{
        //    get { return _hasSeen; }
        //    set { _hasSeen = value; }
        //}

        //value is 1939, read only, public
        //public const int ReleaseYearForColor { get; }= 1939;
        //constant field
        public const int ReleaseYearForColor = 1939;

        //public readonly int ReleaseYearForColor = 1939;

        //private readonly int _releaseYearForColor = 1939;
        //public bool IsBlackAndWhite
        //{
        //    get => ReleaseYear <= ReleaseYearForColor; 
        //    //set { }
        //}
        public bool IsBlackAndWhite
            => ReleaseYear <= ReleaseYearForColor;
            //set { }
        
        [Obsolete("Do not use", true)]
        public string TestAccessibility
        {
            get => ""; 
            private set { }
        }

        public override string ToString()
            => $"{Title} ({ReleaseYear})";


        //Fields - data to be stored
        //never make fields public
        private string _title = "";
        private string _description = "";
        //private int _releaseYear =1900;
        private string _rating = "";
        //private bool _hasSeen;
        //private int _runLength;

        /// <summary>Validates the movie.</summary>
        /// <returns>An error message if validation fails or empty string otherwise</returns>
        /*public string Validate()
        {
            //this is implicit first parameter, represents instance
            var title = "";
            //Name is required
            if (String.IsNullOrEmpty (this.Title))
                return "Name is required";
            //Release year >= 1900
            if (ReleaseYear < 1900)
                return "Release Year must be >= 1900";
            //Run length >= 0
            if (RunLength < 0)
                return "Run Length must be >=0";
            //Rating is required
            if (String.IsNullOrEmpty (Rating))
                return "Rating is required";

            return "";
        }*/

        public IEnumerable<ValidationResult> Validate ( ValidationContext validationContext )
        {
            return Enumerable.Empty<ValidationResult> ();
            //Rating is required
            /*if (String.IsNullOrEmpty (Rating))
                //results.Add(new ValidationResult( "Rating is required"));
                yield return new ValidationResult ("Rating is required");
            */

            //return results
        }
        //can new up other objects, however this wont have access to any of the cool stuff above
        //private Movie originalMovie = new Movie ();

    }
    //[AttributeUsage(AttributeTargets.)]
}
