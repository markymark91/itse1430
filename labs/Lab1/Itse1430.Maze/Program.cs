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
            Console.WriteLine("You've entered Rapture, an underwater city situated at the bottom of the ocean. \nOnce a utopia for its citizens," +
               " Rapture has fallen into chaos, in part due to the \nmental instability that resulted from excessive gene-splicing. "+
               "Your goal is to escape Rapture. \nThere is a room with a bathysphere, which will carry you back to the surface.\n");
            Room1 ();
        }

        static void ChangeDirection(string answer) //use pointers
        {

        }

        static string GetCommand()
        {
            Console.WriteLine ("\nPlease enter a command. You may either enter 'move' followed by a direction, \n'turn' followed by either right, left, or around, or 'look' to get a description of where you are: ");
            s_command = Console.ReadLine ();
            s_command = s_command.ToLower();

            while (s_command != "turn left" && s_command!= "turn right" && s_command != "turn around" && s_command != "move forward" && s_command != "move backward" && s_command != "move left" && s_command != "move right" && s_command != "look")
            {
                Console.WriteLine ("Invalid input. You may either enter 'move' followed by a direction, \n'turn' followed by right, left, or around, or 'look' to get a description of where you are: ");
                s_command = Console.ReadLine ();
                s_command = s_command.ToLower ();
            }
            return s_command;
        }

        static string HandleCommand(string choice, string direction)
        {
           string holder;

            while (true)
            {
                switch (choice)
                {
                    case "look":
                        Console.WriteLine (direction);
                        break;
                    case "turn left":
                        holder = s_left;
                        s_left = s_backward;
                        s_backward = s_right;
                        s_right = s_forward;
                        s_forward = holder;
                        Console.WriteLine ($"\n {s_left} points west, {s_backward} points south, {s_right} points east, {s_forward} points north");
                        break;
                    case "turn right":
                        holder = s_right;
                        s_right = s_backward;
                        s_backward = s_left;
                        s_left = s_forward;
                        s_forward = holder;
                        Console.WriteLine ($"\n {s_left} points west, {s_backward} points south, {s_right} points east, {s_forward} points north");
                        break;
                    case "turn around":
                        holder = s_right;
                        s_right = s_left;
                        s_left = holder;
                        holder = s_forward;
                        s_forward = s_backward;
                        s_backward = holder;
                        Console.WriteLine ($"\n {s_left} points west, {s_backward} points south, {s_right} points east, {s_forward} points north");
                        break;
                    case "move left": 
                        return s_left;
                    case "move backward":
                        return s_backward;
                    case "move right":
                        return s_right;
                    case "move forward":
                        return s_forward;
                    default:
                        Console.WriteLine ("Invalid input");
                        break;
                }  
                choice = GetCommand ();
            }
        }

        static void Room1 ()
        {
            string description ="\nYou find yourself in the welcome lobby. Loose rubble is scattered across the flooded floor, \nwater leaking from cracked windows and busted pipes. \n";
                
            string direction = "\nYou are currently facing " + s_forward + ". There are pathways to your " + s_left + ", " + s_forward + ", and " + s_right +".\n";

            Console.WriteLine (description);
            
            string choice = GetCommand ();
            string answer = HandleCommand (choice, direction);
            if (answer == "left")     
            {
                ChangeDirection (answer);
                Room2 ();
            }
            else if (answer == "forward")
            {
                ChangeDirection(answer);
                Room4 ();
            }
            else if (answer == "right")
            {
                ChangeDirection(answer);
                Room8 ();
            }
            while (answer != "left" && answer != "forward" && answer != "right")
            {
                Console.WriteLine ("\nThat's a deadend! Please enter a valid input");
                choice = GetCommand ();
                answer = HandleCommand (choice, description);
                if (answer == "left")
                {
                    ChangeDirection(answer);
                    Room2 ();
                }
                else if (answer == "forward")
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
            Console.WriteLine ("You've entered room 2!");
            string description = "This is the description of this dank place.\nYou are facing " + s_forward +
                ". There are pathways to your " + s_left + ", " + s_forward + ", and " + s_right + ".\n";
            Console.WriteLine (description);
            string choice = GetCommand ();
            string answer = HandleCommand (choice, description);
            if (answer == "left")
            {
                ChangeDirection(answer);
                Room3 ();
            }
            else if (answer == "forward")
            {
                ChangeDirection(answer);
                Room6 ();
            }
            else if (answer == "right")
            {
                ChangeDirection(answer);
                Room1 ();
            }
            while (answer != "left" && answer != "forward" && answer != "right")
            {
                Console.WriteLine ("That's a deadend! Please enter a valid input");
                choice = GetCommand ();
                answer = HandleCommand (choice, description);
                if (answer == "left")
                {
                    ChangeDirection(answer);
                    Room3 ();
                }
                else if (answer == "forward")
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
            Console.WriteLine ("You've entered room 3!");
            string description = "This is the description of this dank place. \nYou are currently facing " + s_forward + 
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
            Console.WriteLine ("You've entered room 4!");
            string description = "This is the description of this dank place. \nYou are currently facing " + s_forward + 
                ". There are pathways to your " + s_backward + ", " + s_right + ", and " + s_forward + ".\n";
            Console.WriteLine (description);
            string choice = GetCommand ();
            string answer = HandleCommand (choice, description);
            if (answer == "right")
            {
                ChangeDirection(answer);
                Room9 ();
            }
            else if (answer == "backward")
            {
                ChangeDirection(answer);
                Room1 ();
            }
            else if (answer == "forward")
            {
                ChangeDirection(answer);
                Room5 ();
            }
            while (answer != "right" && answer != "backward" && answer != "forward")
            {
                Console.WriteLine ("That's a deadend! Please enter a valid input");
                choice = GetCommand ();
                answer = HandleCommand (choice, description);
                if (answer == "right")
                {
                    ChangeDirection(answer);
                    Room9 ();
                }
                else if (answer == "backward")
                {
                    ChangeDirection(answer);
                    Room1 ();
                }
                else if (answer == "forward")
                {
                    ChangeDirection(answer);
                    Room5 ();
                }
            }

        }
        static void Room5 ()//down 4, left 6, up 12, right 10
        {
            Console.WriteLine ("You've entered room 5!");
            string description = "This is the description of this dank place. \nYou are currently facing " + s_forward + 
                ". There are pathways to your " + s_backward + ", " + s_left + ", " + s_right + ", and " + s_forward + ".\n";
            Console.WriteLine (description);
            string choice = GetCommand ();
            string answer = HandleCommand (choice, description);
            if (answer == "right")
            {
                ChangeDirection(answer);
                Room10 ();
            }
            else if (answer == "backward")
            {
                ChangeDirection(answer);
                Room4 ();
            }
            else if (answer == "forward")
            {
                ChangeDirection(answer);
                Room12 ();
            }
            else if (answer == "left")
            {
                ChangeDirection(answer);
                Room6 ();
            }
            while (answer != "right" && answer != "backward" && answer != "forward" && answer != "left")
            {
                Console.WriteLine ("That's a deadend! Please enter a valid input");
                choice = GetCommand ();
                answer = HandleCommand (choice, description);
                if (answer == "right")
                {
                    ChangeDirection(answer);
                    Room10 ();
                }
                else if (answer == "backward")
                {
                    ChangeDirection(answer);
                    Room4 ();
                }
                else if (answer == "forward")
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
            string description = "This is the description of this dank place. \nYou are currently facing " + s_forward + 
                ". There are pathways to your " + s_backward + ", " + s_right + ", and " + s_forward + ".\n";
            Console.WriteLine (description);
            string choice = GetCommand ();
            string answer = HandleCommand (choice, description);
            if (answer == "right")
            {
                ChangeDirection(answer);
                Room5 ();
            }
            else if (answer == "backward")
            {
                ChangeDirection(answer);
                Room2 ();
            }
            else if (answer == "forward")
            {
                ChangeDirection(answer);
                Room7 ();
            }
            while (answer != "right" && answer != "backward" && answer != "forward")
            {
                Console.WriteLine ("That's a deadend! Please enter a valid input");
                choice = GetCommand ();
                answer = HandleCommand (choice, description);
                if (answer == "right")
                {
                    ChangeDirection(answer);
                    Room5 ();
                }
                else if (answer == "backward")
                {
                    ChangeDirection(answer);
                    Room2 ();
                }
                else if (answer == "forward")
                {
                    ChangeDirection(answer);
                    Room7 ();
                }
            }
        }
        static void Room7 ()//down 6, right 12
        {
            Console.WriteLine ("You've entered room 7!");
            string description = "This is the description of this dank place. \nYou are currently facing " + s_forward + 
                ". There are pathways to your " + s_backward + ", and " + s_right + ".\n";
            Console.WriteLine (description);
            string choice = GetCommand ();
            string answer = HandleCommand (choice, description);
            if (answer == "right")
            {
                ChangeDirection(answer);
                Room12 ();
            }
            else if (answer == "backward")
            {
                ChangeDirection(answer);
                Room6 ();
            }

            while (answer != "right" && answer != "backward")
            {
                Console.WriteLine ("That's a deadend! Please enter a valid input");
                choice = GetCommand ();
                answer = HandleCommand (choice, description);
                if (answer == "right")
                {
                    ChangeDirection(answer);
                    Room12 ();
                }
                else if (answer == "backward")
                {
                    ChangeDirection(answer);
                    Room6 ();
                }
            }
        }
        static void Room8 ()//left 1, up 9
        {
            Console.WriteLine ("You've entered room 8!");
            string description = "This is the description of this dank place. \nYou are currently facing " + s_forward + 
                ". There are pathways to your " + s_left + ", and " + s_forward + ".\n";
            Console.WriteLine (description);
            string choice = GetCommand ();
            string answer = HandleCommand (choice, description);
            if (answer == "left")
            {
                Room1 ();
            }
            else if (answer == "forward")
            {
                Room9 ();
            }

            while (answer != "left" && answer != "forward")
            {
                Console.WriteLine ("That's a deadend! Please enter a valid input");
                choice = GetCommand ();
                answer = HandleCommand (choice, description);
                if (answer == "left")
                {
                    Room1 ();
                }
                else if (answer == "forward")
                {
                    Room9 ();
                }
            }
        }
        static void Room9 ()//down 8, left 4, up 10
        {
            Console.WriteLine ("You've entered room 9!");
            string description = "This is the description of this dank place. \nYou are currently facing " + s_forward + 
                ". There are pathways to your " + s_backward + ", " + s_left + ", and " + s_forward + ".\n";
            Console.WriteLine (description);
            string choice = GetCommand ();
            string answer = HandleCommand (choice, description);
            if (answer == "left")
            {
                Room4 ();
            }
            else if (answer == "backward")
            {
                Room8 ();
            }
            else if (answer == "forward")
            {
                Room10 ();
            }
            while (answer != "left" && answer != "backward" && answer != "forward")
            {
                Console.WriteLine ("That's a deadend! Please enter a valid input");
                choice = GetCommand ();
                answer = HandleCommand (choice, description);
                if (answer == "left")
                {
                    Room4 ();
                }
                else if (answer == "backward")
                {
                    Room8 ();
                }
                else if (answer == "forward")
                {
                    Room10 ();
                }
            }
        }
        static void Room10 ()//down 9, left 5, up 11, right 13
        {
            Console.WriteLine ("You've entered room 10!");
            string description = "This is the description of this dank place. \nYou are currently facing " + s_forward + 
                ". There are pathways to your " + s_backward + ", " + s_left + ", " + s_right + ", and " + s_forward + ".\n";
            Console.WriteLine (description);
            string choice = GetCommand ();
            string answer = HandleCommand (choice, description);
            if (answer == "right")
            {
                Room13 ();
            }
            else if (answer == "backward")
            {
                Room9 ();
            }
            else if (answer == "forward")
            {
                Room11 ();
            }
            else if (answer == "left")
            {
                Room5 ();
            }
            while (answer != "right" && answer != "backward" && answer != "forward" && answer != "left")
            {
                Console.WriteLine ("That's a deadend! Please enter a valid input");
                choice = GetCommand ();
                answer = HandleCommand (choice, description);
                if (answer == "right")
                {
                    Room13 ();
                }
                else if (answer == "backward")
                {
                    Room9 ();
                }
                else if (answer == "forward")
                {
                    Room11 ();
                }
                else if (answer == "left")
                {
                    Room5 ();
                }
            }
        }
        static void Room11 ()//down 10, left 12, right 14
        {
            Console.WriteLine ("You've entered room 11!");
            string description = "This is the description of this dank place. \nYou are currently facing " + s_forward + 
                ". There are pathways to your " + s_backward + ", " + s_left + ", and " + s_right + ".\n";
            Console.WriteLine (description);
            string choice = GetCommand ();
            string answer = HandleCommand (choice, description);
            if (answer == "left")
            {
                Room12 ();
            }
            else if (answer == "backward")
            {
                Room10 ();
            }
            else if (answer == "right")
            {
                Room14 ();
            }
            while (answer != "left" && answer != "backward" && answer != "right")
            {
                Console.WriteLine ("That's a deadend! Please enter a valid input");
                choice = GetCommand ();
                answer = HandleCommand (choice, description);
                if (answer == "left")
                {
                    Room12 ();
                }
                else if (answer == "backward")
                {
                    Room10 ();
                }
                else if (answer == "right")
                {
                    Room14 ();
                }
            }
        }
        static void Room12 ()//down 5, left 7, right 11
        {
            Console.WriteLine ("You've entered room 12!");
            string description = "This is the description of this dank place. \nYou are currently facing " + s_forward + 
                ". There are pathways to your " + s_backward + ", " + s_left + ", and " + s_right + ".\n";
            Console.WriteLine (description);
            string choice = GetCommand ();
            string answer = HandleCommand (choice, description);
            if (answer == "left")
            {
                Room7 ();
            }
            else if (answer == "backward")
            {
                Room5 ();
            }
            else if (answer == "right")
            {
                Room11 ();
            }
            while (answer != "left" && answer != "backward" && answer != "right")
            {
                Console.WriteLine ("That's a deadend! Please enter a valid input");
                choice = GetCommand ();
                answer = HandleCommand (choice, description);
                if (answer == "left")
                {
                    Room7 ();
                }
                else if (answer == "backward")
                {
                    Room5 ();
                }
                else if (answer == "right")
                {
                    Room11 ();
                }
            }
        }
        static void Room13 ()//left 10, up 14, down 15
        {
            Console.WriteLine ("You've entered room 13!");
            string description = "This is the description of this dank place. \nYou are currently facing " + s_forward + 
                ". There are pathways to your " + s_backward + ", " + s_left + ", and " + s_forward + ".\n";
            Console.WriteLine (description);
            string choice = GetCommand ();
            string answer = HandleCommand (choice, description);
            if (answer == "left")
            {
                Room10 ();
            }
            else if (answer == "backward")
            {
                Room15 ();
            }
            else if (answer == "forward")
            {
                Room14 ();
            }
            while (answer != "left" && answer != "backward" && answer != "forward")
            {
                Console.WriteLine ("That's a deadend! Please enter a valid input");
                choice = GetCommand ();
                answer = HandleCommand (choice, description);
                if (answer == "left")
                {
                    Room10 ();
                }
                else if (answer == "backward")
                {
                    Room15 ();
                }
                else if (answer == "forward")
                {
                    Room14 ();
                }
            }
        }
        static void Room14 ()//left 11, down 13
        {
            Console.WriteLine ("You've entered room 14!");
            string description = "This is the description of this dank place. \nYou are currently facing " + s_forward + 
                ". There are pathways to your " + s_backward + ", and" + s_left + ".\n";
            Console.WriteLine (description);
            string choice = GetCommand ();
            string answer = HandleCommand (choice, description);
            if (answer == "left")
            {
                Room11 ();
            }
            else if (answer == "backward")
            {
                Room13 ();
            }
            
            while (answer != "left" && answer != "backward")
            {
                Console.WriteLine ("That's a deadend! Please enter a valid input");
                choice = GetCommand ();
                answer = HandleCommand (choice, description);
                if (answer == "left")
                {
                    Room11 ();
                }
                else if (answer == "backward")
                {
                    Room13 ();
                }
            }
        }
        static void Room15 ()//END
        {
            Console.WriteLine("Congratulation! You have reached the end! Hurray for bathysphere!");
        }
        
        static string s_command;
        static string s_forward = "forward";
        static string s_backward = "backward";
        static string s_right = "right";
        static string s_left = "left";
    }
}
