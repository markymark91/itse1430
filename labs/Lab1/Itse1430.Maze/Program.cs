/*
 * ITSE 1430
 * Lab 1
 * Mark Dobbins
 */



using System;

namespace Itse1430.Maze
{
    
    class Program
    {
        enum directions { left, up, right, down };
        static void Main(string[] args)
        {
            Room1 ();
        }

        static string GetCommand()
        {
            Console.WriteLine ("\nPlease enter a command. You may either enter 'move' followed by a direction, \n'turn' followed by a direction, or 'look' to get a description of where you are: ");
            command = Console.ReadLine ();
            command = command.ToLower();

            while (command != "turn left" && command!= "turn right" && command != "move up" && command != "move down" && command != "move left" && command != "move right" && command != "look")
            {
                Console.WriteLine ("Invalid input. You may either enter 'move' followed by a direction, \n'turn' followed by a direction, or 'look' to get a description of where you are: ");
                command = Console.ReadLine ();
                command = command.ToLower ();
            }
            return command;
        }

        static int HandleCommand(string choice, string description)
        {
            int holder;
            int left = (int)directions.left;
            int down = (int)directions.down;
            int right = (int)directions.right;
            int up = (int)directions.up;
            Console.WriteLine($" {left} {down} {right} {up}");
            while (true)
            {
                switch (choice)
                {
                    case "look":
                        Console.WriteLine (description);
                        break;
                    case "turn left":
                        holder = left;
                        left = down;
                        down = right;
                        right = up;
                        up = holder;
                        Console.WriteLine ($" {left} {down} {right} {up}");
                        break;
                    case "turn right":
                        holder = right;
                        right = down;
                        down = left;
                        left = up;
                        up = holder;
                        Console.WriteLine ($" {left} {down} {right} {up}");
                        break;
                    case "move left":
                        return left;
                    case "move down":
                        return down;
                    case "move right":
                        return right;
                    case "move up":
                        return up;
                    default:
                        Console.WriteLine ("Invalid input");
                        break;
                }  
                choice = GetCommand ();
            }
            return 5;
        }

        static void Room1 ()
        {
            int room2 = (int)directions.left;
            int room4 = (int)directions.up;
            int room8 = (int)directions.right;
            int deadend = (int)directions.down;
            string description = "You've entered Rapture, an underwater city situated at the bottom of the ocean. \nOnce a utopia for its citizens," +
                " Rapture has fallen into chaos, in part due to the \nmental instability that resulted from excessive gene-splicing. "+
                "Your goal is to escape Rapture. \nThere is a room with a bathysphere, which will carry you back to the surface."+
                "\nYou find yourself in the welcome lobby. Loose rubble is scattered across the flooded floor, \nwater leaking from cracked windows and busted pipes. " +
                "\n\nThere are three pathways connected to this room; Left, Right, and Forward";

            Console.WriteLine (description);
            
            string choice = GetCommand ();
            int answer = HandleCommand (choice, description);
            if (answer == room2)
                Room2 ();
            if (answer == room4)
                Room4 ();
            if (answer == room8)
                Room8 ();
            while (answer == deadend)
            {
                Console.WriteLine ("That's a deadend! Please enter a valid input");
                answer = HandleCommand (choice, description);
                if (answer == room2)
                    Room2 ();
                if (answer == room4)
                    Room4 ();
                if (answer == room8)
                    Room8 ();
            }

           
        }
        static void Room2 ()
        {
            Console.WriteLine ("You've entered room 2!");
            string description = "This is the description of this dank place";
            Console.WriteLine (description);

        }
        static void Room3 ()
        {

        }
        static void Room4 ()
        {
            Console.WriteLine ("You've entered room 4!");
            string description = "This is the description of this dank place";
            Console.WriteLine (description);
        }
        static void Room5 ()
        {

        }
        static void Room6 ()
        {

        }
        static void Room7 ()
        {

        }
        static void Room8 ()
        {
            Console.WriteLine ("You've entered room 8!");
            string description = "This is the description of this dank place";
            Console.WriteLine (description);
        }
        static void Room9 ()
        {

        }
        static void Room10 ()
        {

        }
        static void Room11 ()
        {

        }
        static void Room12 ()
        {

        }
        static void Room13 ()
        {

        }
        static void Room14 ()
        {

        }
        static void Room15 ()
        {

        }
        static string command;
    }
}

/*
 * enum Command
        {
            Quit = 1,
            MoveForward,
            MoveBackward
        }

        static Command GetCommand()
        {
            //Get input from user
            Command command = ParseCommand (input);
            
            return Command.Quit;
        }

        static Command ParseCommand(string input)
        {
            while (true)
            {
                input = Console.ReadLine ();
                input = input.ToLower ();

            }

        }

        static Command HandleCommand()
        {
            Command command = GetCommand ();

            return command;
        }
*/
