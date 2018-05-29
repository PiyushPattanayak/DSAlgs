using System;
using System.Collections.Generic;
using System.Diagnostics;
using BasicAlgorithms.Helpers;
using BasicAlgorithms.Sorting;

namespace ConsoleRunner
{
    public class SortRunner : IRunner
    {
		private int[] a;
		private Stopwatch watch;
		public bool IsExitRequested { get; set; }

        public SortRunner()
        {
            IsExitRequested = false;
            Console.WriteLine("Enter the number of elements in the array");
            int size = Convert.ToInt32(Console.ReadLine());
    		a = ArrayHelper.GenerateRandomIntegerArray(size);
    		watch = new Stopwatch();
            Console.WriteLine("Initital Array");
            ArrayHelper.PrintArray<int>(a);
        }

    	public void Run()
    	{
    		List<Result> results = new List<Result>();
            Action<int[]> printAction = ArrayHelper.PrintArray<int>;
            results.Add(MeasurementHelpers.RunAndMeasureSortAlgorithm(Sorters.SelectionSort, printAction, watch, a));
            results.Add(MeasurementHelpers.RunAndMeasureSortAlgorithm(Sorters.BubbleSort, printAction, watch, a));
            results.Add(MeasurementHelpers.RunAndMeasureSortAlgorithm(Sorters.InsertionSort, printAction, watch, a));
            results.Add(MeasurementHelpers.RunAndMeasureSortAlgorithm(Sorters.MergeSort, printAction, watch, a));
            results.Add(MeasurementHelpers.RunAndMeasureSortAlgorithm(Sorters.QuickSort, printAction, watch, a));
            results.Add(MeasurementHelpers.RunAndMeasureSortAlgorithm(Sorters.QuickSortWithDuplicates, printAction, watch, a));

            MeasurementHelpers.PrintResults(results);
            IsExitRequested = true;
    	}
    }


}
