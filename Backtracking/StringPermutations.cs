using System;
using System.Collections.Generic;

namespace Backtracking
{
    public class StringPermutations
    {
        public static List<string> GetPermutations(String s)
        {
            List<string> result = new List<string>();
            GetPermutationsUtil(result, s.ToCharArray(), 0, s.Length - 1);
            return result;
        }

        private static void swap(char[] arr, int i, int j)
        {
            char temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }

		private static void GetPermutationsUtil(List<String> result, char[] s, int start, int stop)
		{
            if(start == stop)
            {
                result.Add(new string(s));
            }

            for (int i = start; i <= stop; i++)
            {
                // Swap
                swap(s, i, start);
                //Permute on the remaining
                GetPermutationsUtil(result, s, start + 1, stop);
                swap(s, i, start);
            }
		}
    }
}
