using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BasicAlgorithms.UnionFind;

namespace ConsoleRunner
{
    public class UnionFindRunner : IRunner
    {
        List<IUnionFind> unionFindImpementations;
        public bool IsExitRequested { get; set; }
        public UnionFindRunner()
        {
			unionFindImpementations = new List<IUnionFind>();
            IsExitRequested = false;

			Console.WriteLine("Welcome to the UnionFind program\n How many elements do you want?");
			int count = Convert.ToInt32(Console.ReadLine());

			unionFindImpementations.Add(new QuickFind(count));
			unionFindImpementations.Add(new QuickUnion(count));
			unionFindImpementations.Add(new WeightedQUF(count));
			unionFindImpementations.Add(new WeightedQUFWithPathCompression(count));
        }


        public void Run()
        {
            Console.WriteLine("What would you like to do? Enter any opther option to quit\n1. Find element\n2. Are elements connected?\n3. Connect 2 elements \n4. Count of connected components\n5. Print Array");
            var optionRequested = Console.ReadLine();
            int value1, value2;
            switch (optionRequested)
            {
                case "1": 
                    Console.WriteLine("Enter the element that you would like to find");
                    value1 = Convert.ToInt32(Console.ReadLine());
                    Find(value1);
                    break;
				case "2":
					Console.WriteLine("Enter the 2 elements for which you want to know if they are connected");
					value1 = Convert.ToInt32(Console.ReadLine());
                    value2 = Convert.ToInt32(Console.ReadLine());
					Connected(value1, value2);
					break;
				case "3":
					Console.WriteLine("Enter the 2 elements that you want to connect");
					value1 = Convert.ToInt32(Console.ReadLine());
					value2 = Convert.ToInt32(Console.ReadLine());
					Union(value1, value2);
					break;
                case "4":
                    Count();
                    break;
                case "5":
                    Print();
                    break;
                default:
                    IsExitRequested = true;
                    break;
            }
        }

        private void Find(int p)
        {
            foreach (var item in unionFindImpementations)
            {
                int result = item.Find(p);
                string output = result == -1 ? "Not found" : Convert.ToString(result);
                Console.WriteLine($"{item.GetType().Name}, Result = {output}");
            }
        }


		private void Connected(int p, int q)
		{
			foreach (var item in unionFindImpementations)
			{
                Console.WriteLine($"{item.GetType().Name}, Result = {item.Connected(p,q)}");
			}
		}

		private void Union(int p, int q)
		{
			foreach (var item in unionFindImpementations)
			{
				item.Union(p,q);
			}
		}
		private void Count()
		{
			foreach (var item in unionFindImpementations)
			{
                Console.WriteLine($"{item.GetType().Name}, Count = {item.Count}");
			}
		}

		private void Print()
		{
			foreach (var item in unionFindImpementations)
			{
				Console.WriteLine($"{item.GetType().Name}");
                item.Print();
			}
		}
    }
}
