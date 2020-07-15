using System;
//DO NOT DELETE the two following using statements *********************************
using Game_Logic_Class;
using Object_Classes;

namespace Space_Race
{
    class Console_Class
    {
        public static int roundCount; // round number
        /// <summary>
        /// Algorithm below currently plays only one game
        /// 
        /// when have this working correctly, add the abilty for the user to 
        /// play more than 1 game if they choose to do so.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {

            DisplayIntroductionMessage();

            /*                    
             Set up the board in Board class (Board.SetUpBoard)
             Determine number of players - initally play with 2 for testing purposes 
             Create the required players in Game Logic class
              and initialize players for start of a game             
             loop  until game is finished           
                call PlayGame in Game Logic class to play one round
                Output each player's details at end of round
             end loop
             Determine if anyone has won
             Output each player's details at end of the game
           */
            //SETUP
            Submain();
            /////
            //PreEndChoice();
            //EndChoice();
            /////
            //Board.SetUpBoard();
            //for (int i = 0; i < Board.Squares.Length; i++)
            //{
            //    Console.WriteLine(Board.Squares[i]);
            //}
            //for(int j = 0; j < SpaceRaceGame.Players.Count; j++)
            //{
            //    Console.WriteLine(SpaceRaceGame.Players[j]);
            //}
            //Console.ReadKey();



        }//end Main
        /// <summary>
        /// The main loop of the program. So the game can be replayed without the welcome message
        /// Pre:    none / welcome message.
        /// Post:   game complete.
        /// </summary>
        static void Submain()
        {
            roundCount = -1; //resetting the starting round count
            Board.SetUpBoard(); //setting up the board class
            SpaceRaceGame.NumberOfPlayers = InputNumberOfPlayers(); // setting number of players while checking for input type/range
            SpaceRaceGame.SetUpPlayers(); //determinig the NumberOfPlayers in the SpaceRaceGame Class
            SpaceRaceGame.GameAtFinish = false;                             //END SETUP

            //LOOP
            bool round_loop = true;
            while (round_loop)
            {
                roundCount++;
                PlayRoundCue();

                SpaceRaceGame.PlayOneRound(); //this code is for creating the number of players which are playing the specific Turn

                foreach (Player player in SpaceRaceGame.Players)
                {
                    Console.WriteLine("\t{0} on Square {1} with {2} yottawatt of power remaining", player.Name, player.Position, player.RocketFuel);
                }
                //foreach (Player player in SpaceRaceGame.Players)
                //{
                //    if (player.AtFinish == true)
                //        break;
                //            break;
                //}
                if (SpaceRaceGame.GameAtFinish == true)
                {

                    round_loop = false;
                }



            }
            //END LOOP
            //ENDGAME
            EndGameProcess();
            EndChoice();
        }

        /// <summary>
        /// Display a welcome message to the console
        /// Pre:    none.
        /// Post:   A welcome message is displayed to the console.
        /// </summary>
        static void DisplayIntroductionMessage()
        {
            Console.WriteLine("\n\tWelcome to Space Race.\n");
        } //end DisplayIntroductionMessage

        /// <summary>
        /// Displays a prompt and waits for a keypress.
        /// Pre:  none
        /// Post: a key has been pressed.
        /// </summary>
        static void PressEnter()
        {
            Console.Write("\n\tPress Enter to terminate program ...");
            Console.ReadLine();
        } // end PressAny

        /// <summary>
        /// Displays a prompt and waits for a keypress then checks the input to confirm whether it is in bounds
        /// Pre:  setup board
        /// Post: number of players input taken
        /// </summary>
        static int InputNumberOfPlayers()
        {
            string UserInput;
            int number;
            bool GoodChoice = false;
            bool check = false;

            do
            {
                Console.WriteLine("\tThis Game is from 2 to 6  players");
                Console.Write("\tHow many players (2-6): ");
                UserInput = Console.ReadLine();
                Console.WriteLine();
                GoodChoice = int.TryParse(UserInput, out number);
                if (GoodChoice = true && (number >= SpaceRaceGame.MIN_PLAYERS && number <= SpaceRaceGame.MAX_PLAYERS))
                {
                    check = true;
                }
                else
                {
                    Console.WriteLine("Error: invalid number of players entered\n");
                }
            } while (!check);
            return number;
        }

        // Round numbers

        static void PlayRoundCue()
        {
            Console.Write("\nPress Enter to play a round ...");
            Console.ReadLine();
            if (roundCount > 0)
            {
                Console.WriteLine("\n\tNext Round\n");
            }
            else
            {
                Console.WriteLine("\n\tFirst Round\n");
            }

        }
        static void EndGameProcess()
        {
            Console.WriteLine("\n\n\tThe following player(s) finished the game");
            foreach (Player player in SpaceRaceGame.Players)
            {
                if (player.AtFinish == true)
                {
                    Console.WriteLine("\t\n\t        {0}", player.Name);
                }
            }
            Console.WriteLine("\n\n\tIndividual players finished with amounts of fuel at the locations specified");
            foreach (Player player in SpaceRaceGame.Players)
            {
                Console.WriteLine("\n\t        {0} with {2} yottawatt at Square {1} ", player.Name, player.Position, player.RocketFuel);
            }
            Console.Write("\n\nPress Enter Key to continue ...");
            Console.ReadLine();
        }
        static void EndChoice()
        {
            bool good = false;
            while (!good)
            {
                Console.Clear();
                Console.Write("\n\n\n\n\n\tPlay Again? (y or n): ");
                char input = Console.ReadKey().KeyChar;
                if (input == 'y' || input == 'Y')
                {
                    good = true;
                    Console.WriteLine(); //blank
                    Submain();
                }
                else
                {
                    good = true;
                    Console.WriteLine("\n\n\n\tThanks for playing Space Race.");
                    PressEnter();
                }
            }

        }
    }
}//end Console class