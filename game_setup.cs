using System;
using static System.Console;

namespace Isolation
{
    static partial class Program
    {   
        static void Initialize( ) 
        {
            Write( "Enter your name [default Player A]: " );
            string inputNameA = ReadLine( );
            if( inputNameA.Length == 0 ) nameA = "Player A"; // Default name for first player.
            else nameA = inputNameA;
            WriteLine( $"Name: {nameA}" );
            WriteLine( );
            
            Write( "Enter your name [default Player B]: " );
            string inputNameB = ReadLine( );
            if( inputNameB.Length == 0 ) nameB = "Player B"; // Default name for second player.
            else nameB = inputNameB;
            WriteLine( $"Name: {nameB}" );
            WriteLine( );
            
            int gameRows = 6; // Default row setting for game board.
            bool isValid = false;
            
            // Loops for user input until input for rows is valid.
            while( isValid == false)
            {
                Write( "Enter the desired number of rows on game board [default 6]: " );
                string inputBoardRows = ReadLine( );
                if( inputBoardRows.Length == 0 )
                {
                    isValid = true;
                    WriteLine( $"Board Rows: {gameRows}" );
                }
                else 
                {
                    gameRows = int.Parse( inputBoardRows );
                    if( gameRows < 4 || gameRows > 26 ) 
                    {
                        WriteLine( "Please enter a value between 4 and 26!" ); // Restriction for number of rows on game board.
                    }
                    else 
                    {
                        isValid = true;
                        WriteLine( $"Board Rows: {gameRows}" );
                    }
                }
                WriteLine( );
            }
            rows = gameRows;
            
            int gameColumns = 8; // Default column setting for game board.
            isValid = false;
            
            // Loops for user input until input for columns is valid.
            while( isValid == false)
            {
                Write( "Enter the desired number of columns on game board [default 8]: " );
                string inputBoardColumns = ReadLine( ); 
                if( inputBoardColumns.Length == 0 ) 
                {
                    isValid = true;
                    WriteLine( $"Board Columns: {gameColumns}" );
                }
                else 
                {
                    gameColumns = int.Parse( inputBoardColumns );
                    if( gameColumns < 4 || gameColumns > 26 ) 
                    {
                        WriteLine( "Please enter a value between 4 and 26!" ); // Restriction for number of columns on game board.
                    }
                    else 
                    {
                        isValid = true;
                        WriteLine( $"Board Rows: {gameColumns}" );
                    }  
                }
                WriteLine( );
            }
            columns = gameColumns;
            isValid = false;
            board = new bool[ rows, columns ];
            
            // Display instructions for move input.
            WriteLine( "~ You have created a game board within a size that allows every letter of the alphabet to represent each row and column." );
            WriteLine( "~ From now on, you will use letters to define your starting position, as well as your moves." );
            WriteLine( "~ In progressive order, letter 'a' represents the first row/column, letter 'b' represents the second row/column, and so on." );
            WriteLine( "~ For the starting position, enter two lowercase letters without spaces." ); 
            WriteLine( "~ The first letter represents the desired row for your starting position" );
            WriteLine( "~ The second letter represents the desired column for your starting position." );
            
            // Loops for user input until player A's input for their starting position is valid.
            while( isValid == false )
            {
                WriteLine( );
                Write( $"{nameA}, please enter a desired starting position on the game board [default is middle row, first column]: " );
                startPosA = ReadLine( );
                WriteLine( );
                
                if( startPosA.Length == 0 ) // Default starting position for player A.
                {
                    if( rows % 2 != 0 ) 
                    {
                        startPosA = letters[ ( rows / 2 ) ] + "a";
                        positionA = startPosA;
                    }
                    else // If number of rows on game board is even, starting position will always be the row where the quotient is rounded down.
                    {
                        startPosA = letters[ ( rows / 2 - 1 )  ] + "a"; 
                        positionA = startPosA;
                    }
                    isValid = true;
                }
                else
                {
                    if( startPosTest1( startPosA ) )
                        if( test2( startPosA, 2 ) )
                            if( startPosTest2( startPosA ) )
                                isValid = true;
                } 

                if( isValid )
                {
                    positionA = startPosA;
                    WriteLine( $"Starting Position: {startPosA}" );
                }
            }
            isValid = false;    
                
            // Loops for user input until player B's input for their starting position is valid.   
            while( isValid == false )
            {
                WriteLine( );
                Write( $"{nameB}, please enter a desired starting position on the game board [default is middle row, last column]: " );
                startPosB = ReadLine( );
                WriteLine( );
                
                if( startPosB.Length == 0 ) // Default starting position for player B.
                {
                    if( rows % 2 != 0 )
                    {
                        startPosB = letters[ ( rows / 2 ) ] + letters[ columns - 1 ];
                        positionB = startPosB;
                    }
                    else // If number of rows on game board is even, starting position will always be the row where the quotient is rounded up. 
                    {
                        startPosB = letters[ ( rows / 2 ) ] + letters[ columns - 1 ];
                        positionB = startPosB;
                    }
                    isValid = true;
                } 
                else
                {
                    if( startPosTest1( startPosB ) )
                        if( test2( startPosB, 2 ) )
                            if( startPosTest2( startPosB ) )
                                if( startPosTest3( ) )
                                    isValid = true;
                }
                      
                if( isValid )
                {
                    positionB = startPosB;
                    WriteLine( $"Starting Position: {startPosB}" );
                }
            }
        }
    }
}
