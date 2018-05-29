using System;

namespace ConsoleRunner
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Which program do you want to test?\n 1. UnionFind");
			int optionRequested = Convert.ToInt32(Console.ReadLine());
            IRunner runner;
            switch (optionRequested)
            {
                case 1:
                    runner = new UnionFindRunner();
                    break;
                default:
                    Console.WriteLine( "Invalid option, quiting program.");
                    return;
            }

            while(!runner.IsExitRequested)
            {
                runner.Run();
            }

        }
    }
}
