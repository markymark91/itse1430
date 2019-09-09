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

            var quit = false;
            while (!quit)
            {
                char input = DisplayMenu ();
                
                switch (input) //switches MUST end every single case statement with either a break or return
                {
                    //empty cases do fall through, can be useful 
                    //case 'a':
                    case 'A': AddMovie (); break;
                    case 'D': DisplayMovie (); break;
                    case 'R': RemoveMovie (); break;
                    case 'Q':
                    {
                        quit = true;
                        break;
                    }
                    default: Console.WriteLine("Not supported"); break;
                };
                /*if (input == 'A')
                {
                    AddMovie ();
                } 
                else if (input == 'D')
                {
                    DisplayMovie ();
                } 
                else if (input == 'R')
                {
                    RemoveMovie ();
                }
                else if (input == 'Q')
                {
                    break;
                }*/
            };
        }

        private static void RemoveMovie ()
        {
            //Confirm removal
            //Please don't do this expression == true, expression. Just use the expression
            if (!ReadBoolean ($"Are you sure you want to remove {title}? "))
            {
                return;
            }

            //Remove movie
            title = null;
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
            //Display message if no movies
            if(String.IsNullOrEmpty(title))
            {
                Console.WriteLine ("No movies");
                return;
            }

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

            //String.Compare("", "", StringComparison.)
            Console.WriteLine ("".PadLeft(50, '-'));
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
                Console.WriteLine ("R)emove Movie");
                Console.WriteLine ("Q)uit");

                string input = Console.ReadLine ();

                //lower case
                input = input.ToLower ();
                //if (input == "A" || input == "a")
                // if (input == "a")
                if (String.Compare (input, "a")==0)
                {
                    return 'A';
                } 
                else if (input == "q")
                {
                    return 'Q';
                } 
                else if (input == "d")
                    return 'D';
                else if (input == "r")
                    return 'R';
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

        static void DemoString()
        {
            string str = null;

            //checking for null or empty string
            if(str != null && str  != "")
                str = str.ToLower ();

            //Length - NO
            if (str != null && str.Length == 0)
                str = str.ToLower ();

            //Empty - NO
            if (str != null && str  != String.Empty)
                str = str.ToLower ();

            //Correct Approach
            if (!String.IsNullOrEmpty(str))
                str = str.ToLower ();
        }

        //DONT DO THIS OUTSIDE LAB ONE. GLOBAL VARIABLE ARE TABOO
        static string title;
        static string description;
        static int runLength;
        static int releaseYear;
        static bool hasSeen;
    }
}

/* Determine if 'input' is 'none'
 *  input == "none"
 *  String Compare(input, "none", true) == 0 //third variable is case sensitivity
 *  input.ToLower() == "none"
 *  
 * Create an array 'names' that stores 100 names
 *  string[] names = new string[100]
 * 
 * Set first value to 'sue'
 *  names[0] = "sue"
 *  
 * Enumerate values of 'grades'
 *  for(int x = 0; x < grades.length; ++x)
 *      grades[x]
 *      
 * Display 'You worked x hours', where 'hours' contains hours worked
 *  Console.WriteLine( "You worked " + hours + " hours");
 *  Console.WriteLine(String.Format( "You worked {0}", hours));
 *  Console.WriteLine($"You worked {hours} hours");
 *  Console.WriteLine("You worked {0} hours", hours);
 *  
 * Es.PadLeft, PadRight(int)
 */