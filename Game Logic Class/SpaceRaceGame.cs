using System.Drawing;
using System.ComponentModel;
using Object_Classes;
using System;


namespace Game_Logic_Class
{
    public static class SpaceRaceGame
    {
        // Minimum and maximum number of players.
        public const int MIN_PLAYERS = 2;
        public const int MAX_PLAYERS = 6;

        private static int numberOfPlayers = 2; 
        public static int NumberOfPlayers
        {
            get
            {
                return numberOfPlayers;
            }
            set
            {
                numberOfPlayers = value;
            }
        }

        public static string[] names = { "One", "Two", "Three", "Four", "Five", "Six" };  // default values

        // Only used in Part B - GUI Implementation, the colours of each player's token
        private static Brush[] playerTokenColours = new Brush[MAX_PLAYERS] { Brushes.Yellow, Brushes.Red,
                                                                       Brushes.Orange, Brushes.White,
                                                                      Brushes.Green, Brushes.DarkViolet};
        /// <summary>
        /// A BindingList is like an array which grows as elements are added to it.
        /// </summary>
        private static BindingList<Player> players = new BindingList<Player>();
        public static BindingList<Player> Players
        {
            get
            {
                return players;
            }
        }

        // The pair of die
        private static Die die1 = new Die(), die2 = new Die();
        /// <summary>
        /// Set up the conditions for this game as well as
        ///   creating the required number of players, adding each player 
        ///   to the Binding List and initialize the player's instance variables
        ///   except for playerTokenColour and playerTokenImage in Console implementation.
        ///   
        ///     
        /// Pre:  none
        /// Post:  required number of players have been initialsed for start of a game.
        /// </summary>
        public static void SetUpPlayers()
        {
             Players.Clear();

            for (int i = 0; i < numberOfPlayers; i++)
            {
                
                Player player_object = new Player(names[i]);               
                player_object.RocketFuel = Player.INITIAL_FUEL_AMOUNT;
                player_object.AtFinish = false;
                player_object.Location = Board.StartSquare;
                player_object.Position = Board.START_SQUARE_NUMBER;
                player_object.HasPower = true;
                player_object.PlayerTokenColour = playerTokenColours[i];
                Players.Add(player_object);
            }



        }
        private static bool gameAtFinish;
        public static bool GameAtFinish 
        {

            get
            {
                return gameAtFinish;
            }

            set
            {
                gameAtFinish = value;
            }
        }
        // for number of players
        //      create a new player object
        //      initialize player's instance variables for start of a game
        //      add player to the binding list





        /// <summary>
        ///  Plays one round of a game
        /// </summary>
        /// 
        //Creating a Public method which allows a player to play a round by determine who is the player and where to start and finish
        private static void PlayOneTurn(int who)
        {

            if (players[who].HasPower)
            {
                players[who].Play(die1, die2);

                if (players[who].AtFinish)
                {
                    GameAtFinish = true;
                }

                //if (!players[who].HasPower)
                //{
                //    numberOfPlayers++;
                //}

            }

        } 
        public static void PlayOneRound()
        {

            for (int Rounds = 0; Rounds < NumberOfPlayers ; Rounds++) // by creating the for loop fuction to detemin how many 
                                                     // rounds for each number of players by adding the 
            {
                

                //}
                PlayOneTurn(Rounds);
                //Players[SetRound].Position = Players[SetRound].Location.Number;
                //Players[SetRound].Location.LandOn(this);
                // create a motheoth call PlayoneTurn  and call it here
                
            }

        }

        public static bool CheckForEndGame()
        {
            for (int i = 0; i < numberOfPlayers; i++)
            {
                if (numberOfPlayers == Board.FINISH_SQUARE_NUMBER)
                {
                    gameAtFinish = true;
                }
                if (numberOfPlayers >= Board.START_SQUARE_NUMBER && numberOfPlayers < Board.FINISH_SQUARE_NUMBER)
                {
                    gameAtFinish = false;
                }
            
            }
            return gameAtFinish;
        }

    }//end SnakesAndLadders
}