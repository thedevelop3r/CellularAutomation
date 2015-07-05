using System;

namespace CellularAutomation{
	public class Program
	{
		public static void Main(string[] args)
		{
			CellularAutomata map = new CellularAutomata (80, 22, new Random (System.DateTime.Now.Millisecond));
			map.RandomizeMap (30);
			map.DoSimulationSteps (10, 4, 3);
			map.PrintGraph ();
		}
	}
}
