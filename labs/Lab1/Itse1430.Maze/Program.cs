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
        static void Main(string[] args)
        {
            Room1 ();
        }

        static void FacingDirection()
        {

        }
        static void ChangeDirection(string answer)
        {
           
        }

        static string GetCommand()
        {
            Console.WriteLine ("\nPlease enter a command. You may either enter 'move' followed by a direction, \n'turn' followed by a direction, or 'look' to get a description of where you are: ");
            s_command = Console.ReadLine ();
            s_command = s_command.ToLower();

            while (s_command != "turn left" && s_command!= "turn right" && s_command != "move up" && s_command != "move down" && s_command != "move left" && s_command != "move right" && s_command != "look")
            {
                Console.WriteLine ("Invalid input. You may either enter 'move' followed by a direction, \n'turn' followed by a direction, or 'look' to get a description of where you are: ");
                s_command = Console.ReadLine ();
                s_command = s_command.ToLower ();
            }
            return s_command;
        }

        static string HandleCommand(string choice, string description)
        {
           string holder;
           /* int left = (int)directions.left;
            int down = (int)directions.down;
            int right = (int)directions.right;
            int up = (int)directions.up;*/
            while (true)
            {
                switch (choice)
                {
                    case "look":
                        Console.WriteLine (description);
                        break;
                    case "turn left":
                        holder = s_left;
                        s_left = s_down;
                        s_down = s_right;
                        s_right = s_up;
                        s_up = holder;
                        Console.WriteLine ($"\n {s_left} points west, {s_down} points north, {s_right} points east, {s_up} points south");
                        break;
                    case "turn right":
                        holder = s_right;
                        s_right = s_down;
                        s_down = s_left;
                        s_left = s_up;
                        s_up = holder;
                        Console.WriteLine ($"\n {s_left} points west, {s_down} points north, {s_right} points east, {s_up} points south");
                        break;
                    case "move left": 
                        return s_left;
                    case "move down":
                        return s_down;
                    case "move right":
                        return s_right;
                    case "move up":
                        return s_up;
                    default:
                        Console.WriteLine ("Invalid input");
                        break;
                }  
                choice = GetCommand ();
            }
        }

        static void Room1 ()
        {
            /*string room2 = s_left;
            string room4 = s_up;
            string room8 = s_right;*/
            string description = "\nYou've entered Rapture, an underwater city situated at the bottom of the ocean. \nOnce a utopia for its citizens," +
                " Rapture has fallen into chaos, in part due to the \nmental instability that resulted from excessive gene-splicing. "+
                "Your goal is to escape Rapture. \nThere is a room with a bathysphere, which will carry you back to the surface."+
                "\nYou find yourself in the welcome lobby. Loose rubble is scattered across the flooded floor, \nwater leaking from cracked windows and busted pipes. " +
                "\n\nYou are currently facing " + s_up + ". There are pathways to your " + s_left + ", " + s_up + ", and " + s_right +".\n";

            Console.WriteLine (description);
            
            string choice = GetCommand ();
            string answer = HandleCommand (choice, description);
            if (answer == "left")
            {
                ChangeDirection (answer);
                Room2 ();
            }
            else if (answer == "up")
            {
                ChangeDirection(answer);
                Room4 ();
            }
            else if (answer == "right")
            {
                ChangeDirection(answer);
                Room8 ();
            }
            while (answer != "left" && answer != "up" && answer != "right")
            {
                Console.WriteLine ("\nThat's a deadend! Please enter a valid input");
                choice = GetCommand ();
                answer = HandleCommand (choice, description);
                if (answer == "left")
                {
                    ChangeDirection(answer);
                    Room2 ();
                }
                else if (answer == "up")
                {
                    ChangeDirection(answer);
                    Room4 ();
                }
                else if (answer == "right")
                {
                    ChangeDirection(answer);
                    Room8 ();
                }
            } 
        }
        static void Room2 () //left 3, up 6, right 1, down deadend
        {
            /*string room3 = s_left;
            string room6 = s_up;
            string room1 = s_right;*/
            Console.WriteLine ("You've entered room 2!");
            Console.WriteLine ($" left {s_left}");
            string description = "This is the description of this dank place.\nYou are facing " + s_up +
                ". There are pathways to your " + s_left + ", " + s_up + ", and " + s_right + ".\n";
            Console.WriteLine (description);
            string choice = GetCommand ();
            string answer = HandleCommand (choice, description);
            Console.WriteLine ($"\n left {s_left} answer {answer} right {s_right}");
            if (answer == "left")
            {
                ChangeDirection(answer);
                Room3 ();
            }
            else if (answer == "up")
            {
                ChangeDirection(answer);
                Room6 ();
            }
            else if (answer == "right")
            {
                ChangeDirection(answer);
                Room1 ();
            }
            while (answer != "left" && answer != "up" && answer != "right")
            {
                Console.WriteLine ("That's a deadend! Please enter a valid input");
                choice = GetCommand ();
                answer = HandleCommand (choice, description);
                if (answer == "left")
                {
                    ChangeDirection(answer);
                    Room3 ();
                }
                else if (answer == "up")
                {
                    ChangeDirection(answer);
                    Room6 ();
                }
                else if (answer == "right")
                {
                    ChangeDirection(answer);
                    Room1 ();
                }
            }
        }
        static void Room3 () // right 2, deadend else
        {
            //string room2 = s_right;
            Console.WriteLine ("You've entered room 3!");
            string description = "This is the description of this dank place. \nYou are currently facing " + s_up + 
                ". There are pathways to your " + s_right + ".\n";
            Console.WriteLine (description);
            string choice = GetCommand ();
            string answer = HandleCommand (choice, description);
            if (answer == "right")
            {
                ChangeDirection(answer);
                Room2 ();
            }
            while (answer != "right")
            {
                Console.WriteLine ("That's a deadend! Please enter a valid input");
                choice = GetCommand ();
                answer = HandleCommand (choice, description);
                if (answer == "right")
                {
                    ChangeDirection(answer);
                    Room2 ();
                }
            }
        }
        static void Room4 () //down 1, right 9, up 5, deadend else
        {
            /*string room9 = s_right;
            string room1 = s_down;
            string room5 = s_up;*/
            Console.WriteLine ("You've entered room 4!");
            string description = "This is the description of this dank place. \nYou are currently facing " + s_up + 
                ". There are pathways to your " + s_down + ", " + s_right + ", and " + s_up + ".\n";
            Console.WriteLine (description);
            string choice = GetCommand ();
            string answer = HandleCommand (choice, description);
            if (answer == "right")
            {
                ChangeDirection(answer);
                Room9 ();
            }
            else if (answer == "down")
            {
                ChangeDirection(answer);
                Room1 ();
            }
            else if (answer == "up")
            {
                ChangeDirection(answer);
                Room5 ();
            }
            while (answer != "right" && answer != "down" && answer != "up")
            {
                Console.WriteLine ("That's a deadend! Please enter a valid input");
                choice = GetCommand ();
                answer = HandleCommand (choice, description);
                if (answer == "right")
                {
                    ChangeDirection(answer);
                    Room9 ();
                }
                else if (answer == "down")
                {
                    ChangeDirection(answer);
                    Room1 ();
                }
                else if (answer == "up")
                {
                    ChangeDirection(answer);
                    Room5 ();
                }
            }

        }
        static void Room5 ()//down 4, left 6, up 12, right 10
        {
            Console.WriteLine ("You've entered room 5!");
            string description = "This is the description of this dank place. \nYou are currently facing " + s_up + 
                ". There are pathways to your " + s_down + ", " + s_left + ", " + s_right + ", and " + s_up + ".\n";
            Console.WriteLine (description);
            string choice = GetCommand ();
            string answer = HandleCommand (choice, description);
            if (answer == "right")
            {
                ChangeDirection(answer);
                Room10 ();
            }
            else if (answer == "down")
            {
                ChangeDirection(answer);
                Room4 ();
            }
            else if (answer == "up")
            {
                ChangeDirection(answer);
                Room12 ();
            }
            else if (answer == "left")
            {
                ChangeDirection(answer);
                Room6 ();
            }
            while (answer != "right" && answer != "down" && answer != "up" && answer != "left")
            {
                Console.WriteLine ("That's a deadend! Please enter a valid input");
                choice = GetCommand ();
                answer = HandleCommand (choice, description);
                if (answer == "right")
                {
                    ChangeDirection(answer);
                    Room10 ();
                }
                else if (answer == "down")
                {
                    ChangeDirection(answer);
                    Room4 ();
                }
                else if (answer == "up")
                {
                    ChangeDirection(answer);
                    Room12 ();
                }
                else if (answer == "left")
                {
                    ChangeDirection(answer);
                    Room6 ();
                }
            }
        }
        static void Room6 ()//down 2, right 5, up 7
        {
            Console.WriteLine ("You've entered room 6!");
            string description = "This is the description of this dank place. \nYou are currently facing " + s_up + 
                ". There are pathways to your " + s_down + ", " + s_right + ", and " + s_up + ".\n";
            Console.WriteLine (description);
            string choice = GetCommand ();
            string answer = HandleCommand (choice, description);
            if (answer == "right")
            {
                ChangeDirection(answer);
                Room5 ();
            }
            else if (answer == "down")
            {
                ChangeDirection(answer);
                Room2 ();
            }
            else if (answer == "up")
            {
                ChangeDirection(answer);
                Room7 ();
            }
            while (answer != "right" && answer != "down" && answer != "up")
            {
                Console.WriteLine ("That's a deadend! Please enter a valid input");
                choice = GetCommand ();
                answer = HandleCommand (choice, description);
                if (answer == "right")
                {
                    ChangeDirection(answer);
                    Room5 ();
                }
                else if (answer == "down")
                {
                    ChangeDirection(answer);
                    Room2 ();
                }
                else if (answer == "up")
                {
                    ChangeDirection(answer);
                    Room7 ();
                }
            }
        }
        static void Room7 ()//down 6, right 12
        {
            Console.WriteLine ("You've entered room 7!");
            string description = "This is the description of this dank place. \nYou are currently facing " + s_up + 
                ". There are pathways to your " + s_down + ", and " + s_right + ".\n";
            Console.WriteLine (description);
            string choice = GetCommand ();
            string answer = HandleCommand (choice, description);
            if (answer == "right")
            {
                ChangeDirection(answer);
                Room12 ();
            }
            else if (answer == "down")
            {
                ChangeDirection(answer);
                Room6 ();
            }

            while (answer != "right" && answer != "down")
            {
                Console.WriteLine ("That's a deadend! Please enter a valid input");
                choice = GetCommand ();
                answer = HandleCommand (choice, description);
                if (answer == "right")
                {
                    ChangeDirection(answer);
                    Room12 ();
                }
                else if (answer == "down")
                {
                    ChangeDirection(answer);
                    Room6 ();
                }
            }
        }
        static void Room8 ()//left 1, up 9
        {
            Console.WriteLine ("You've entered room 8!");
            string description = "This is the description of this dank place. \nYou are currently facing " + s_up + 
                ". There are pathways to your " + s_left + ", and " + s_up + ".\n";
            Console.WriteLine (description);
            string choice = GetCommand ();
            string answer = HandleCommand (choice, description);
            if (answer == "left")
            {
                ChangeDirection(answer);
                Room1 ();
            }
            else if (answer == "up")
            {
                ChangeDirection(answer);
                Room9 ();
            }

            while (answer != "left" && answer != "up")
            {
                Console.WriteLine ("That's a deadend! Please enter a valid input");
                Console.WriteLine ($"{choice}");
                choice = GetCommand ();
                Console.WriteLine ($"{choice}");
                answer = HandleCommand (choice, description);
                if (answer == "left")
                {
                    ChangeDirection(answer);
                    Room1 ();
                }
                else if (answer == "up")
                {
                    ChangeDirection(answer);
                    Room9 ();
                }
            }
        }
        static void Room9 ()//down 8, left 4, up 10
        {
            Console.WriteLine ("You've entered room 9!");
            string description = "This is the description of this dank place. \nYou are currently facing " + s_up + 
                ". There are pathways to your " + s_down + ", " + s_left + ", and " + s_up + ".\n";
            Console.WriteLine (description);
            string choice = GetCommand ();
            string answer = HandleCommand (choice, description);
            if (answer == "left")
            {
                ChangeDirection(answer);
                Room4 ();
            }
            else if (answer == "down")
            {
                ChangeDirection(answer);
                Room8 ();
            }
            else if (answer == "up")
            {
                ChangeDirection(answer);
                Room10 ();
            }
            while (answer != "left" && answer != "down" && answer != "up")
            {
                Console.WriteLine ("That's a deadend! Please enter a valid input");
                choice = GetCommand ();
                answer = HandleCommand (choice, description);
                if (answer == "left")
                {
                    ChangeDirection(answer);
                    Room4 ();
                }
                else if (answer == "down")
                {
                    ChangeDirection(answer);
                    Room8 ();
                }
                else if (answer == "up")
                {
                    ChangeDirection(answer);
                    Room10 ();
                }
            }
        }
        static void Room10 ()//down 9, left 5, up 11, right 13
        {
            Console.WriteLine ("You've entered room 10!");
            string description = "This is the description of this dank place. \nYou are currently facing " + s_up + 
                ". There are pathways to your " + s_down + ", " + s_left + ", " + s_right + ", and " + s_up + ".\n";
            Console.WriteLine (description);
            string choice = GetCommand ();
            string answer = HandleCommand (choice, description);
            if (answer == "right")
            {
                ChangeDirection(answer);
                Room13 ();
            }
            else if (answer == "down")
            {
                ChangeDirection(answer);
                Room9 ();
            }
            else if (answer == "up")
            {
                ChangeDirection(answer);
                Room11 ();
            }
            else if (answer == "left")
            {
                ChangeDirection(answer);
                Room5 ();
            }
            while (answer != "right" && answer != "down" && answer != "up" && answer != "left")
            {
                Console.WriteLine ("That's a deadend! Please enter a valid input");
                choice = GetCommand ();
                answer = HandleCommand (choice, description);
                if (answer == "right")
                {
                    ChangeDirection(answer);
                    Room13 ();
                }
                else if (answer == "down")
                {
                    ChangeDirection(answer);
                    Room9 ();
                }
                else if (answer == "up")
                {
                    ChangeDirection(answer);
                    Room11 ();
                }
                else if (answer == "left")
                {
                    ChangeDirection(answer);
                    Room5 ();
                }
            }
        }
        static void Room11 ()//down 10, left 12, right 14
        {
            Console.WriteLine ("You've entered room 11!");
            string description = "This is the description of this dank place. \nYou are currently facing " + s_up + 
                ". There are pathways to your " + s_down + ", " + s_left + ", and " + s_right + ".\n";
            Console.WriteLine (description);
            string choice = GetCommand ();
            string answer = HandleCommand (choice, description);
            if (answer == "left")
            {
                ChangeDirection(answer);
                Room12 ();
            }
            else if (answer == "down")
            {
                ChangeDirection(answer);
                Room10 ();
            }
            else if (answer == "right")
            {
                ChangeDirection(answer);
                Room14 ();
            }
            while (answer != "left" && answer != "down" && answer != "right")
            {
                Console.WriteLine ("That's a deadend! Please enter a valid input");
                choice = GetCommand ();
                answer = HandleCommand (choice, description);
                if (answer == "left")
                {
                    ChangeDirection(answer);
                    Room12 ();
                }
                else if (answer == "down")
                {
                    ChangeDirection(answer);
                    Room10 ();
                }
                else if (answer == "right")
                {
                    ChangeDirection(answer);
                    Room14 ();
                }
            }
        }
        static void Room12 ()//down 5, left 7, right 11
        {
            Console.WriteLine ("You've entered room 12!");
            string description = "This is the description of this dank place. \nYou are currently facing " + s_up + 
                ". There are pathways to your " + s_down + ", " + s_left + ", and " + s_right + ".\n";
            Console.WriteLine (description);
            string choice = GetCommand ();
            string answer = HandleCommand (choice, description);
            if (answer == "left")
            {
                ChangeDirection(answer);
                Room7 ();
            }
            else if (answer == "down")
            {
                ChangeDirection(answer);
                Room5 ();
            }
            else if (answer == "right")
            {
                ChangeDirection(answer);
                Room11 ();
            }
            while (answer != "left" && answer != "down" && answer != "right")
            {
                Console.WriteLine ("That's a deadend! Please enter a valid input");
                choice = GetCommand ();
                answer = HandleCommand (choice, description);
                if (answer == "left")
                {
                    ChangeDirection(answer);
                    Room7 ();
                }
                else if (answer == "down")
                {
                    ChangeDirection(answer);
                    Room5 ();
                }
                else if (answer == "right")
                {
                    ChangeDirection(answer);
                    Room11 ();
                }
            }
        }
        static void Room13 ()//left 10, up 14, down 15
        {
            Console.WriteLine ("You've entered room 13!");
            string description = "This is the description of this dank place. \nYou are currently facing " + s_up + 
                ". There are pathways to your " + s_down + ", " + s_left + ", and " + s_up + ".\n";
            Console.WriteLine (description);
            string choice = GetCommand ();
            string answer = HandleCommand (choice, description);
            if (answer == "left")
            {
                ChangeDirection(answer);
                Room10 ();
            }
            else if (answer == "down")
            {
                ChangeDirection(answer);
                Room15 ();
            }
            else if (answer == "up")
            {
                ChangeDirection(answer);
                Room14 ();
            }
            while (answer != "left" && answer != "down" && answer != "up")
            {
                Console.WriteLine ("That's a deadend! Please enter a valid input");
                choice = GetCommand ();
                answer = HandleCommand (choice, description);
                if (answer == "left")
                {
                    ChangeDirection(answer);
                    Room10 ();
                }
                else if (answer == "down")
                {
                    ChangeDirection(answer);
                    Room15 ();
                }
                else if (answer == "up")
                {
                    ChangeDirection(answer);
                    Room14 ();
                }
            }
        }
        static void Room14 ()//left 11, down 13
        {
            Console.WriteLine ("You've entered room 14!");
            string description = "This is the description of this dank place. \nYou are currently facing " + s_up + 
                ". There are pathways to your " + s_down + ", and" + s_left + ".\n";
            Console.WriteLine (description);
            string choice = GetCommand ();
            string answer = HandleCommand (choice, description);
            if (answer == "left")
            {
                ChangeDirection(answer);
                Room11 ();
            }
            else if (answer == "down")
            {
                ChangeDirection(answer);
                Room13 ();
            }
            
            while (answer != "left" && answer != "down")
            {
                Console.WriteLine ("That's a deadend! Please enter a valid input");
                choice = GetCommand ();
                answer = HandleCommand (choice, description);
                if (answer == "left")
                {
                    ChangeDirection(answer);
                    Room11 ();
                }
                else if (answer == "down")
                {
                    ChangeDirection(answer);
                    Room13 ();
                }
            }
        }
        static void Room15 ()//END
        {
            Console.WriteLine("Congratulation! You have reached the end! Hurray for bathysphere!");
        }
        
        static string s_command;
        static string s_up = "up";
        static string s_down = "down";
        static string s_right = "right";
        static string s_left = "left";
    }
}
/* static string HandleCommand(string choice, string description)
        {
           /* string holder;
            int left = (int)directions.left;
            int down = (int)directions.down;
            int right = (int)directions.right;
            int up = (int)directions.up;
Console.WriteLine($" {s_west} {s_south} {s_east} {s_north}");
            while (true)
            {
                switch (choice)
                {
                    case "look":
                        Console.WriteLine(description);
                        break;
                    case "turn left":
                        holder = left;
                        left = down;
                        down = right;
                        right = up;
                        up = holder;
                        Console.WriteLine($" {left} {down} {right} {up}");
                        break;
                    case "turn right":
                        holder = right;
                        right = down;
                        down = left;
                        left = up;
                        up = holder;
                        Console.WriteLine($" {left} {down} {right} {up}");
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
                        Console.WriteLine("Invalid input");
                        break;
                }  
                choice = GetCommand ();
            }
        }*/



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
