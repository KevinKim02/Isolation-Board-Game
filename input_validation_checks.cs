using System;
using static System.Console;
using static System.Math;

namespace Isolation
{
    static partial class Program
    {   
        static bool startPosTest1( string startPos )
        {
            if( startPos.Length != 2 )
            {
                WriteLine( "Please enter only 2 letters, each indicating a row and a column!" );
                return false;
            }
            else return true;
        }
        static bool startPosTest2( string startPos )
        {
            if( Array.IndexOf( letters, startPos.Substring( 0, 1 ) ) > rows  )
            {
                WriteLine( "Please enter a starting row within the game board!" );
                return false;
            }
            else if( Array.IndexOf( letters, startPos.Substring( 1, 1 ) ) > columns  )
            {          
                WriteLine( "Please enter a starting column within the game board!" );
                return false;
            }
            return true;
        }
        
        static bool startPosTest3( )
        {
            if( startPosA == startPosB )
            {
                if( startPosB.Length == 0 ) 
                    WriteLine( "Please enter a starting position, your default starting position is taken!" );
                else
                    WriteLine( "Your starting position is taken! Please enter another starting position." );
                return false;
            }
            else return true;
        }
        
        static bool test1( string inputMove )
        {
            if( inputMove.Length == 0 )                                            
            {
                WriteLine( "Please enter a move!" );
                return false;
            }
            else if( inputMove.Length != 4 )                                           
            {
                WriteLine( "Please enter only four letters!" );
                return false;
            }
            else if( ( Array.IndexOf( letters, inputMove.Substring( 0, 1 ) ) ) >= rows && ( Array.IndexOf( letters, inputMove.Substring( 1, 1 ) ) ) >= columns )
            {
                WriteLine( "Please enter a row and column within the game board!" );
                return false;
            }
            else if( Array.IndexOf( letters, inputMove.Substring( 0, 1 ) ) >= rows )
            {
                WriteLine( "Please enter a row within the game board!" );
                return false;
            }  
            else if( Array.IndexOf( letters, inputMove.Substring( 1, 1 ) ) >= columns ) 
            {
                WriteLine( "Please enter a column within the game board!" );
                return false;
            }
            return true;       
        }
        
        static bool test2( string inputMove, int sizeOfInput )
        {   
            for( int i = 0; i < sizeOfInput; i ++ )
            {
                if( inputMove.Substring( i, 1 ) != "a" && inputMove.Substring( i, 1 ) != "b" && inputMove.Substring( i, 1 ) != "c" && 
                    inputMove.Substring( i, 1 ) != "d" && inputMove.Substring( i, 1 ) != "e" && inputMove.Substring( i, 1 ) != "f" && 
                    inputMove.Substring( i, 1 ) != "g" && inputMove.Substring( i, 1 ) != "h" && inputMove.Substring( i, 1 ) != "i" && 
                    inputMove.Substring( i, 1 ) != "j" && inputMove.Substring( i, 1 ) != "k" && inputMove.Substring( i, 1 ) != "l" && 
                    inputMove.Substring( i, 1 ) != "m" && inputMove.Substring( i, 1 ) != "n" && inputMove.Substring( i, 1 ) != "o" && 
                    inputMove.Substring( i, 1 ) != "p" && inputMove.Substring( i, 1 ) != "q" && inputMove.Substring( i, 1 ) != "r" && 
                    inputMove.Substring( i, 1 ) != "s" && inputMove.Substring( i, 1 ) != "t" && inputMove.Substring( i, 1 ) != "u" && 
                    inputMove.Substring( i, 1 ) != "v" && inputMove.Substring( i, 1 ) != "w" && inputMove.Substring( i, 1 ) != "x" && 
                    inputMove.Substring( i, 1 ) != "y" && inputMove.Substring( i, 1 ) != "z" )
                {
                    WriteLine( "Please enter a lowercase letter!" );
                    return false;
                }
            }
            return true;
        }
        
