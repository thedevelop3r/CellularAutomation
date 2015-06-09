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

			for (int x = 0; x < rows; x++)
			{
				for (int y = 0; y < columns; y++)
				{
					if (mapMatrix [x, y] == true)
					{
						image [x, y] = "x";
					} else
					{
						image [x, y] = " ";
					}
				}
			}
			return image;
		}

		//prints 2d array in matrix form
		public void PrintMatrix(string [,] image)
		{
			for (int x = 0; x < rows; x++)
			{
				for (int y = 0; y < columns; y++)
				{
					Console.Write (image [x, y]);
				}
				Console.Write ("\n");
			}
		}

		//randomizes values in 2d boolean array
		public bool[,] RandomizeMatrix(int percentRandom)
		{
			Random r = new Random ();
		
			//iterate through all coords in 2d array and set true or false
			for (int x = 0; x < rows; x++)
			{
				for (int y = 0; y < columns; y++)
				{
					if (r.Next (100) < percentRandom)
					{
						mapMatrix [x, y] = true;
					} else
					{
						mapMatrix [x, y] = false;
					}
				}
			}
			return mapMatrix;
		}

		//gets number of cells around a given cell that hold true
		private int CountAliveNeighbors(bool[,] mapMatrix, int x, int y)
		{
			int aliveNeighbors = 0;

			//iterate through surrounding coords in 2d array and check if true
			for (int i = x-1; i < x+2; i++)
			{
				for (int j = y-1; j < y+2; j++) {
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
			for (int x = 1; x < rows-1; x++)
			{
				for (int y = 1; y < columns-1; y++)
				{
					if (CountAliveNeighbors (mapMatrix, x, y) > 4)
					{
						newMapMatrix [x, y] = true;
					} else
					{
						newMapMatrix [x, y] = false;
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
			for (int x = 0; x < rows; x += rows-1)
			{
				for (int y = 0; y < columns; y++)
				{
					newMapMatrix [x, y] = false;
				}
			}

			//iterate through all coords on top and bottom
			for (int y = 0; y < columns; y += columns-1)
			{
				for (int x = 0; x < rows; x++)
				{
					newMapMatrix [x, y] = false;
				}
			}
			return newMapMatrix;
		}

		//sets borders to true
		public  bool[,] BordersOn()
		{
			bool[,] newMapMatrix = mapMatrix;

			//iterate through coords on left and right
			for (int x = 0; x < rows; x += rows-1)
			{
				for (int y = 0; y < columns; y++)
				{
					newMapMatrix [x, y] = true;
				}
			}

			//iterate through coords on top and bottom
			for (int y = 0; y < columns; y += columns-1)
			{
				for (int x = 0; x < rows; x++)
				{
					newMapMatrix [x, y] = true;
				}
			}
			return newMapMatrix;
		}

	}
}

