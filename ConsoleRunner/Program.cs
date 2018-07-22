using System;
using System.Collections.Generic;
using BasicAlgorithms.Helpers;
using BasicAlgorithms.Sorting;
using DataStructures;
using DataStructures.GraphProcessors;
using DynamicProgramming;
using Backtracking;

namespace ConsoleRunner
{
    class MainClass
    {
        // WILL BE SORTED OUT LATER
        public static void Main(string[] args)
        {
			GraphTestMethods gt = new GraphTestMethods();
            //Test DFS/BFS and Get Paths

            //Digraph g = gt.GenerateDirectedGraph();
            //BFSPaths bfsPaths = new BFSPaths(g, 2);

            //for (int i = 0; i < g.VertexCount; i++)
            //{
            //    bfsPaths.PrintPath(i);
            //    Console.WriteLine();
            //}

            //         Graph g = gt.GenerateUndirectedGraphForConnectedComponents();
            //         //ConnectedComponents cc = new ConnectedComponents(g);
            //         //cc.PrintConnectedComponents();

            //         FindCycleUndirectedGraph fcu = new FindCycleUndirectedGraph(g);
            //         Console.WriteLine($"Does this graph have a cycle: {fcu.HasCycle}.");

            //         g = gt.GenerateUndirectedGraph();
            //         fcu = new FindCycleUndirectedGraph(g);
            //Console.WriteLine($"Does this graph have a cycle: {fcu.HasCycle}.");

            Digraph g = gt.GenerateDirectedAcyclicGraph();
            FindCycleDirectedGraph fcd = new FindCycleDirectedGraph(g);
            Console.WriteLine($"Does directed graph have a cycle; {fcd.HasCycle}");

            g = gt.GenerateDirectedCyclicGraph();
            fcd = new FindCycleDirectedGraph(g);
            Console.WriteLine($"Does directed graph have a cycle; {fcd.HasCycle}");
                     Console.WriteLine("The cycle is: ");
                     fcd.PrintCycle();

            g = gt.GenerateDirectedCyclicSelfLoopGraph();
            fcd = new FindCycleDirectedGraph(g);
            Console.WriteLine($"Does directed graph have a cycle; {fcd.HasCycle}");
            Console.WriteLine("The cycle is: ");
            fcd.PrintCycle();

            //Digraph g = gt.GenerateDirectedAcyclicGraphForTopologicalSort();
            //TopologicalSort topSort = new TopologicalSort(g);
            //Console.WriteLine("The topological order is: ");
            //topSort.PrintTopologicalOrder();

            //Console.WriteLine("Enter the size of the random array you want to generate");
            //int size = Convert.ToInt32(Console.ReadLine());
            //int[] a = ArrayHelper.GenerateRandomIntegerArray(size);
            //ArrayHelper.PrintArray<int>(a);
            //Sorters.HeapSort(a);
            //ArrayHelper.PrintArray<int>(a);


            //        int[] a = { 5, 4, 3, 2, 1 };
            //        MinHeap heap = new MinHeap(a);
            //        bool isExitRequested = false;
            //        while(!isExitRequested)
            //        {
            //            Console.WriteLine(" What do you want to so");
            //            Console.WriteLine("1. Add an element\n2.Remove the minimum element\n3.Print the heap");
            //            int optionSelected = 0;
            //int value = 0;
            //           try
            //           {
            //optionSelected = Convert.ToInt32(Console.ReadLine());

            //    }
            //    catch (Exception ex)
            //    {
            //        isExitRequested = true;
            //        continue;
            //    }

            //    switch(optionSelected)
            //    {
            //        case 1:
            //            Console.WriteLine("Enter the element you would like to insert");
            //            value = Convert.ToInt32(Console.ReadLine());
            //            heap.Insert(value);
            //            break;
            //        case 2:
            //            value = heap.RemoveMin();
            //            Console.WriteLine($"The minimum value is {value}");
            //            break;
            //        case 3:
            //            heap.PrintHeap();
            //            break;
            //        default:
            //            isExitRequested = true;
            //            break;
            //    }
            //}



            //         int[] coins = { 1, 5, 10, 25 };
            //         int amount = 1;
            //         var minCount = MinimumCoinChange.Recursive(coins, 1);
            //         Console.WriteLine($"{nameof(minCount)}:{minCount} for {nameof(amount)}: {amount}");
            //amount = 6;
            //minCount = MinimumCoinChange.Recursive(coins, 6);
            //Console.WriteLine($"{nameof(minCount)}:{minCount} for {nameof(amount)}: {amount}");
            //amount = 49;
            //minCount = MinimumCoinChange.Recursive(coins, 49);
            //Console.WriteLine($"{nameof(minCount)}:{minCount} for {nameof(amount)}: {amount}");

            //         while(true)
            //         {
            //	Console.WriteLine("Enter the fibonacci number that you need.");
            //	int n = Convert.ToInt32(Console.ReadLine());    
            //             Console.WriteLine($"Recursive result: {Fibonacci.Recursive(n)}");
            //             Console.WriteLine($"TopDown DP result: {Fibonacci.TopDownDP(n)}");
            //	Console.WriteLine($"BottomUp DP result: {Fibonacci.BottomUpDp(n)}");
            //}



            //int[] a = { 7, 76, 11, 65, 27, 19, 56, 23, 50, 80 };
            //ArrayHelper.PrintArray<int>(a);
            //Sorters.QuickSort(a);
            //ArrayHelper.PrintArray<int>(a);
            //Heap minHeap = new Heap(a, false);
            //int[] sorted = minHeap.HeapSort();
            //for (int i = 0; i < sorted.Length; i++)
            //{
            //    Console.WriteLine(sorted[i]);
            //}


            //         Console.WriteLine("Which program do you want to test?\n 1. UnionFind\n 2.Sort\n");
            //int optionRequested = Convert.ToInt32(Console.ReadLine());
            //IRunner runner;
            //switch (optionRequested)
            //{
            //    case 1:
            //        runner = new UnionFindRunner();
            //        break;
            //    case 2:
            //        runner = new SortRunner();
            //        break;
            //    default:
            //        Console.WriteLine( "Invalid option, quiting program.");
            //        return;
            //}

            //while(!runner.IsExitRequested)
            //{
            //    runner.Run();
            //}

        }
    }
}