        static bool test3( string inputMove, int totalMoveCounter )
        {
            if( playerATurn == true )
            {
                if( inputMove.Substring( 0, 1 ) == positionB.Substring( 0, 1 ) && inputMove.Substring( 1, 1 ) == positionB.Substring( 1, 1 ) )
                {
                    WriteLine( $"You cannot move into the position of {nameB}'s pawn!" );
                    return false;
                }
                else if( totalMoveCounter == 0 && inputMove.Substring( 0, 1 ) == startPosA.Substring( 0, 1 ) && inputMove.Substring( 1, 1 ) == startPosA.Substring( 1, 1 ) )
                {
                    WriteLine( "Please make a move outside of your starting position!" );
                    return false;
                }
                else if( inputMove.Substring( 0, 1 ) == positionA.Substring( 0, 1 ) && inputMove.Substring( 1, 1 ) == positionA.Substring( 1, 1 ) )
                {
                    WriteLine( "Please make a move outside of your current position!" );
                    return false;
                }    
                return true;
            }
            else
            {
                if( inputMove.Substring( 0, 1 ) == positionA.Substring( 0, 1 ) && inputMove.Substring( 1, 1 ) == positionA.Substring( 1, 1 ) )
                {
                    WriteLine( $"You cannot move into the position of {nameA}'s pawn!" );
                    return false;
                }   
                else if( totalMoveCounter == 0 && inputMove.Substring( 0, 1 ) == startPosB.Substring( 0, 1 ) && inputMove.Substring( 1, 1 ) == startPosB.Substring( 1, 1 ) )
                {
                    WriteLine( "Please make a move outside of your starting position!" );
                    return false;
                }
                else if( inputMove.Substring( 0, 1 ) == positionB.Substring( 0, 1 ) && inputMove.Substring( 1, 1 ) == positionB.Substring( 1, 1 ) )
                {
                    WriteLine( "Please make a move outside of your current position!" );
                    return false;
                }
                return true;
            }
        }
        static bool test4( string inputMove, string position )
        {
            if( ( int )Abs( Array.IndexOf( letters, position.Substring( 0, 1 ) ) - Array.IndexOf( letters, inputMove.Substring( 0, 1 ) ) ) > 1 ||
                ( int )Abs( Array.IndexOf( letters, position.Substring( 1, 1 ) ) - Array.IndexOf( letters, inputMove.Substring( 1, 1 ) ) ) > 1 )
            {
                WriteLine( "You can only move one space!" ); 
                return false;
            }
            else if( Array.IndexOf( letters, inputMove.Substring( 2, 1 ) ) >= rows || Array.IndexOf( letters, inputMove.Substring( 3, 1 ) ) >= columns )
            {
                WriteLine( "You cannot remove a tile that does not exist on the game board!" );
                return false;
            }
            else if( board[ Array.IndexOf( letters, inputMove.Substring( 0, 1 ) ), Array.IndexOf( letters, inputMove.Substring( 1, 1 ) ) ] == true )
            {
                WriteLine( "You cannot move to a removed tile!" );
                return false;
            }
            else if( inputMove.Substring( 2, 1 ) == inputMove.Substring( 0, 1 ) && inputMove.Substring( 3, 1 ) == inputMove.Substring( 1, 1 ) )
            {
                WriteLine( "You cannot remove the tile that you are moving to!" );
                return false;
            }
            return true;
        }

        static bool test5( string inputMove )
        {
            if( inputMove.Substring( 2, 1 ) == startPosA.Substring( 0, 1 ) && inputMove.Substring( 3, 1 ) == startPosA.Substring( 1, 1 ) )
            {
                if( playerATurn == true )
                    WriteLine( $"You cannot remove your own starting platform tile!" );
                else
                    WriteLine( $"You cannot remove {nameA}'s starting platform tile!" );
                return false;
            }
            else if( inputMove.Substring( 2, 1 ) == startPosB.Substring( 0, 1 ) && inputMove.Substring( 3, 1 ) == startPosB.Substring( 1, 1 ) )
            {
                if( playerATurn == true )
                    WriteLine( $"You cannot remove {nameB}'s starting platform tile!" );
                else
                    WriteLine( $"You cannot remove your own starting platform tile!" );
                return false;
            }
            else if( board[ ( Array.IndexOf( letters, inputMove.Substring( 2, 1 ) ) ), ( Array.IndexOf( letters, inputMove.Substring( 3, 1 ) ) ) ] == true )
            {
                WriteLine( "You cannot remove a tile that is already removed!" );
                return false;
            }
            return true;
        }


        static bool test6( string inputMove, string position )
        {
            if( inputMove.Substring( 2, 1 ) == position.Substring( 0, 1 ) && inputMove.Substring( 3, 1 ) == position.Substring( 1, 1 ) )
            {
                if( playerATurn == true )
                    WriteLine( $"You cannot remove the tile {nameB} is on!" );
                else
                    WriteLine( $"You cannot remove the tile {nameA} is on!" );
                return false;
            } 
            else return true;
        } 
    }
}