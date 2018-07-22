using System;
using System.Collections.Generic;

namespace Backtracking
{
	public class AllSubsets
	{
		public static List<List<int>> GetAllSubsets(int[] set)
		{
			List<List<int>> result = new List<List<int>>();
            List<int> subset = new List<int>();
            result.Add(subset);
            GetAllSubsetsUtil(set, result, subset, 0);

			return result;
		}

		private static void swap(char[] arr, int i, int j)
		{
			char temp = arr[i];
			arr[i] = arr[j];
			arr[j] = temp;
		}

		private static void GetAllSubsetsUtil(int[] set, List<List<int>> result, List<int> subset, int index)
		{
            for (int i = index; i < set.Length; i++)
            {
                subset.Add(set[i]);
                result.Add(new List<int>(subset));
                GetAllSubsetsUtil(set, result, subset, i + 1);
                subset.Remove(set[i]);
			}
		}
	}
}
