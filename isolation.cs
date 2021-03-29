using System;
using static System.Console;

namespace Isolation
{
    static partial class Program
    {   
        static string nameA;
        static string nameB;
        static int rows;           // Number of rows on game board.
        static int columns;        // Number of columns on game board.
        static string startPosA;   // Position of player A's starting platform.
        static string startPosB;   // Position of player B's starting platform.
        static string positionA;   // First two letters indicate original position of pawn A just before move is made.
        static string positionB;   // First two letters indicate original position of pawn A just before move is made.
        
        static bool[ , ] board = new bool[ rows, columns ];  // False (default) if tile is not removed, true if tile is removed.
        
        static string[ ] letters = { "a","b","c","d","e","f","g","h","i","j","k","l","m","n","o","p","q","r","s","t","u","v","w","x","y","z" };
        
        static string moveA = "";           // Two letters indicating desired position and two letters indicating tile to remove (player A).
        static string moveB = "";           // Two letters indicating desired position and two letters indicating tile to remove (player B).
        static bool gameEnd = false;
        static bool playerATurn = true;     // True if player A's turn, false if player B's turn.
        static bool firstMoveForA = true;   // True iff it is player A's first turn.
        static bool firstMoveForB = true;   // True iff it is player B's first turn.
        static bool blockRemovalA = false;  // Initiates the setting of board[ r, c ] to true or false.
        static bool blockRemovalB = false;  // Initiates the setting of board[ r, c ] to true or false.

        static void Main( )
        {
            WriteLine( );
            WriteLine( "~ For the best experience, play on full screen!" );
            WriteLine( );
            Initialize( );
            WriteLine( );
            DrawGameBoard( );
            Move( );
        }
        static void Move( )
        {
            string inputMoveA = "" ;   // Two letters indicating desired position and two letters indicating tile to remove (player A).
            string inputMoveB = "" ;   // Two letters indicating desired position and two letters indicating tile to remove (player B).
            bool isValid = false;
            int totalMoveCounterA = 0;
            int totalMoveCounterB = 0;
            firstMoveForA = false;
            blockRemovalA = true;
            
            // Initiate endless loop.
            while( gameEnd == false )
            {
                // Player A's turn.
                if( playerATurn == true )
                {
                    // Loops for user input until player A's input for their move is valid (checking for any restrictions)
                    while( isValid == false ) 
                    {
                        WriteLine( );
                        Write( $"{nameA}, please enter a move: " );
                        inputMoveA = ReadLine( );
                        WriteLine( );

                        if( test1( inputMoveA ) )
                            if( test2( inputMoveA, 4 ) )
                                if( test3( inputMoveA, totalMoveCounterA ) )
                                    if( test4( inputMoveA, positionA ) )
                                        if( test5( inputMoveA ) )
                                            if( test6( inputMoveA, positionB ) )
                                                    isValid = true;
 
                        if( isValid )
                        {
                            positionA = inputMoveA;
                            WriteLine( "New pawn row is {0}", inputMoveA.Substring( 0, 1 ) );
                            WriteLine( "New pawn column is {0}", inputMoveA.Substring( 1, 1 ) );
                            WriteLine( "Removed tile row is {0}", inputMoveA.Substring( 2, 1 ) );
                            WriteLine( "Removed tile column is {0}", inputMoveA.Substring( 3, 1 ) );
                        }
                    }
                    playerATurn = false; // Switching flag to indicate player B's turn.
                    isValid = false;     // Setting up the while loop for player B's turn.
                    totalMoveCounterA ++;
                }
                
                // Player B's turn.
                else
                {
                    firstMoveForB = false;
                    blockRemovalB = true;
                    
                    // Loops for user input until player B's input for their move is valid (checking for any restrictions)
                    while( isValid == false )
                    {
                        WriteLine( );
                        Write( $"{nameB}, please enter a move: " );
                        inputMoveB = ReadLine( );
                        WriteLine( );

                        if( test1( inputMoveB ) )
                            if( test2( inputMoveB, 4 ) )
                                if( test3( inputMoveB, totalMoveCounterB ) )
                                    if( test4( inputMoveB, positionB ) )
                                        if( test5( inputMoveB ) )
                                                if( test6( inputMoveB, positionA ) )
                                                    isValid = true;

                        if( isValid )
                        {
                            positionB = inputMoveB;
                            WriteLine( "New pawn row is {0}", inputMoveB.Substring( 0, 1 ) );
                            WriteLine( "New pawn column is {0}", inputMoveB.Substring( 1, 1 ) );
                            WriteLine( "Removed tile row is {0}", inputMoveB.Substring( 2, 1 ) );
                            WriteLine( "Removed tile column is {0}", inputMoveB.Substring( 3, 1 ) );
                            WriteLine( );
                        }
                    }
                    playerATurn = true; 
                    isValid = false;   // Setting up the while loop for player A's turn.
                    totalMoveCounterB ++;
                }
                WriteLine( );
                moveA = inputMoveA;
                moveB = inputMoveB;
                DrawGameBoard( );
                GameOver( positionA, nameB );
                GameOver( positionB, nameA );
            }
        }

