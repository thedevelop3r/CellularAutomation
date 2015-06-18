using System;

namespace CellularAutomation
{
	public class Matrix
	{
		//declare vars: mapMatrix, matrix
		//rows, and matrix columns
		bool[,] mapMatrix;
		int rows;
		int columns;

		//defalt constructor- needs int rows
		//and columns
		public Matrix (int rows, int columns)
		{
			this.rows = rows;
			this.columns = columns;
			this.mapMatrix = new bool[rows, columns];
		}

		//converts boolean 2d array to string array for viewing
		public string[,] ToImage()
		{
			string[,] image = new string[rows,columns];

			for (int y = 0; y < rows; y++)
			{
				for (int x = 0; x < columns; x++)
				{
					if (mapMatrix [y, x] == true)
					{
						image [y, x] = "x";
					} else
					{
						image [y, x] = " ";
					}
				}
			}
			return image;
		}

		//prints 2d array in matrix form
		public void PrintMatrix(string [,] image)
		{
			for (int y = 0; y < rows; y++)
			{
				for (int x = 0; x < columns; x++)
				{
					Console.Write (image [y, x]);
				}
				Console.Write ("\n");
			}
		}

		//randomizes values in 2d boolean array
		public bool[,] RandomizeMatrix(int percentRandom)
		{
			Random r = new Random ();
		
			//iterate through all coords in 2d array and set true or false
			for (int y = 0; y < rows; y++)
			{
				for (int x = 0; x < columns; x++)
				{
					if (r.Next (100) < percentRandom)
					{
						mapMatrix [y, x] = true;
					} else
					{
						mapMatrix [y, x] = false;
					}
				}
			}
			return mapMatrix;
		}

		//gets number of cells around a given cell that hold true
		private int CountAliveNeighbors(bool[,] mapMatrix, int y, int x)
		{
			int aliveNeighbors = 0;

			//iterate through surrounding coords in 2d array and check if true
			for (int i = y-1; i < y+2; i++)
			{
				for (int j = x-1; j < x+2; j++) {
					if (mapMatrix [i, j] == true)
					{
						aliveNeighbors++;
					}
				}
			}
			return aliveNeighbors;
		}

		//generates new map according to rule: must have at least 4 living neighbors
		public bool[,] DoSimulationStep()
		{
			bool[,] newMapMatrix = mapMatrix;

			//iterate through all coords
			for (int y = 1; y < rows-1; y++)
			{
				for (int x = 1; x < columns-1; x++)
				{
					if (CountAliveNeighbors (mapMatrix, y, x) > 4)
					{
						newMapMatrix [y, x] = true;
					} else
					{
						newMapMatrix [y, x] = false;
					}		 
				}
			}
			return newMapMatrix;
		}

		//sets borders to false
		public bool[,] BordersOff()
		{
			bool[,] newMapMatrix = mapMatrix;

			//iterate through all coords on left and right
			for (int y = 0; y < rows; y += rows-1)
			{
				for (int x = 0; x < columns; x++)
				{
					newMapMatrix [y, x] = false;
				}
			}

			//iterate through all coords on top and bottom
			for (int x = 0; x < columns; x += columns-1)
			{
				for (int y = 0; y < rows; y++)
				{
					newMapMatrix [y, x] = false;
				}
			}
			return newMapMatrix;
		}

		//sets borders to true
		public  bool[,] BordersOn()
		{
			bool[,] newMapMatrix = mapMatrix;

			//iterate through coords on left and right
			for (int y = 0; y < rows; y += rows-1)
			{
				for (int x = 0; x < columns; x++)
				{
					newMapMatrix [y, x] = true;
				}
			}

			//iterate through coords on top and bottom
			for (int x = 0; x < columns; x += columns-1)
			{
				for (int y = 0; y < rows; y++)
				{
					newMapMatrix [y, x] = true;
				}
			}
			return newMapMatrix;
		}

	}
}

