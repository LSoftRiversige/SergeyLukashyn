using System;

namespace ConsoleAppLab2_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Run();

           //try
           //{
           //    Run();
           //}
           //catch (Exception e)
           //{
           //    Console.WriteLine($"{e.Message}");
           //}
            
            Console.WriteLine();
            Console.WriteLine("Press any key...");
            Console.ReadKey();
        }

        private static void Run()
        {
            //new GuidExample().Run();
            //new TimeExample().Run();
            //new NestedAndTupleExample().Run();
            new B2B.B2b().Run();
            //new DynamicExplore().Run();
            //new CastExplore().Run();
        }
    }
}