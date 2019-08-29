/*
 * ITSE 1430
 * Lab 1
 * Mark Dobbins
 */


using System;

namespace HelloWorld
{
    class Program
    {
        static void Main ( string[] args )
        {
            //Movie data
            string title;
            int runLength;
            int releaseYear;
            string description;
            bool haveSeen;

            while (true)
            {
                char input = DisplayMenu ();
                if (input == 'A')
                {
                    AddMovie ();
                } else if (input == 'Q')
                {
                    break;
                }
            };
        }

        static void AddMovie()
        {
            //Get title
            Console.Write ("Title: ");
            string title = Console.ReadLine ();
            //Get description
            Console.Write ("Description: ");
            string description = Console.ReadLine ();
            //Get release year
            int releaseYear = ReadInt32 ("Release Year: ");
            //Get run length
            int runLength = ReadInt32 ("Run Length (in minutes): ");
            //Get have seen
            bool haveSeen = ReadBoolean ("Have Seen?: ");

        }

        static int ReadInt32(string message)
        {
            while (true)
            {
                Console.Write (message);
                string input = Console.ReadLine ();
                // int result = Int32.Parse (input);
                //int result;
                // if (Int32.TryParse (input, out result))
                if (Int32.TryParse (input, out int result))
                {
                    return result;
                }
                Console.WriteLine ("Not a number");
            }
        }
        static bool ReadBoolean( string message )
        {
            while (true)
            {
                Console.Write (message);
                string input = Console.ReadLine ();
                // int result = Int32.Parse (input);
                bool result;
                if (Boolean.TryParse (input, out result))
                {
                    return result;
                }
                Console.WriteLine ("Not a boolean");
            }
        }
        static char DisplayMenu ()
        {
            do
            {
                Console.WriteLine ("A)dd Movie");
                Console.WriteLine ("Q)uit");

                string input = Console.ReadLine ();
                if (input == "A" || input == "a")
                {
                    return 'A';
                } 
                else if (input == "Q" || input == "q")
                {
                    return 'Q';
                } 
                else
                {
                    Console.WriteLine ("Invalid input");
                }
            } while (true);
        }

        private static void DemoLanguage ()
        {
            string name = "";

            //string if = "";
            name = "Bob";
            string name2 = name;

            Console.WriteLine ("Hello World!");

            //Another block
            //Yet another block

            int hours = 8;
            double payRate = 15.25;

            double totalPay = payRate * hours;

            string fullName = "Fred" + " " + "Jones";
        }
    }
}
