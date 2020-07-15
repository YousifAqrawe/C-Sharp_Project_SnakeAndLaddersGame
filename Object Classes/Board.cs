using System.Diagnostics;

namespace Object_Classes
{
    /// <summary>
    /// Models a game board for Space Race consisting of three different types of squares
    /// 
    /// Ordinary squares, Wormhole squares and Blackhole squares.
    /// 
    /// landing on a Wormhole or Blackhole square at the end of a player's move 
    /// results in the player moving to another square
    /// 
    /// </summary>
    public static class Board
    {
        /// <summary>
        /// Models a game board for Space Race consisting of three different types of squares
        /// 
        /// Ordinary squares, Wormhole squares and Blackhole squares.
        /// 
        /// landing on a Wormhole or Blackhole square at the end of a player's move 
        /// results in the player moving to another square
        /// 
        /// 
        /// </summary>

        public const int NUMBER_OF_SQUARES = 56;
        public const int START_SQUARE_NUMBER = 0;
        public const int FINISH_SQUARE_NUMBER = NUMBER_OF_SQUARES - 1;

        private static Square[] squares = new Square[NUMBER_OF_SQUARES];

        public static Square[] Squares
        {
            get
            {
                Debug.Assert(squares != null, "squares != null",
                   "The game board has not been instantiated");
                return squares;
            }
        }

        public static Square StartSquare
        {
            get
            {
                return squares[START_SQUARE_NUMBER];
            }
        }


        /// <summary>
        ///  Eight Wormhole squares.
        ///  
        /// Each row represents a Wormhole square number, the square to jump forward to and the amount of fuel consumed in that jump.
        /// 
        /// For example {2, 22, 10} is a Wormhole on square 2, jumping to square 22 and using 10 units of fuel
        /// 
        /// </summary>
        private static int[,] wormHoles =
        {
            {2, 22, 10},
            {3, 9, 3},
            {5, 17, 6},
            {12, 24, 6},
            {16, 47, 15},
            {29, 38, 4},
            {40, 51, 5},
            {45, 54, 4}
        };

        /// <summary>
        ///  Eight Blackhole squares.
        ///  
        /// Each row represents a Blackhole square number, the square to jump back to and the amount of fuel consumed in that jump.
        /// 
        /// For example {10, 4, 6} is a Blackhole on square 10, jumping to square 4 and using 6 units of fuel
        /// 
        /// </summary>
        private static int[,] blackHoles =
        {
            {10, 4, 6},
            {26, 8, 18},
            {30, 19, 11},
            {35,11, 24},
            {36, 34, 2},
            {49, 13, 36},
            {52, 41, 11},
            {53, 42, 11}
        };


