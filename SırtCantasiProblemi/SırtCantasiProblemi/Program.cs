using System;
using System.IO;

namespace SırtCantasiProblemi
{
    class Program
    {

		public static int KnapSack(int capacity, int[] weight, int[] value, int itemsCount)
		{
			int[,] K = new int[itemsCount + 1, capacity + 1];

			for (int i = 0; i <= itemsCount; ++i)
			{
				for (int w = 0; w <= capacity; ++w)
				{
					if (i == 0 || w == 0)
						K[i, w] = 0;
					else if (weight[i - 1] <= w)
						K[i, w] = Math.Max(value[i - 1] + K[i - 1, w - weight[i - 1]], K[i - 1, w]);
					else
						K[i, w] = K[i - 1, w];
				}
			}

			return K[itemsCount, capacity];
		}
		static void Main(string[] args)
        {


			StreamReader sr = new StreamReader("C:\\Users\\Administrator\\Desktop\\items.txt");
			char[] c = null;
			c = new char[255];
			int[] number = sr.ReadBlock(c, 0, 15);
			
			Console.WriteLine(c);

			int[] value = { number[2,2], 100, 120 };
			int[] weight = { 10, 20, 30 };
			int capacity = 50;
			int itemsCount = 3;

			int result = KnapSack(capacity, weight, value, itemsCount);

			Console.WriteLine(result);
			

		

			
			Console.WriteLine(sr.ReadToEnd());

			Console.ReadKey();

		}
	}
}
