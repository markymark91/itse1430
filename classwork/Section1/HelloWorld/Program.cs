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
            /*string title;
            int runLength;
            int releaseYear;
            string description;
            bool haveSeen;*/

            while (true)
            {
                char input = DisplayMenu ();
                if (input == 'A')
                {
                    AddMovie ();
                } else if (input == 'D')
                {
                    DisplayMovie ();
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
             title = Console.ReadLine ();
            //Get description
            Console.Write ("Description: ");
             description = Console.ReadLine ();
            //Get release year
             releaseYear = ReadInt32 ("Release Year: ");
            //Get run length
             runLength = ReadInt32 ("Run Length (in minutes): ");
            //Get have seen
             hasSeen = ReadBoolean ("Have Seen?: ");

        }

        static void DisplayMovie()
        {
            //Title, description, release year, run length, hasSeen
            Console.WriteLine (title);
            Console.WriteLine (description);

            //Formatting strings
            //1) String concat
            Console.WriteLine ("Released " + releaseYear);

            //2) Printf
            // Console.WriteLine ("Run Time: {0}", runLength);

            //3) String formatting
            var formattedString = String.Format ("Run time: [0]", runLength);
            Console.WriteLine (formattedString);

            //4) String interpolation (best option maybe)
            //$" = interpolated string. changes how processor processes the string. can put almost any expression within {}
            //However, whatever is within {} HAS to be in there at compile time
            Console.WriteLine ($"Seen it? {hasSeen}");
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
                if (Int32.TryParse (input, out var result))
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
                Console.WriteLine ("D)isplay Movie");
                Console.WriteLine ("Q)uit");

                string input = Console.ReadLine ();

                //lower case
                input = input.ToLower ();
                //if (input == "A" || input == "a")
               // if (input == "a")
               if (String.Compare(input, "a")==0)
                {
                    return 'A';
                } else if (input == "q")
                    {
                    return 'Q';
                } else if (input == "d")
                            return 'D';
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
        static void DemoArray()
        {
            double[] payRates = new double[100];

            //50th element to 7.25
            payRates[49] = 7.25;

            //read 89th element into temp variable
            double payRate = payRates[88];

            //print out the 80th element
            Console.WriteLine (payRates[79]);

            //An empty array
            bool[] isPassing = new bool[0];

            //Enumerating an array. variableArrayName.Length gives length of the array
            for (int index = 0; index < payRates.Length; ++index)
                Console.WriteLine (payRates[index]);

            var name = "Bob William Smith Jr III"; //var stands for variable. name will be the type of variable depending on its contents
            string[] nameParts = name.Split (' ');
            //split is a function available to any string expression that 
            //splits the string into any set of characters. gives you an array of strings. Here, splits by space



        }

        //DONT DO THIS OUTSIDE LAB ONE. GLOBAL VARIABLE ARE TABOO
        static string title;
        static string description;
        static int runLength;
        static int releaseYear;
        static bool hasSeen;
    }
}