        static void GameOver( string position, string winner )
        {
            int rowPos = Array.IndexOf( letters, position.Substring( 0, 1 ) );
            int colPos = Array.IndexOf( letters, position.Substring( 1, 1 ) );

            bool noMoreMoves = false;
            
            if( rowPos == 0 )
            {
                if( colPos == 0 )
                    noMoreMoves = board[ 0, 1 ] && board[ 1, 0 ] && board[ 1, 1 ];

                else if( colPos == columns - 1 )
                    noMoreMoves = board[ 0, colPos - 1 ] && board[ 1, colPos ] && board[ 1, colPos ];

                else
                    noMoreMoves = board[ 0, colPos + 1 ] && board[ 0, colPos - 1 ] && board[ 1, colPos - 1 ] && board[ 1, colPos + 1 ] && board[ 1, colPos ];
            }
            else if( rowPos == rows - 1 )
            {
                if( colPos == 0 )
                    noMoreMoves = board[ rowPos - 1, 0 ] && board[ rowPos, 1 ] && board[ rowPos - 1, 1 ];
                
                else if( colPos == columns - 1 )
                    noMoreMoves = board[ rowPos, colPos - 1 ] && board[ rowPos - 1, colPos ] && board[ rowPos - 1, colPos - 1 ];
                
                else
                    noMoreMoves = board[ rowPos, colPos + 1 ] && board[ rowPos, colPos - 1 ] && board[ rowPos - 1, colPos - 1 ] && board[ rowPos - 1, colPos + 1 ] && board[ rowPos - 1, colPos ];
            }
            else
            {
                if( colPos == 0 )
                    noMoreMoves = board[ rowPos, 1 ] && board[ rowPos - 1, 0 ] && board[ rowPos + 1, 0 ] && board[ rowPos - 1, 1 ] && board[ rowPos + 1, 1 ];
                
                else if( colPos == columns - 1 )
                    noMoreMoves = board[ rowPos, colPos - 1 ] && board[ rowPos - 1, colPos ] && board[ rowPos + 1, colPos ] && board[ rowPos - 1, colPos - 1 ] && board[ rowPos + 1, colPos - 1 ];

                else
                    noMoreMoves = board[ rowPos - 1, colPos - 1 ] && board[ rowPos + 1, colPos - 1 ] && board[ rowPos - 1, colPos ] && board[ rowPos + 1, colPos ] && board[ rowPos - 1, colPos + 1 ] && board[ rowPos + 1, colPos + 1 ] && board[ rowPos, colPos - 1 ] && board[ rowPos, colPos + 1 ];
            }

            if( noMoreMoves )
            {
                gameEnd = true;
                WriteLine( ); 
                WriteLine( "Game Over! {0} is the winner!", winner );
                WriteLine( ); 
            }
        }
    }
}
