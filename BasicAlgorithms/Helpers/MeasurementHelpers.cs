using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace BasicAlgorithms.Helpers
{
	public struct Result
	{
		public string Name;
		public double ElapsedMs;
	}

    public class MeasurementHelpers
    {
        public static void PrintResults(List<Result> results)
		{
			Console.WriteLine();
			PrintHeader("");
			PrintHeader("RESULTS!!!");
			PrintHeader("");

			foreach (var result in results)
			{
				Console.WriteLine($"{result.Name} took {result.ElapsedMs} milliseconds.");
			}
		}

        public static Result RunAndMeasureSearchAlgorithm(
			Func<int[], int, int> action,
			Action<int[]> printAction,
			Stopwatch watch,
			int[] a, int value)
		{
			Console.WriteLine($"Running {action.Method.Name}");

			watch.Restart();
			int result = action(a, value);
			watch.Stop();

			printAction?.Invoke(a);

			return new Result
			{
				Name = action.Method.Name,
				ElapsedMs = watch.Elapsed.TotalMilliseconds
			};
		}

		public static Result RunAndMeasureSortAlgorithm(
			Action<int[]> action,
			Action<int[]> printAction,
			Stopwatch watch,
			int[] a)
		{
			Console.WriteLine($"Running {action.Method.Name}");
			int[] b = (int[])a.Clone();

			watch.Restart();
			action(b);
			watch.Stop();

			printAction?.Invoke(b);

			return new Result
			{
				Name = action.Method.Name,
				ElapsedMs = watch.Elapsed.TotalMilliseconds
			};
		}

		private static void PrintHeader(string header)
		{
			int width = Console.WindowWidth - header.Length;
			string prettyPrint = new string('*', width / 2);
			string formattedHeader = prettyPrint + header + prettyPrint;
			Console.WriteLine(formattedHeader);
		}
    }
}
