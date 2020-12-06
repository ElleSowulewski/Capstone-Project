using System;

namespace Capstone
{
    class Program
    {
        // **************************************************
        //
        // Title: Capstone Project
        // Description: An applicstion that plays games
        //              for my CIT110 Capstone Project
        // Application Type: Console
        // Author: Elle Sowulewski
        // Dated Created: 11/19/2020
        // Last Updated: 12/6/2020
        //
        // **************************************************

        //-------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// *****************************************************************
        /// *                            Main                               *
        /// *****************************************************************
        /// </summary>
        
        static void Main(string[] args)
        {
            // Calls the methods to set the theme and display menus

            SetTheme();

            DisplayWelcomeScreen();
            DisplayMenuScreen();
            DisplayClosingScreen();
        }

        /// <summary>
        /// *****************************************************************
        /// *                        Set Theme                              *
        /// *****************************************************************
        /// </summary>

        static void SetTheme()
        {
            // Sets the background to blue and forground to white

            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Blue;
        }

        //-------------------------------------------------------------------------------------------------------//

        #region MAIN MENU

        /// <summary>
        /// *****************************************************************
        /// *                        Main Menu                              *
        /// *****************************************************************
        /// </summary>
        /// 

        static void DisplayMenuScreen()
        {
            Console.CursorVisible = true;

            bool quitApplication = false;
            string menuChoice;

            do
            {
                DisplayScreenHeader("Main Menu");

                
                // Get user menu choice
                
                Console.WriteLine("\ta) Number Guessing Game");
                Console.WriteLine("\tb) Rock Paper Scissors");
                Console.WriteLine("\tq) Quit");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();

                
                // process user menu choice
                
                switch (menuChoice)
                {
                    case "a":
                        NumberGuesser();
                        break;

                    case "b":
                        RPS();
                        break;

                    case "q":
                        quitApplication = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quitApplication);
        }

        #endregion

        //-------------------------------------------------------------------------------------------------------//

        #region NUMBER GUESSER

        /// <summary>
        /// *****************************************************************
        /// *                       Number Guesser                          *
        /// *****************************************************************
        /// </summary>
        
        static void NumberGuesser()
        {
            // A game where the program gets a random number and the user tries to guess it

            (int lives, int hints) gameSettings;
            gameSettings.lives = 3;
            gameSettings.hints = 1;

            bool quitNGMenu = false;
            string menuChoice;

            do
            {
                DisplayScreenHeader("Game Menu");


                // Get user menu choice

                Console.WriteLine("\ta) Instructions");
                Console.WriteLine("\tb) Settings");
                Console.WriteLine("\tc) Play");
                Console.WriteLine("\tq) Quit");
                Console.Write("\t\tEnter Choice:");
                
                menuChoice = Console.ReadLine().ToLower();
               
                // process user menu choice

                switch (menuChoice)
                {
                    case "a":

                        NGInstructions(gameSettings.lives, gameSettings.hints);
                        break;

                    case "b":

                        gameSettings = NGSettings();
                        break;

                    case "c":

                        NGPlay(gameSettings.lives, gameSettings.hints);
                        break;

                    case "q":
                        quitNGMenu = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quitNGMenu);

            DisplayContinuePrompt();
            
        }

        //-------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// *****************************************************************
        /// *                     Number Guesser Game                       *
        /// *****************************************************************
        /// </summary>

        static void NGPlay(int lives, int hints)
        {
            // Time to play!

            DisplayScreenHeader("Number Guesser");

            int numberToGuess = RandNum();
            Console.WriteLine("\tI am guessing a number between 1 and 100. Can you guess it?");
            Console.WriteLine();

            while (lives > 0)
            {
                Console.WriteLine("\tEnter your guess...");
                Console.WriteLine();
                string userGuess = Console.ReadLine();
                int guess = int.Parse(userGuess);

                if (guess > numberToGuess)
                {
                    if (hints == 1)
                    {
                        Console.WriteLine("\tYour guess was too high!");
                        Console.WriteLine();
                        lives--;
                    }
                    else
                    {
                        Console.WriteLine("\tYour guess was incorrect!");
                        Console.WriteLine();
                        lives--;
                    }
                }
                if (guess < numberToGuess)
                {
                    if (hints == 1)
                    {
                        Console.WriteLine("\tYour guess was too low!");
                        Console.WriteLine();
                        lives--;
                    }
                    else
                    {
                        Console.WriteLine("\tYour guess was incorrect!");
                        Console.WriteLine();
                        lives--;
                    }
                }
                if (guess == numberToGuess)
                {
                    Console.WriteLine("\tYou correctly guessed the number! YOU WIN!");
                    Console.WriteLine();

                    Console.WriteLine("\tWould you like to play again? [yes / no]");
                    string input2 = Console.ReadLine().ToLower();
                    Console.WriteLine();
                    if (input2 == "yes")
                    {
                        NGPlay(lives, hints);
                    }
                    else if (input2 == "no")
                    {
                        DisplayContinuePrompt();
                    }
                    else
                    {
                        Console.WriteLine("\tPlease enter either 'yes' or 'no'.");
                    }
                }
            }

            Console.WriteLine("\tYou failed to guess the number. You lose...");
            Console.WriteLine($"\tThe number was: {numberToGuess}");
            Console.WriteLine();

            Console.WriteLine("\tWould you like to play again? [yes / no]");
            string input = Console.ReadLine().ToLower();
            if (input == "yes")
            {
                NGPlay(lives, hints);
            }
            if (input == "no")
            {
                DisplayContinuePrompt();
            }
            else
            {
                Console.WriteLine("\tPlease enter either 'yes' or 'no'.");
            }
        }

        //-------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// *****************************************************************
        /// *                   Number Guesser Settings                    *
        /// *****************************************************************
        /// </summary>

        static (int lives, int hints) NGSettings()
        {
            // Allows the user to review and modify settings for the Number Guesser Game

            (int lives, int hints) gameSettings;
            gameSettings.lives = 3;
            gameSettings.hints = 1;

            bool quitSettings = false;
            string menuChoice;

            do
            {
                DisplayScreenHeader("Settings Menu");


                // Get user menu choice and display current settings

                Console.WriteLine("\ta) Change Amount of Lives");
                Console.WriteLine("\tb) Toggle Hints");
                Console.WriteLine("\tq) Quit");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();

                // process user menu choice

                switch (menuChoice)
                {
                    case "a":

                        // Validates the users input for lives for the number guesser game

                        Console.WriteLine();
                        Console.WriteLine($"\tLives are set to: {gameSettings.lives}");
                        Console.WriteLine();
                        Console.WriteLine("\tEnter the new life amount:");

                        int userInput = 0;
                        bool loop = true;
                        while (loop == true)
                        {
                            if (int.TryParse(Console.ReadLine(), out userInput) == true)
                            {
                                if (userInput > 0 && userInput <= 10)
                                {
                                    gameSettings.lives = userInput;
                                    Console.WriteLine($"\tLives is now set to {gameSettings.lives}");
                                    Console.WriteLine();
                                    DisplayContinuePrompt();
                                    loop = false;
                                }
                                else
                                {
                                    Console.WriteLine("\tThe number you entered was not valid. Please try a number between 0 and 10.");
                                    Console.WriteLine();
                                }
                            }
                            else
                            {
                                Console.WriteLine("\tThe number you entered was not valid. Please try a number between 0 and 10.");
                                Console.WriteLine();
                            }
                        }
                        break;

                    case "b":

                        // Validates the users input for hints for the number guesser game

                        Console.WriteLine();

                        if (gameSettings.hints == 1)
                        {
                            Console.WriteLine($"\tHints are curently ON");
                            Console.WriteLine();
                        }
                        if (gameSettings.hints == 0)
                        {
                            Console.WriteLine($"\tHints are currently OFF");
                            Console.WriteLine();
                        }

                        Console.WriteLine("Would you like to toggle hints? [yes / no]");
                        Console.WriteLine();

                        // validate input
                        string userInput2 = Console.ReadLine().ToLower();
                        bool loop2 = true;
                        while (loop2 == true)
                        {
                            if (userInput2 == "yes")
                            {
                                if (gameSettings.hints == 1)
                                {
                                    gameSettings.hints = 0;
                                    Console.WriteLine("\tHints are now OFF.");
                                    DisplayContinuePrompt();
                                    loop = false;
                                    break;
                                }
                                else if (gameSettings.hints == 0)
                                {
                                    gameSettings.hints = 1;
                                    Console.WriteLine("\tHints are now ON.");
                                    DisplayContinuePrompt();
                                    loop = false;
                                    break;
                                }
                            }
                            if (userInput2 == "no")
                            {
                                DisplayContinuePrompt();
                                loop = false;
                                break;
                            }
                            else
                            {
                                Console.WriteLine("\tYour input was not valid. Please enter either 'yes' or 'no'.");
                                Console.WriteLine();
                            }
                        }
                        break;

                    case "q":
                        quitSettings = true;
                        return gameSettings;
                        
                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }
            } while (!quitSettings);
            return gameSettings;
            
        }

        //-------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// *****************************************************************
        /// *                 Number Guesser Instructions                   *
        /// *****************************************************************
        /// </summary>

        static void NGInstructions(int lives, int hint)
        {
            // Displays the instructions for the number guesser game

            DisplayScreenHeader("Number Guesser Instructions");

            Console.WriteLine("\tWelcome to the Number Guesser Game!");
            Console.WriteLine("\tIn this game the computer will have a number that you need to try and guess!");
            Console.WriteLine($"\tYou have {lives} chances to guess the number!");

            if (hint == 1)
            {
                Console.WriteLine("\tThe computer will give you hints on if your guess was too high or too low.");
            }

            DisplayContinuePrompt();

        }

        //-------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// *****************************************************************
        /// *                   Randum Number Generator                     *
        /// *****************************************************************
        /// </summary>

        static int RandNum()
        {
            // Generates a random number for the number guesser game

            Random random = new Random();

            int numberToGuess = random.Next(101);

            return numberToGuess;

        }

        #endregion

        //-------------------------------------------------------------------------------------------------------//

        #region RPS

        /// <summary>
        /// *****************************************************************
        /// *                     Rock Paper Scissors                       *
        /// *****************************************************************
        /// </summary>

        static void RPS()
        {
            // A game where the program gets a random number representing rock paper scissors and the user tries to counter it

            bool quitNGMenu = false;
            string menuChoice;

            do
            {
                DisplayScreenHeader("Game Menu");


                // Get user menu choice

                Console.WriteLine("\ta) Instructions");
                Console.WriteLine("\tb) Play");
                Console.WriteLine("\tq) Quit");
                Console.Write("\t\tEnter Choice:");

                menuChoice = Console.ReadLine().ToLower();

                // process user menu choice

                switch (menuChoice)
                {
                    case "a":

                        RPSInstructions();
                        break;

                    case "b":

                        RPSPlay();
                        break;

                    case "q":
                        quitNGMenu = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quitNGMenu);

            DisplayContinuePrompt();

        }

        //-------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// *****************************************************************
        /// *                          RPS Game                             *
        /// *****************************************************************
        /// </summary>

        static void RPSPlay()
        {
            // Time to play!

            int comp = 0; 
            int user = 0;

            DisplayScreenHeader("Rock Paper Scissors");

            bool loop = true;
            while (loop == true)
            {
                // Loops until user enters valid input
                bool valid = false;
                while (valid == false)
                {
                    Console.WriteLine("\tWhat do you choose? [rock, paper, scissors]");
                    Console.WriteLine();
                    var userInput = Console.ReadLine().ToLower();
                    comp = RPSRandNum();

                    // Validates, echos user's input and converts to a number for comparison
                    if (userInput == "rock")
                    {
                        user = 1;
                        Console.WriteLine($"\tYou chose {userInput}!");
                        valid = true;
                    }
                    else if (userInput == "paper")
                    {
                        user = 2;
                        Console.WriteLine($"\tYou chose {userInput}!");
                        valid = true;
                    }
                    else if (userInput == "scissors")
                    {
                        user = 3;
                        Console.WriteLine($"\tYou chose {userInput}!");
                        valid = true;
                    }
                    else
                    {
                        Console.WriteLine("\tYour input was invalid, please try again.");
                        Console.WriteLine("");
                    }
                }

                Console.WriteLine();
                Console.WriteLine("\tRock!");
                System.Threading.Thread.Sleep(1000);
                Console.WriteLine("\tPaper!");
                System.Threading.Thread.Sleep(1000);
                Console.WriteLine("\tScissors!");
                System.Threading.Thread.Sleep(1000);
                Console.WriteLine("\tShoot!");
                Console.WriteLine();

                // Tells user what computer got
                if (comp == 1)
                {
                    Console.WriteLine("\tThe computer chose rock!");
                }
                else if (comp == 2)
                {
                    Console.WriteLine("\tThe computer chose paper!");
                }
                else if (comp == 3)
                {
                    Console.WriteLine("\tThe computer chose scissors!");
                }

                Console.WriteLine();

                // Make comparison and tell user if they won, lost, or tie
                if (comp == 1 && user == 1)
                {
                    Console.WriteLine("\tRock doesn't affect rock, it's a tie!");
                }
                else if (comp == 1 && user == 2)
                {
                    Console.WriteLine("\tPaper beats rock, you win!");
                }
                else if (comp == 1 && user == 3)
                {
                    Console.WriteLine("\tRock beats scissors, you lose!");
                }
                else if (comp == 2 && user == 1)
                {
                    Console.WriteLine("\tPaper beats rock, you lose!");
                }
                else if (comp == 2 && user == 2)
                {
                    Console.WriteLine("\tPaper doesn't affect paper, it's a tie!");
                }
                else if (comp == 2 && user == 3)
                {
                    Console.WriteLine("\tScissors beat paper, you win!");
                }
                else if (comp == 3 && user == 1)
                {
                    Console.WriteLine("\tRock beats scissors, you win!");
                }
                else if (comp == 3 && user == 2)
                {
                    Console.WriteLine("\tScissors beat paper, you lose!");
                }
                else if (comp == 3 && user == 3)
                {
                    Console.WriteLine("\tScissors doesn't affect scissors, it's a tie!");
                }

                Console.WriteLine();
                Console.WriteLine("\tWould you like to play again? [yes / no]");
                var uInput = Console.ReadLine().ToLower();
                Console.WriteLine();

                bool vloop = true;
                while (vloop == true)
                {
                    if (uInput == "yes")
                    {
                        vloop = false;
                    }
                    else if (uInput == "no")
                    {
                        loop = false;
                        vloop = false;
                    }
                    else
                    {
                        Console.WriteLine("\tPlease enter either 'yes' or 'no'.");
                    }
                }      
            }
        }

        //-------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// *****************************************************************
        /// *                      RPS Instructions                         *
        /// *****************************************************************
        /// </summary>

        static void RPSInstructions()
        {
            // Displays the instructions for the rock paper scissors game

            DisplayScreenHeader("Rock Paper Scissors Instructions");

            Console.WriteLine("\tWelcome to Rock Paper Scissors!");
            Console.WriteLine("\tIn this game the computer will choose either rock, paper, or scissors.");
            Console.WriteLine("\tYou will have to also choose either rock, paper, or scissors.");
            Console.WriteLine();
            Console.WriteLine("\t\tRock beats Scissors");
            Console.WriteLine("\t\tScissors beat Paper");
            Console.WriteLine("\t\tPaper beats Rock");
            Console.WriteLine();
            Console.WriteLine("\tTry to guess what the computer will choose and pick accordingly to win!");

            DisplayContinuePrompt();

        }

        //-------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// *****************************************************************
        /// *                        RPS Generator                          *
        /// *****************************************************************
        /// </summary>

        static int RPSRandNum()
        {
            // Generates a random number for the rock paper scissors game

            Random random = new Random();

            int RPSnumber = random.Next(4);

            return RPSnumber;

        }

        #endregion

        //-------------------------------------------------------------------------------------------------------//

        #region USER INTERFACE

        /// <summary>
        /// *****************************************************************
        /// *                     Welcome Screen                            *
        /// *****************************************************************
        /// </summary>

        static void DisplayWelcomeScreen()
        {
            // Displays the welcome screen for the beginning of the app

            Console.CursorVisible = false;

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\tGame Player");
            Console.WriteLine();

            DisplayContinuePrompt();
        }

        //-------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// *****************************************************************
        /// *                     Closing Screen                            *
        /// *****************************************************************
        /// </summary>

        static void DisplayClosingScreen()
        {
            // Displays the closing screen for the ending of the app

            Console.CursorVisible = false;

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\tThank you for using the Game Player!");
            Console.WriteLine();
            Console.WriteLine("\t\tDeveloped by: Elle Sowulewski");
            Console.WriteLine("\t\tfor the CIT110 Capstone Project.");
            Console.WriteLine();

            DisplayContinuePrompt();
        }

        //-------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// *****************************************************************
        /// *                  Display Continue Prompt                      *
        /// *****************************************************************
        /// </summary>
        static void DisplayContinuePrompt()
        {
            // Method for waiting for user input before continuing

            Console.WriteLine();
            Console.WriteLine("\tPress any key to continue...");
            Console.ReadKey();
        }

        //-------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// *****************************************************************
        /// *                    Display Menu Prompt                        *
        /// *****************************************************************
        /// </summary>
        
        static void DisplayMenuPrompt(string menuName)
        {
            // Method for returning the user to the previous menu

            Console.WriteLine();
            Console.WriteLine($"\tPress any key to return to the {menuName} Menu.");
            Console.ReadKey();
        }

        //-------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// *****************************************************************
        /// *                    Display Screen Header                      *
        /// *****************************************************************
        /// </summary>
        
        static void DisplayScreenHeader(string headerText)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\t" + headerText);
            Console.WriteLine();
        }

        #endregion

        //-------------------------------------------------------------------------------------------------------//
    }
}

