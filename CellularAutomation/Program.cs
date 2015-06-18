using System;

namespace CellularAutomation
{
	class MainClass
	{
		//declare intial vars rows, columns,
		//and % random (probability of 
		//randomly setting coord true)
		static int rows = 22;
		static int columns = 80;
		static int percentRandom = 45;

		//everyone's favorite method
		public static void Main (string[] args)
		{
			
			//declare new matrix m x n
			Matrix map = new Matrix (rows, columns);

			//randomize matrix
			map.RandomizeMatrix (percentRandom);

			//set borders
			map.BordersOff ();

			//do x simulation steps
			for (int i = 0; i < 4; i++)
			{
				map.DoSimulationStep ();
			}

			//print final matrix
			map.PrintMatrix (map.ToImage ());
		}
	}
}
