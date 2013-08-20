using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using seagolf.Nouns;

namespace seagolf.Verbs
{
  public class Simulate
  {
    public static void Step( CellGrid input, CellGrid output )
    {
      // assume output is same size as input
      for( int iy = 0; iy < input.grid.GetLength(0); ++iy ) {
        for( int ix = 0; ix < input.grid.GetLength(1); ++ix ) {
          ApplyRule( input, output, ix, iy );
        }
      }
    }

    public static void ApplyRule( CellGrid input, CellGrid output, int x, int y )
    {
      int count = LiveNeighborCount( input, x, y );
      int value = Peek( input, x, y );
      if( value == 0 ) { // dead
        switch( count ) {
          // Any dead cell with exactly three live neighbours becomes a live cell, as if by reproduction.
          case 3: Poke( output, x, y, 1 ); break;
        }
      } else if( value == 1 ) { // alive
        switch( count ) {
          // Any live cell with fewer than two live neighbours dies, as if caused by under-population.
          case 1: Poke( output, x, y, 0 ); break;
          // Any live cell with two or three live neighbours lives on to the next generation.
          case 2: 
          case 3: break;
          // Any live cell with more than three live neighbours dies, as if by overcrowding.
          case 4:
          case 5:
          case 6:
          case 7:
          case 8: Poke( output, x, y, 0 ); break;
        }
      }
    }

    // defines neighborhood to check for each cell
    static readonly int[][] LOCALITY = new int[][]
    {
      new int[] { +1, +1 },
      new int[] { -1, -1 },
      new int[] { -1, +0 },
      new int[] { -1, +1 },
      new int[] { +0, -1 },
      new int[] { +0, +1 },
      new int[] { +1, -1 },
      new int[] { +1, +0 },
    };

    public static int LiveNeighborCount( CellGrid input, int x, int y )
    {
      int count = 0;
      foreach( int[] L in LOCALITY )
        count += (Peek( input, x + L[1], y + L[0] ) != 0)? 1 : 0;
      return count;
    }

    public static int Peek( CellGrid input, int x, int y )
    {
      if     ( x < 0 || x > input.grid.GetLength(0) )
        return 0; // off-grid: dead
      else if( y < 0 || y > input.grid.GetLength(1) )
        return 0; // off-grid: dead
      else
        return input.grid[ x, y ];
    }

    public static void Poke( CellGrid output, int x, int y, int value )
    {
      output.grid[ x, y ] = value;
    }
  }
}
