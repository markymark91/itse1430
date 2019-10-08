/*
 * ITSE 1430
 * Lab 2
 * Mark Dobbins
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Character class contains the data for each instance of character the user creates
/// </summary>
namespace CharacterCreator
{
    public class Character
    {
        //Character's Name
        public string Name 
        {
            get { return _name ?? ""; }
            set { _name = value; }
        }

        //Character's Profession or Class
        public string Profession
        {
            get { return _profession ?? ""; }
            set { _profession = value; }
        }

        //Character's Race
        public string Race
        {
            get { return _race ?? ""; }
            set { _race = value; }
        }

        //Description of the character
        public string Description
        {
            get { return _description ?? ""; }
            set { _description = value; }
        }

        //These are the stats for each character. Set to 50 by default
        public int Strength { get; set; } = 50;
        public int Dexterity { get; set; } = 50;
        public int Piety { get; set; } = 50;
        public int Vitality { get; set; } = 50;
        public int Intelligence { get; set; } = 50;

        //This is what will appear in the roster; The character's Race, followed by Profession, followed by their Name
        public override string ToString ()
        {
            return $"{Race} {Profession} {Name}";
        }

        private string _name = "";
        private string _profession = "";
        private string _race = "";
        private string _description = "";


        /// <summary>Validates the character.</summary>
        /// <returns>An error message if validation fails or empty string otherwise</returns>
        public string Validate ()
        {
            //Name is required
            if (String.IsNullOrEmpty (Name))
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
            //Race is required
            if (String.IsNullOrEmpty (Race))
                return "Race is required";
            if (String.IsNullOrEmpty (Profession))
                return "Profession is required";

            return "";
        }
    }
}
