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
        static void Main ( string[] args ) //All main will do is print out a description for Rapture and call the first room function
        {
            Console.WriteLine ("You've entered Rapture, an underwater city situated at the bottom of the ocean. \nOnce a utopia for its citizens," +
               " Rapture has fallen into chaos, in part due to the \nmental instability that resulted from excessive gene-splicing. "+
               "Your goal is to escape Rapture. \nThere is a room with a bathysphere, which will carry you back to the surface.\n");
            Room1 ();
        }

        static string GetCommand () //Received the command from the user, checks to make sure it's one of the accepted commands, and passes it along
        {
            Console.Write ("\nPlease enter a command. You may either enter 'move' followed by a direction, \n'turn' followed by either right, left, or around, or 'look' to get a description of where you are: ");
            s_command = Console.ReadLine ();
            s_command = s_command.ToLower ();

            while (s_command != "turn left" && s_command!= "turn right" && s_command != "turn around" 
                && s_command != "move forward" && s_command != "move backward" && s_command != "move left" && s_command != "move right" 
                && s_command != "look" && s_command != "quit" && s_command != "")
            {
                Console.Write ("Invalid input. You may either enter 'move' followed by a direction, \n'turn' followed by right, left, or around, or 'look' to get a description of where you are: ");
                s_command = Console.ReadLine ();
                s_command = s_command.ToLower ();
            }
            return s_command;
        }

        static string HandleCommand ( string choice, int roomNumber ) //Performs several different functions based on the user's command
        {
            string holder;
            string exitHolder;
            string quitter;

            while (true)
            {
                switch (choice)
                {
                    case "":
                    break;
                    case "look": //Each room has a certain number of exits that are in certain directions. 
                                //These if statements tract what direction the user is facing and the direction of the exits respective of the user's direction
                    if (roomNumber == 1)
                        Console.WriteLine ("\nYou are currently facing " + s_forward + ". There are pathways are: " + s_exitLeft + ", " + s_exitForward + ", and " + s_exitRight + ".");
                    if (roomNumber == 2)
                        Console.WriteLine ("\nYou are currently facing " + s_forward + ". There are pathways are: " + s_exitLeft + ", " + s_exitForward + ", and " + s_exitRight + ".");
                    if (roomNumber == 3)
                        Console.WriteLine ("\nYou are currently facing " + s_forward + ". There are pathways are: " + s_exitRight + ".");
                    if (roomNumber == 4)
                        Console.WriteLine ("\nYou are currently facing " + s_forward + ". There are pathways are: " + s_exitBackward + ", " + s_exitForward + ", and " + s_exitRight + ".");
                    if (roomNumber == 5)
                        Console.WriteLine ("\nYou are currently facing " + s_forward + ". There are pathways are: " +s_exitBackward + ", " + s_exitLeft + ", " + s_exitForward + ", and " + s_exitRight + ".");
                    if (roomNumber == 6)
                        Console.WriteLine ("\nYou are currently facing " + s_forward + ". There are pathways are: " + s_exitBackward + ", " + s_exitForward + ", and " + s_exitRight + ".");
                    if (roomNumber == 7)
                        Console.WriteLine ("\nYou are currently facing " + s_forward + ". There are pathways are: " + s_exitBackward + ", and " + s_exitRight + ".");
                    if (roomNumber == 8)
                        Console.WriteLine ("\nYou are currently facing " + s_forward + ". There are pathways are: " + s_exitLeft + ", and " + s_exitForward + ".");
                    if (roomNumber == 9)
                        Console.WriteLine ("\nYou are currently facing " + s_forward + ". There are pathways are: " + s_exitLeft + ", " + s_exitForward + ", and " + s_exitBackward + ".");
                    if (roomNumber == 10)
                        Console.WriteLine ("\nYou are currently facing " + s_forward + ". There are pathways are: " + s_exitBackward + ", " + s_exitLeft + ", " + s_exitForward + ", and " + s_exitRight + ".");
                    if (roomNumber == 11)
                        Console.WriteLine ("\nYou are currently facing " + s_forward + ". There are pathways are: " + s_exitLeft + ", " + s_exitBackward + ", and " + s_exitRight + ".");
                    if (roomNumber == 12)
                        Console.WriteLine ("\nYou are currently facing " + s_forward + ". There are pathways are: " + s_exitLeft + ", " + s_exitBackward + ", and " + s_exitRight + ".");
                    if (roomNumber == 13)
                        Console.WriteLine ("\nYou are currently facing " + s_forward + ". There are pathways are: " + s_exitLeft + ", " + s_exitForward + ", and " + s_exitBackward + ".");
                    if (roomNumber == 14)
                        Console.WriteLine ("\nYou are currently facing " + s_forward + ". There are pathways are: " + s_exitLeft + ", and " + s_exitBackward + ".");
                    break;
                    case "turn left": //swaps the values of the user direction and exit direction variables to the left
                    holder = s_left;
                    s_left = s_backward;
                    s_backward = s_right;
                    s_right = s_forward;
                    s_forward = holder;
                    exitHolder = s_exitLeft;
                    s_exitLeft = s_exitForward;
                    s_exitForward = s_exitRight;
                    s_exitRight = s_exitBackward;
                    s_exitBackward = exitHolder;
                    Console.WriteLine ($"\nYou have turned left.");
                    break;
                    case "turn right": //swaps the values of the user direction and exit direction variables to the right
                    holder = s_right;
                    s_right = s_backward;
                    s_backward = s_left;
                    s_left = s_forward;
                    s_forward = holder;
                    exitHolder = s_exitLeft;
                    s_exitLeft = s_exitBackward;
                    s_exitBackward = s_exitRight;
                    s_exitRight = s_exitForward;
                    s_exitForward = exitHolder;
                    Console.WriteLine ($"\nYou have turned right.");
                    break;
                    case "turn around": //swaps the values of the user direction and exit direction variables, left with right and forward with backward
                    holder = s_right;
                    s_right = s_left;
                    s_left = holder;
                    holder = s_forward;
                    s_forward = s_backward;
                    s_backward = holder;
                    exitHolder = s_exitLeft;
                    s_exitLeft = s_exitRight;
                    s_exitRight = exitHolder;
                    exitHolder = s_exitForward;
                    s_exitForward = s_exitBackward;
                    s_exitBackward = exitHolder;
                    Console.WriteLine ($"\nYou have turned around.");
                    break;
                    case "move left":
                    return s_left;
                    case "move backward":
                    return s_backward;
                    case "move right":
                    return s_right;
                    case "move forward":
                    return s_forward;
                    case "quit": //below is the quit switch that allows the user to exit the program
                    Console.Write ("\nAre you sure you want to quit? Yes/No: ");
                    quitter = Console.ReadLine ();
                    quitter = quitter.ToLower ();
                    if (quitter == "yes")
                        Environment.Exit (0);
                    if (quitter == "no")
                        break;
                    while (quitter != "yes" && quitter != "no")
                    {
                        Console.Write ("Invalid input. Please enter either 'yes' or 'no': ");
                        quitter = Console.ReadLine ();
                        quitter = quitter.ToLower ();
                    }
                    break;
                    default:
                    Console.WriteLine ("Invalid input");
                    break;
                }
                choice = GetCommand ();
            }
        }

        static void Room1 ()
        {
            //every room has its own room number and description
            int roomNumber = 1;
            string description = "\nYou find yourself in the Lounge. This room connects the Bathysphere Station with " +
                "\nthe rest of rapture. People would rest before or after their travels to and from Rapture. \nLoose rubble is scattered across the flooded floor, \nwater leaking from cracked windows and busted pipes. \n" +
                "\nYou are currently facing " + s_forward + ". There are pathways to your " + s_left + ", " + s_forward + ", and " + s_right +".\n";

            Console.WriteLine (description);

            string choice = GetCommand (); //gets the command
            string answer = HandleCommand (choice, roomNumber); //passes the command and room number to the command handle function

            //the only exits available for this room are left, forward, and right
            if (answer == "left")
                Room2 ();
            else if (answer == "forward")
                Room4 ();
            else if (answer == "right")
                Room8 ();

            while (answer != "left" && answer != "forward" && answer != "right") //If the user tries to input a direction that has no adjoining room
            {
                Console.WriteLine ("\nThat's a deadend! Please enter a valid input");
                Console.WriteLine (description);
                choice = GetCommand ();
                answer = HandleCommand (choice, roomNumber);
                if (answer == "left")
                    Room2 ();
                else if (answer == "forward")
                    Room4 ();
                else if (answer == "right")
                    Room8 ();
            }
        }
        static void Room2 () //left 3, up 6, right 1, down deadend
        {
            int roomNumber = 2;
            Console.WriteLine ("You've entered room 2!\n");
            string description = "\nThe Medical Pavilion has many advertisements for Steinman's surgery operations and" +
                " other services in Rapture. \nThis place was once operated by Doctor Steinman, and is now ruled by him." +
                "\nThe walls are covered in messaged painted in the blood of his former patients and those foolish enough to oppose him.\n";
            
            Console.WriteLine (description);
            string choice = GetCommand ();
            string answer = HandleCommand (choice, roomNumber);

            if (answer == "left")
                Room3 ();
            else if (answer == "forward")
                Room6 ();
            else if (answer == "right")
                Room1 ();

            while (answer != "left" && answer != "forward" && answer != "right")
            {
                Console.WriteLine ("That's a deadend! Please enter a valid input");
                Console.WriteLine (description);
                choice = GetCommand ();
                answer = HandleCommand (choice, roomNumber);
                if (answer == "left")
                    Room3 ();
                else if (answer == "forward")
                    Room6 ();
                else if (answer == "right")
                    Room1 ();
            }
        }
        static void Room3 () // right 2, deadend else
        {
            int roomNumber = 3;
            Console.WriteLine ("You've entered room 3!");
            string description = "\nThe Metro Station, once a bustling and lively area, now vacant save for some rats." +
                "\nconvicted criminals were publicly displayed to dismay any who would distrupt the peace." +
                "\nThe Metro Station isn't operational, and so the only way to go is back.\n"; 
            Console.WriteLine (description);
            string choice = GetCommand ();
            string answer = HandleCommand (choice, roomNumber);
            if (answer == "right")
                Room2 ();
            
            while (answer != "right")
            {
                Console.WriteLine ("That's a deadend! Please enter a valid input");
                Console.WriteLine (description);
                choice = GetCommand ();
                answer = HandleCommand (choice, roomNumber);
                if (answer == "right")
                    Room2 ();
            }
        }
        static void Room4 () //down 1, right 9, up 5, deadend else
        {
            int roomNumber = 4;
            Console.WriteLine ("\nYou've entered room 4!");
            string description = "\nDue to the collapse of the city, you've discovered the Smuggler's Hideout." +
                "\nThis is where the smugglers and criminals did their business: alcohol, tobacco, beef, even bibles." +
                "\nThe hideout is connected to several areas, allowing greater freedom for their operations.\n";
            Console.WriteLine (description);
            string choice = GetCommand ();
            string answer = HandleCommand (choice, roomNumber);
            if (answer == "right")
                Room9 ();
            else if (answer == "backward")
                Room1 ();
            else if (answer == "forward")
                Room5 ();

            while (answer != "right" && answer != "backward" && answer != "forward")
            {
                Console.Write ("\nThat's a deadend! Please enter a valid input: ");
                Console.WriteLine (description);
                choice = GetCommand ();
                answer = HandleCommand (choice, roomNumber);
                if (answer == "right")
                    Room9 ();
                else if (answer == "backward")
                    Room1 ();
                else if (answer == "forward")
                    Room5 ();
            }

        }
        static void Room5 ()//down 4, left 6, up 12, right 10
        {
            int roomNumber = 5;
            Console.WriteLine ("\nYou've entered room 5!");
            string description = "\nArcadia is the oxygen supplier of Rapture." +
                "\nFull of forests and other plant life, this location was excellent for those seeking refuge." +
                "\nFarms and markets that were once as full of life as the environment are now torched and burned to the ground.\n"; 
            Console.WriteLine (description);
            string choice = GetCommand ();
            string answer = HandleCommand (choice, roomNumber);
            if (answer == "right")
                Room10 ();
            else if (answer == "backward")
                Room4 ();
            else if (answer == "forward")
                Room12 ();
            else if (answer == "left")
                Room6 ();

            while (answer != "right" && answer != "backward" && answer != "forward" && answer != "left")
            {
                Console.Write ("\nThat's a deadend! Please enter a valid input: ");
                Console.WriteLine (description);
                choice = GetCommand ();
                answer = HandleCommand (choice, roomNumber);
                if (answer == "right")
                    Room10 ();
                else if (answer == "backward")
                    Room4 ();
                else if (answer == "forward")
                    Room12 ();
                else if (answer == "left")
                    Room6 ();
            }
        }
        static void Room6 ()//down 2, right 5, up 7
        {
            int roomNumber = 6;
            Console.WriteLine ("\nYou've entered room 6!");
            string description = "\nWorley Winery has been ransacked of all its wine." +
                "\nEmpty wine racks, barrels, and bottles liter the floor. " +
                "\nThe distillery below ground has been destroyed.\n";
            Console.WriteLine (description);
            string choice = GetCommand ();
            string answer = HandleCommand (choice, roomNumber);
            if (answer == "right")
                Room5 ();
            else if (answer == "backward")
                Room2 ();
            else if (answer == "forward")
                Room7 ();

            while (answer != "right" && answer != "backward" && answer != "forward")
            {
                Console.Write ("\nThat's a deadend! Please enter a valid input: ");
                Console.WriteLine (description);
                choice = GetCommand ();
                answer = HandleCommand (choice, roomNumber);
                if (answer == "right")
                    Room5 ();
                else if (answer == "backward")
                    Room2 ();
                else if (answer == "forward")
                    Room7 ();
            }
        }
        static void Room7 ()//down 6, right 12
        {
            int roomNumber = 7;
            Console.WriteLine ("\nYou've entered room 7!");
            string description = "\nFort Frolic was where Rapture's citizens came to relax and unwind." +
                "\nA plethora of avenues for film, music, gambling, and strip clubs were available to those who could afford it." +
                "\nNow this place is full of twisted and macabre works, signifying the peoples' decent into madness.\n"; 
            Console.WriteLine (description);
            string choice = GetCommand ();
            string answer = HandleCommand (choice, roomNumber);
            if (answer == "right")
                Room12 ();
            else if (answer == "backward")
                Room6 ();

            while (answer != "right" && answer != "backward")
            {
                Console.Write ("\nThat's a deadend! Please enter a valid input: ");
                Console.WriteLine (description);
                choice = GetCommand ();
                answer = HandleCommand (choice, roomNumber);
                if (answer == "right")
                    Room12 ();
                else if (answer == "backward")
                    Room6 ();
            }
        }
        static void Room8 ()//left 1, up 9
        {
            int roomNumber = 8;
            Console.WriteLine ("\nYou've entered room 8!");
            string description = "\nHephaestus is the power facility for Rapture. Using volcanic vents, Rapture had limitless power." +
                "\nOnce the deline of Rapture began, the facility would be frequently assaulted by those wanting the power for themselves." +
                "\nHephaestus is populated with the bodies of those who once worked within its walls.\n"; 
            Console.WriteLine (description);
            string choice = GetCommand ();
            string answer = HandleCommand (choice, roomNumber);
            if (answer == "left")
                Room1 ();
            else if (answer == "forward")
                Room9 ();

            while (answer != "left" && answer != "forward")
            {
                Console.Write ("\nThat's a deadend! Please enter a valid input: ");
                Console.WriteLine (description);
                choice = GetCommand ();
                answer = HandleCommand (choice, roomNumber);
                if (answer == "left")
                    Room1 ();
                else if (answer == "forward")
                    Room9 ();
            }
        }
        static void Room9 ()//down 8, left 4, up 10
        {
            int roomNumber = 9;
            Console.WriteLine ("\nYou've entered room 9!");
            string description = "\nThis is the Rapture Central Control station" +
                "\nThis fortress was unbreachable during the attacks on Hephaestus," +
                "\nand is the most untouched location in all of Rapture\n.";
            Console.WriteLine (description);
            string choice = GetCommand ();
            string answer = HandleCommand (choice, roomNumber);
            if (answer == "left")
                Room4 ();
            else if (answer == "backward")
                Room8 ();
            else if (answer == "forward")
                Room10 ();

            while (answer != "left" && answer != "backward" && answer != "forward")
            {
                Console.Write ("\nThat's a deadend! Please enter a valid input: ");
                Console.WriteLine (description);
                choice = GetCommand ();
                answer = HandleCommand (choice, roomNumber);
                if (answer == "left")
                    Room4 ();
                else if (answer == "backward")
                    Room8 ();
                else if (answer == "forward")
                    Room10 ();
            }
        }
        static void Room10 ()//down 9, left 5, up 11, right 13
        {
            int roomNumber = 10;
            Console.WriteLine ("\nYou've entered room 10!");
            string description = "\nOlympus Heights was where the upper class once lived." +
                "\nThe once beautiful district has been all but destroyed, glass and rubble covering the walkways." +
                "\nMercury Suites is the only accessible location within the district, " +
                "\nas the other complexes have been reduced to ash."; 
            Console.WriteLine (description);
            string choice = GetCommand ();
            string answer = HandleCommand (choice, roomNumber);
            if (answer == "right")
                Room13 ();
            else if (answer == "backward")
                Room9 ();
            else if (answer == "forward")
                Room11 ();
            else if (answer == "left")
                Room5 ();

            while (answer != "right" && answer != "backward" && answer != "forward" && answer != "left")
            {
                Console.Write ("\nThat's a deadend! Please enter a valid input: ");
                Console.WriteLine (description);
                choice = GetCommand ();
                answer = HandleCommand (choice, roomNumber);
                if (answer == "right")
                    Room13 ();
                else if (answer == "backward")
                    Room9 ();
                else if (answer == "forward")
                    Room11 ();
                else if (answer == "left")
                    Room5 ();
            }
        }
        static void Room11 ()//down 10, left 12, right 14
        {
            int roomNumber = 11;
            Console.WriteLine ("\nYou've entered room 11!");
            string description = "\nApollo Square was where the lower class residents once lived." +
                "\nThis place wasn't hit as hard as Olympus Heights, but is still in terrible condition." +
                "\nA demolished security checkpoint gives you accessibility to once obstructed areas\n"; 
            Console.WriteLine (description);
            string choice = GetCommand ();
            string answer = HandleCommand (choice, roomNumber);
            if (answer == "left")
                Room12 ();
            else if (answer == "backward")
                Room10 ();
            else if (answer == "right")
                Room14 ();

            while (answer != "left" && answer != "backward" && answer != "right")
            {
                Console.Write ("\nThat's a deadend! Please enter a valid input: ");
                Console.WriteLine (description);
                choice = GetCommand ();
                answer = HandleCommand (choice, roomNumber);
                if (answer == "left")
                    Room12 ();
                else if (answer == "backward")
                    Room10 ();
                else if (answer == "right")
                    Room14 ();
            }
        }
        static void Room12 ()//down 5, left 7, right 11
        {
            int roomNumber = 12;
            Console.WriteLine ("\nYou've entered room 12!");
            string description = "\nPoint Prometheus was where genetic experimentation took place, and where " +
                "\nRapture's decent began. Plasmids that gave the populace it's superhuman powers and enhanced guards" +
                "\nNamed Big Daddies were created here. The labs still have some plasmids lying about.\n"; 
            Console.WriteLine (description);
            string choice = GetCommand ();
            string answer = HandleCommand (choice, roomNumber);
            if (answer == "left")
                Room7 ();
            else if (answer == "backward")
                Room5 ();
            else if (answer == "right")
                Room11 ();

            while (answer != "left" && answer != "backward" && answer != "right")
            {
                Console.Write ("\nThat's a deadend! Please enter a valid input: ");
                Console.WriteLine (description);
                choice = GetCommand ();
                answer = HandleCommand (choice, roomNumber);
                if (answer == "left")
                    Room7 ();
                else if (answer == "backward")
                    Room5 ();
                else if (answer == "right")
                    Room11 ();
            }
        }
        static void Room13 ()//left 10, up 14, down 15
        {
            int roomNumber = 13;
            Console.WriteLine ("\nYou've entered room 13!");
            string description = "\nThe Proving Grounds was once a museum full of powerful imagery to Rapture's history and greatness." +
                "\nNow, as its name implies, it's a training facility used by one of the factions \nduring the civil war to train their citizens for combat." +
                "\nThe Gift Shop and Museum Lobby have been picked clean of anything useful.\n"; 
            Console.WriteLine (description);
            string choice = GetCommand ();
            string answer = HandleCommand (choice, roomNumber);
            if (answer == "left")
                Room10 ();
            else if (answer == "backward")
                Room15 ();
            else if (answer == "forward")
                Room14 ();

            while (answer != "left" && answer != "backward" && answer != "forward")
            {
                Console.Write ("\nThat's a deadend! Please enter a valid input: ");
                Console.WriteLine (description);
                choice = GetCommand ();
                answer = HandleCommand (choice, roomNumber);
                if (answer == "left")
                    Room10 ();
                else if (answer == "backward")
                    Room15 ();
                else if (answer == "forward")
                    Room14 ();
            }
        }
        static void Room14 ()//left 11, down 13
        {
            int roomNumber = 14;
            Console.WriteLine ("\nYou've entered room 14!");
            string description = "\nFontaine's Lair is where one of the faction leaders resided." +
                "\nA giant genetic mucation device lies in the center of the room." +
                "\nThere is a giant monster on the floor in front of the device, already dead."; 
            Console.WriteLine (description);
            string choice = GetCommand ();
            string answer = HandleCommand (choice, roomNumber);
            if (answer == "left")
                Room11 ();
            else if (answer == "backward")
                Room13 ();

            while (answer != "left" && answer != "backward")
            {
                Console.Write ("\nThat's a deadend! Please enter a valid input: ");
                Console.WriteLine (description);
                choice = GetCommand ();
                answer = HandleCommand (choice, roomNumber);
                if (answer == "left")
                    Room11 ();
                else if (answer == "backward")
                    Room13 ();
            }
        }
        static void Room15 ()//END
        {
            Console.WriteLine ("\nYou have reached the bathysphere! As you ascend back to the surface," +
                "\nyou can see Rapture is shrinking in the distance, it's horrors now behind you." +
                "\nYou have completed the maze!");
        }


        static string s_command;
        static string s_forward = "forward";
        static string s_backward = "backward";
        static string s_right = "right";
        static string s_left = "left";

        static string s_exitForward = "forward";
        static string s_exitBackward = "backward";
        static string s_exitRight = "right";
        static string s_exitLeft = "left";
    }
}
