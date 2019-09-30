using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCreator
{
    public class Character
    {
        public string Name
        {
            get { return _name ?? ""; }
            set { _name = value; }
        }
        public string Profession
        {
            get { return _profession ?? ""; }
            set { _profession = value; }
        }
        public string Race
        {
            get { return _race ?? ""; }
            set { _race = value; }
        }
        public string Description
        {
            get { return _description ?? ""; }
            set { _description = value; }
        }
        public int Strength { get; set; } = 50; //Auto property
        public int Dexterity { get; set; } = 50;
        public int Piety { get; set; } = 50;
        public int Vitality { get; set; } = 50;
        public int Intelligence { get; set; } = 50;

        public string TestAccessibility
        {
            get { return ""; }
            private set { }
        }

        //Fields - data to be stored
        //never make fields public
        private string _name = "";
        private string _profession = "";
        //private int _releaseYear =1900;
        private string _race = "";
        private string _description = "";
        //private bool _hasSeen;
        //private int _runLength;

        /// <summary>Validates the movie.</summary>
        /// <returns>An error message if validation fails or empty string otherwise</returns>
        public string Validate ()
        {
            //this is implicit first parameter, represents instance
            var name = "";
            //Name is required
            if (String.IsNullOrEmpty (this.Name))
                return "Name is required";
 
            if (Strength < 0 || Strength > 100)
                return "Strength must be a number between 0 and 100";
            if (Dexterity < 0 || Dexterity > 100)
                return "Strength must be a number between 0 and 100";
            if (Intelligence < 0 || Intelligence > 100)
                return "Strength must be a number between 0 and 100";
            if (Vitality < 0 || Vitality > 100)
                return "Strength must be a number between 0 and 100";
            if (Piety < 0 || Piety > 100)
                return "Strength must be a number between 0 and 100";
            //Rating is required
            if (String.IsNullOrEmpty (Race))
                return "Race is required";

            return "";
        }
        //can new up other objects, however this wont have access to any of the cool stuff above
        //private Movie originalMovie = new Movie ();
    }
}
