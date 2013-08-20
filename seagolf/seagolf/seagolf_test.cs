using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using seagolf.Nouns;
using seagolf.Verbs;

namespace seagolf.Test
{
	public class TestProgram
	{
		public static void Main()
		{
			var frame0 = new CellGrid();
			frame0.grid = new int[20,20];

			var frame1 = new CellGrid();
			frame1.grid = new int[20,20];

			frame0.grid[0,1] = 1;
			frame0.grid[1,2] = 1;
			frame0.grid[2,0] = 1;
			frame0.grid[2,1] = 1;
			frame0.grid[2,2] = 1;

            print_CellGrid( frame0 );
			for( var i = 0; i < 50; ++i ) {
				var f =       (i % 2 == 0)? frame0 : frame1;
				var f_prime = (i % 2 == 0)? frame1 : frame0;
                print_CellGrid( f_prime );
			}

            Console.ReadLine();
        }

		public static void print_CellGrid( CellGrid input )
		{
      // assume output is same size as input
      System.Console.WriteLine("");
      for( int iy = 0; iy < input.grid.GetLength(0); ++iy ) {
        for( int ix = 0; ix < input.grid.GetLength(1); ++ix ) {
          System.Console.Write( (input.grid[ ix, iy ] == 1)? "█" : " " );
        }
        System.Console.WriteLine("");
      }
		}
	}
}