        /// <summary>
        /// Parameterless Constructor
        /// Initialises a board consisting of a mix of Ordinary Squares,
        ///     Wormhole Squares and Blackhole Squares.
        /// 
        /// Pre:  none
        /// Post: board is constructed
        /// </summary>
        public static void SetUpBoard()
        {

            // Create the 'start' square where all players will start.
            squares[START_SQUARE_NUMBER] = new Square("Start", START_SQUARE_NUMBER);

            // Create the main part of the board, squares 1 .. 54
            //  CODE NEEDS TO BE ADDED HERE
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////
            for (int squareBetween = 1; squareBetween < 55; squareBetween++) //To get the squares from 1 to 54, i have mentioned that we do for loop which 
                                                                             //includes that the squareBetween is starting with the Square #1 and SquareBetween 
                                                                             //is ending with the Square #54 
            {
                squares[squareBetween] = new Square(squareBetween.ToString(), squareBetween); // By creating the new operator which converts the SquareBetween 
                                                                                              //to a string value
            }
            for (int sqareNom = 1; sqareNom <= (NUMBER_OF_SQUARES - 2); sqareNom++) // Setting up NORMAL 'Squares'  
                                                                                    //
            {
                //PROVIDING THE SAME NUMBER OF WORMHOLES AND BLACKHOLES ARE PRESENT

                //for (int c = 0; c < wormHoles.GetLength(0); c++)
                // As we know in this situation should includes the wormholes and blackHoles
                //and in each of wormholes and blackholes, they've 8 values and in each of these 8 values:-
                //there are 3 additional values which are:- 
                // the first value of these 8 values are the Square
                //  the Second value of these 8 values are the jumping values 
                //  the Third value of these 8 values are the fuel values

                for (int c = 0; c < blackHoles.GetLength(0); c++)
                { // creating if statement to to make sence what does the values in Blacholes and Wormholes mean
                    if (sqareNom == wormHoles[c, 0]) // this means if the squareNom equel to the first value in each first value of the 8 values in Wormholes Private static int[,]
                        // wormholes which are between Curly braces and they are: 2,3,5,12,16,29,40,45 and to get these numbers we have 
                                                     //to add the value in for loop 'c' , and number 0 which include the the int square 
                    {
                        int square = wormHoles[c, 0]; // int square includes the numbers  in Wormholes Private Method
                                                      // and to get these numbers we have to add the value in for loop 'c' , and number 0 which includes the Second value in
                                                      // the each 8 values of Wormholes which are between Curly braces of the Private static int[,] wormholes which includes
                                                      //2,3,5,12,16,29,40,45
                        int jumping = wormHoles[c, 1]; // int jumping includes the numbers  in Wormholes Private Method
                                                    // and to get these numbers we have to add the value in for loop 'c' , and number 1 which includes the Second value in
                                                    // the Wormholes which are between Curly braces of the Private static int[,] wormholes which includes 22,9,17,24,47,38,51,54
                        int fuel_units = wormHoles[c, 2];  // int fuel_units includes the numbers  in Wormholes Private Method
                                                           // and to get these numbers we have to add the value in for loop 'c' , and number 2 which includes the Third value in
                                                           // the Wormholes which are between Curly braces{ } the Private static int[,] wormholes, which includes 10,2,6,6,15,4,5,4,

                        squares[sqareNom] = new WormholeSquare(sqareNom.ToString(), sqareNom, jumping , fuel_units);
                    }

                    else if (sqareNom == blackHoles[c, 0]) // but suppose to the squareNom is equal to blackholes values and if this squareNom is equal to the first value of the 8 
                                                           //blackholes values
                    {
                        int square = blackHoles[c, 0];// int square includes the numbers 10,26,30,25,26,49,52,53 in blackHoles Private Method
                                                      // and to get these numbers we have to add the value in for loop 'c' , and number 0 which includes the first value in
                                                      // the blackholes which are between Curly braces{ }

                        int jumping = blackHoles[c, 1];// int next includes the numbers 4,8,19,11,34,13,41,42 in blackHoles Private Method
                                                    // and to get these numbers we have to add the value in for loop 'c' , and number 1 which includes the second value in
                                                    // the blackholes which are between Curly braces{ } 

                        int fuel_units = blackHoles[c, 2];  // int fuel_units includes the numbers 6,18,11,24,2,36,11,11 in blackHoles Private Method
                                                      // and to get these numbers we have to add the value in for loop 'c' , and number 2 which includes the second value in
                                                      // the blackholes which are between Curly braces{ }
                        squares[sqareNom] = new BlackholeSquare(sqareNom.ToString(), sqareNom, jumping, fuel_units);
                    }



                }







                /*This lines make the last square means square number 56. and it will assign it to that new variable
                 We can use the FINISH_SQUARE_NUMBER*/
                // Create the 'finish' square.

                squares[FINISH_SQUARE_NUMBER] = new Square("Finish", FINISH_SQUARE_NUMBER);

            }

        }




        // end SetUpBoard

        /// <summary>
        /// Finds the destination square and the amount of fuel used for either a 
        /// Wormhole or Blackhole Square.
        /// 
        /// pre: squareNum is either a Wormhole or Blackhole square number
        /// post: destNum and amount are assigned correct values.
        /// </summary>
        /// <param name="holes">a 2D array representing either the Wormholes or Blackholes squares information</param>
        /// <param name="squareNum"> a square number of either a Wormhole or Blackhole square</param>
        /// <param name="destNum"> destination square's number</param>
        /// <param name="amount"> amont of fuel used to jump to the deestination square</param>

        private static void FindDestSquare(int[,] holes, int squareNum, out int destNum, out int amount)
        {
            const int start = 0, exit = 1, fuel = 2;
            destNum = 0; amount = 0;

            //  CODE NEEDS TO BE ADDED HERE
            ///////////////////////////////////////////////////////////////////////////////////////// OTHERWISE IF "holes" GIVEN REFERNCE THAT INSTEAD OF INDIVIDUALS
            //Creating a for loop to get the destination of the squares and also the the fuel's amount which is used in the squares of Wormhole or Blackhole 
            for (int sqareNombers = 0; sqareNombers < NUMBER_OF_SQUARES; sqareNombers++)
            {
                for (int k = 0; k < holes.GetLength(0); k++)
                {
                    if (sqareNombers == squareNum && sqareNombers == holes[k, start])
                    {
                        destNum = holes[k, exit];
                        squareNum = holes[k, fuel];
                    }

                }

            }
            /////////////////////////////////////////////////////////////////////////////////////////
        } //end FindDestSquare

    } //end class Board
}
