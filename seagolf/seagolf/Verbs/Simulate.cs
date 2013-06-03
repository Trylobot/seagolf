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

    }

    public static void ApplyRule( CellGrid input, CellGrid output, int x, int y )
    {

    }

    public static int LiveNeighborCount( CellGrid input, int x, int y )
    {
      // delta (y, x)
      static readonly int[,] LOCALITY = new int[,] {
        { -1, -1 },
        { -1, 0 },
        { -1, 1 },
        { 0, -1 },
        { 0, 0 },
        { 0, 1 },
        { 1, -1 },
        { 1, 0 },
        { 1, 1 },
      };
      
      int count = 0;
      foreach( int[] L in LOCALITY ) {
        int value = Peek( input, x + L[1], y + L[0] );
        count += value;
      }
      return count;
    }

    public static int Peek( CellGrid input, int x, int y )
    {
      
    }

    public static void Poke( CellGrid output, int x, int y, int value )
    {

    }
  }
}
