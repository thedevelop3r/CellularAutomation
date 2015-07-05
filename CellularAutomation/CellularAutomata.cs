using System;

namespace CellularAutomation
{
	public class CellularAutomata
	{
		private int _width;
		private int _height;
		private Random _random;
		private string[,] _image;

		public bool[,] _mapArray { get; private set;}


		public CellularAutomata(int width, int height, Random random)
		{
			this._width = width;
			this._height = height;
			this._random = random;
			this._mapArray = new bool[this._width, this._height];
			this._image = new string[this._width,this._height];
		}


		//Convert boolean 2d array to string array
		private void ToImage()
		{

			for (int x = 0; x < _width; x++)
			{
				for (int y = 0; y < _height; y++)
				{
					if (_mapArray [x, y] == true)
					{
						_image [x, y] = "[]";
					} else
					{
						_image [x, y] = " ";
					}
				}
			}
		}

		//Prints 2d array in Graph form
		public void PrintGraph()
		{
			ToImage ();
			for (int y = _height-1; y >= 0; y--)
			{
				for (int x = 0; x < _width; x++)
				{
					Console.Write (_image [x, y]);
				}
				Console.Write ("\n");
			}
		}

		//Randomize values in 2d boolean array
		public void RandomizeMap(int percentRandom)
		{

			//iterate through all coords in 2d array
			for (int x = 0; x < _width; x++)
			{

				for (int y = 0; y < _height; y++)
				{                    
					if (_random.Next (100) < percentRandom)
					{
						_mapArray [x, y] = true;
					} else
					{
						_mapArray [x, y] = false;
					}
				}
			}
		}

		//gets number of cells around a given cell that hold true
		private int CountAliveNeighbors(bool[,] mapMatrix, int y, int x)
		{
			int aliveNeighbors = 0;

			//iterate through surrounding coords in 2d array and check if true
			if (x != 0 && y != 0)
			{
				for (int i = y - 1; i < y + 2; i++)
				{
					for (int j = x - 1; j < x + 2; j++)
					{
						if (mapMatrix[i, j] == true)
						{
							aliveNeighbors++;
						}
					}
				}
			}
			return aliveNeighbors;
		}

		public void DoSimulationSteps(int iterations, int birthLimit, int deathLimit)
		{
			bool[,] newMapArray = _mapArray;

			for (int i = 0; i < iterations; i++)
			{
				for (int x = 0; x < _width-1; x++)
				{
					for (int y = 0; y < _height-1; y++)
					{
						int neighbors = CountAliveNeighbors(_mapArray, x, y);
						// If a cell is alive and has too few neighbors, kill it.
						if (newMapArray[x, y])
						{
							if (neighbors < deathLimit)
							{
								newMapArray[x, y] = false;
							}
						}
						// If the cell is dead and it has enough neighbors to be born, create it.
						else
						{
							if (neighbors > birthLimit)
							{
								newMapArray[x, y] = true;
							}
						}
					}
				}
			}

			_mapArray = newMapArray;
		}

		public void PrintPercentTrue()
		{
			int trueValues = 0;
			for (int x = 0; x < _width; x++)
			{
				for (int y = 0; y < _height; y++)
				{
					if (_mapArray[x, y] == true)
					{
						trueValues++;
					}
				}
			}
			Console.WriteLine(100 * (double)trueValues / (double)(_width * _height));
		}			
	}
}

