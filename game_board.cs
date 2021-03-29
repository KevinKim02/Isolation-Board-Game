using System;
using static System.Console;
using static System.Math;

namespace Isolation
{
    static partial class Program
    { 
        static void DrawGameBoard( )
        {   
            const string h  = "\u2500"; // horizontal line
            const string v  = "\u2502"; // vertical line
            const string tl = "\u250c"; // top left corner
            const string tr = "\u2510"; // top right corner
            const string bl = "\u2514"; // bottom left corner
            const string br = "\u2518"; // bottom right corner
            const string vr = "\u251c"; // vertical join from right
            const string vl = "\u2524"; // vertical join from left
            const string hb = "\u252c"; // horizontal join from below
            const string ha = "\u2534"; // horizontal join from above
            const string hv = "\u253c"; // horizontal vertical cross
            const string sp = " ";      // space
            const string pa = " A ";    // pawn A
            const string pb = " B ";    // pawn B
            const string bb = "\u25a0"; // block
            const string fb = "\u2588"; // full block
            const string lh = "\u258c"; // left half block
            const string rh = "\u2590"; // right half block
            
            //Draw top labels.            
            Write( "    " );
            for( int c = 0; c < board.GetLength( 1 ); c ++ ) Write( " {0}  ", letters[ c ] );
            WriteLine( );
            
            // Draw the top board boundary.
            Write( "   " );
            for( int c = 0; c < board.GetLength( 1 ); c ++ )
            {
                if( c == 0 ) Write( tl );
                Write( "{0}{0}{0}", h );
                if( c == board.GetLength( 1 ) - 1 ) Write( "{0}", tr ); 
                else                                Write( "{0}", hb );
            }
            WriteLine( );
            
            // Draw the board rows.
            for( int r = 0; r < board.GetLength( 0 ); r ++ ) // 'r' represents the rows of the board[ , ] array.
            {
                Write( " {0} ", letters[ r ] );
                
                // Draw the row contents.
                for( int c = 0; c < board.GetLength( 1 ); c ++ ) // 'c' represents the columns of the board[ , ] array.
                { 
                    Here:
                    if( c == 0 ) Write( v );
                    
                    // If player A moves into a starting platform.
                    if( moveA.Length == 4 && firstMoveForA == false && r == Array.IndexOf( letters, moveA.Substring( 0, 1 ) ) 
                                                                    && c == Array.IndexOf( letters, moveA.Substring( 1, 1 ) ) ) 
                    {
                        if( moveA.Substring( 0, 1 ) == startPosA.Substring( 0, 1 ) && 
                            moveA.Substring( 1, 1 ) == startPosA.Substring( 1, 1 ) )   // If player A moves back into their own starting platform.
                        {
                            Write( "{0}{1}", pa, v );
                            if( Array.IndexOf( letters, startPosA.Substring( 1, 1 ) ) != board.GetLength( 1 ) - 1 ) // Addressing the error caused when starting position is on the last column of the game board.
                                c ++;
                            else 
                                break;
                        }
                        else if( moveA.Substring( 0, 1 ) == startPosB.Substring( 0, 1 ) && 
                                 moveA.Substring( 1, 1 ) == startPosB.Substring( 1, 1 ) )   // If player A moves into player B's starting platform.
                        {
                            Write( "{0}{1}", pa, v );
                            if( Array.IndexOf( letters, startPosB.Substring( 1, 1 ) ) != board.GetLength( 1 ) - 1 ) 
                                c ++;
                            else
                                break;
                        }
                    }
                    
                    // If player B moves into a starting platform.
                    if( moveA.Length == 4 && firstMoveForB == false && r == Array.IndexOf( letters, moveB.Substring( 0, 1 ) ) 
                                                                    && c == Array.IndexOf( letters, moveB.Substring( 1, 1 ) ) )
                    {
                        if( moveB.Substring( 0, 1 ) == startPosA.Substring( 0, 1 ) && 
                            moveB.Substring( 1, 1 ) == startPosA.Substring( 1, 1 ) )   // If player B moves into player A's starting platform.
                        {
                            Write( "{0}{1}", pb, v );
                            if( Array.IndexOf( letters, startPosA.Substring( 1, 1 ) ) != board.GetLength( 1 ) - 1 )
                                c ++; 
                            else 
                                break;
                        }
                        else if( moveB.Substring( 0, 1 ) == startPosB.Substring( 0, 1 ) && 
                                 moveB.Substring( 1, 1 ) == startPosB.Substring( 1, 1 ) )   // If player B moves back into their own starting platform.
                        {
                            Write( "{0}{1}", pb, v );
                            if( Array.IndexOf( letters, startPosB.Substring( 1, 1 ) ) != board.GetLength( 1 ) - 1 )
                                c ++; 
                            else 
                                break;
                        }
                    }
                    
                    // Display at and of the starting platform locations.
                    if( firstMoveForA == true && r == Array.IndexOf( letters, startPosA.Substring( 0, 1 ) ) 
                                              && c == Array.IndexOf( letters, startPosA.Substring( 1, 1 ) ) ) // Displaying player A's pawn on their starting platform before first move is made.
                    {
                        Write( pa + v );
                        if( startPosA.Substring( 0, 1 ) == startPosB.Substring( 0, 1 ) &&                                                                           // Addressing the error where if both starting positions are in the same row and
                            ( int )Abs( Array.IndexOf( letters, startPosA.Substring( 1, 1 ) ) - Array.IndexOf( letters, startPosB.Substring( 1, 1 ) ) ) == 1 ) // beside each other, the pawn on the starting position on the right is not displayed.
                        {    
                            c ++;
                            goto Here;
                        }
                        else if( Array.IndexOf( letters, startPosA.Substring( 1, 1 ) ) != board.GetLength( 1 ) - 1 )
                            c ++;
                        else
                           break;
                    }
                    else if( firstMoveForB == true && r == Array.IndexOf( letters, startPosB.Substring( 0, 1 ) ) 
                                                   && c == Array.IndexOf( letters, startPosB.Substring( 1, 1 ) ) ) // Displaying player B's pawn on their starting platform before first move is made.
                    {
                        Write( pb + v );
                        if( startPosA.Substring( 0, 1 ) == startPosB.Substring( 0, 1 ) &&                                                                           
                            ( int )Abs( Array.IndexOf( letters, startPosA.Substring( 1, 1 ) ) - Array.IndexOf( letters, startPosB.Substring( 1, 1 ) ) ) == 1 ) 
                        {
                            c ++;
                            goto Here;
                        }
                        else if( Array.IndexOf( letters, startPosB.Substring( 1, 1 ) ) != board.GetLength( 1 ) - 1 ) 
                            c ++;
                        else
                            break;
                    }
                    else if( firstMoveForA == false && r == Array.IndexOf( letters, startPosA.Substring( 0, 1 ) ) 
                                                    && c == Array.IndexOf( letters, startPosA.Substring( 1, 1 ) ) ) // Displaying player A's starting platform after first move is made.
                    {
                        Write( "{0}{1}{0}{2}", sp, bb, v );
                        if( startPosA.Substring( 0, 1 ) == startPosB.Substring( 0, 1 ) &&                                                                           // Addressing the error where if both starting positions are in the same row and
                            ( int )Abs( Array.IndexOf( letters, startPosA.Substring( 1, 1 ) ) - Array.IndexOf( letters, startPosB.Substring( 1, 1 ) ) ) == 1 ) // beside each other, starting platform on the right is not displayed.
                        {    
                            c ++;
                            goto Here;
                        }
                        else if( Array.IndexOf( letters, startPosA.Substring( 1, 1 ) ) != board.GetLength( 1 ) - 1 ) 
                            c ++; 
                        else 
                            break;
                    }
                    else if( firstMoveForB == false && r == Array.IndexOf( letters, startPosB.Substring( 0, 1 ) ) 
                                                    && c == Array.IndexOf( letters, startPosB.Substring( 1, 1 ) ) ) // Displaying player B's starting platform after first move is made.
                    {
                        Write( "{0}{1}{0}{2}", sp, bb, v );
                        if( startPosA.Substring( 0, 1 ) == startPosB.Substring( 0, 1 ) && 
                            ( int )Abs( Array.IndexOf( letters, startPosA.Substring( 1, 1 ) ) - Array.IndexOf( letters, startPosB.Substring( 1, 1 ) ) ) == 1 )
                        {
                            c ++;
                            goto Here;
                        }    
                        else if( Array.IndexOf( letters, startPosB.Substring( 1, 1 ) ) != board.GetLength( 1 ) - 1 )
                            c ++; 
                        else 
                            break;
                    }
                    
                    // Display of pawn on every space in game board (except starting platforms).
                    if( moveA.Length == 4 && r == Array.IndexOf( letters, moveA.Substring( 0, 1 ) ) 
                                          && c == Array.IndexOf( letters, moveA.Substring( 1, 1 ) ) ) // Displaying pawn A.
                    {   
                        Write( pa + v );
                        if( Array.IndexOf( letters, moveA.Substring( 1, 1 ) ) != board.GetLength( 1 ) - 1 )
                        {
                            c ++;
                            goto Here;
                        }
                        else 
                            break;
                    }
                    else if( moveB.Length == 4 && r == Array.IndexOf( letters, moveB.Substring( 0, 1 ) ) 
                                               && c == Array.IndexOf( letters, moveB.Substring( 1, 1 ) ) ) // Displaying pawn B.
                    {   
                        Write( pb + v );
                        if( Array.IndexOf( letters, moveB.Substring( 1, 1 ) ) != board.GetLength( 1 ) - 1 )
                        {
                            c ++;
                            goto Here;
                        }
                        else 
                            break;
                    }
                    
                    // Setting board[ r, c ] to true for all of player A's moves so that when the program reaches line ___, it either displays a tile or empty space.
                    if( blockRemovalA == true ) 
                        board[ Array.IndexOf( letters, moveA.Substring( 2, 1 ) ), Array.IndexOf( letters, moveA.Substring( 3, 1 ) ) ] = true;
                    
                    // Setting board[ r, c ] to true for all of player B's moves so that when the program reaches line ___, it either displays a tile or empty space.
                    if( blockRemovalB == true ) 
                        board[ Array.IndexOf( letters, moveB.Substring( 2, 1 ) ), Array.IndexOf( letters, moveB.Substring( 3, 1 ) ) ] = true;
                    
                    // Determines if a tile or empty space is displayed.
                    if( board[ r, c ] ) Write( "{0}{0}{0}{1}", sp, v );
                    else                Write( "{0}{1}{2}{3}", rh, fb, lh, v );
                }
                WriteLine( );
                
                // Draw the boundary after the row.
                if( r != board.GetLength( 0 ) - 1 )
                { 
                    Write( "   " );
                    for( int c = 0; c < board.GetLength( 1 ); c ++ )
                    {                
                        if( c == 0 )
                        {
                            Write( vr );
                        }
                        Write( "{0}{0}{0}", h );
                        if( c == board.GetLength( 1 ) - 1 ) Write( "{0}", vl ); 
                        else                                Write( "{0}", hv );
                    }
                    WriteLine( );
                }
                else
                {
                    Write( "   " );
                    for( int c = 0; c < board.GetLength( 1 ); c ++ )
                    {
                        
                        if( c == 0 ) 
                        {
                            Write( bl );
                        }
                        Write( "{0}{0}{0}", h );
                        if( c == board.GetLength( 1 ) - 1 ) Write( "{0}", br ); 
                        else                                Write( "{0}", ha );
                    }
                    WriteLine( );
                }
            }
        }
    }
}