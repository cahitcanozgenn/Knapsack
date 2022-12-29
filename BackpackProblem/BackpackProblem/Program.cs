using System;
using System.IO;

namespace BackpackProblem
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
			
			string dosyaIcerigi;
			using (StreamReader sr = new StreamReader("C:\\Users\\Administrator\\Desktop\\items.txt"))
			{
				dosyaIcerigi = sr.ReadToEnd();
			}

			Console.WriteLine(dosyaIcerigi);


			string line =dosyaIcerigi.Split('\n')[0];
			string line2 =dosyaIcerigi.Split('\n')[1];
			string line3 = dosyaIcerigi.Split('\n')[2];
			string line4 = dosyaIcerigi.Split('\n')[3];
			string line5 = dosyaIcerigi.Split('\n')[4];
			string line6 = dosyaIcerigi.Split('\n')[5];

            string[] colon = line2.Split(',');
			string[] colon2 = line3.Split(',');
			string[] colon3 = line4.Split(',');
			string[] colon4 = line5.Split(',');
			string[] colon5 = line6.Split(',');

			Console.WriteLine("**");


			string[] value =
			{
	           colon[0][0].ToString(),
	           colon2[0][0].ToString(),
	           colon3[0][0].ToString(),
	           colon4[0][0].ToString(),
	           colon5[0][0].ToString()
		};

			int[] values = new int[value.Length];

			for (int i = 0; i < value.Length; i++)
			{
				values[i] = int.Parse(value[i]);
			}
			
			string[] weight = 
			{
				colon[0][2]+colon[0][3].ToString(),
				colon2[0][2]+colon2[0][3].ToString(),
				colon3[0][2]+colon3[0][3].ToString(),
				colon4[0][2]+colon4[0][3].ToString(),
				colon5[0][2]+colon5[0][3].ToString()
			};

			int[] weights = new int[weight.Length];

			for (int i = 0; i < weight.Length; i++)
			{
				weights[i] = int.Parse(weight[i]);
			}

			int capacity = Convert.ToInt32(line);
			int itemsCount = 3;

			int result = KnapSack(capacity, weights, values, itemsCount);
		    Console.WriteLine(result);
		}
	}
}
