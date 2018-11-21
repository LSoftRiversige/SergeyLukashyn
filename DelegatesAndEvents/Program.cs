using System;

namespace DelegatesAndEvents
{
    class Program
    {
        static void Main(string[] args)
        {
            //var calculator = new Calculator();

            //Notification caller;
            //caller = calculator.DoDivision;
            //caller += calculator.DoMultiplication;
            //caller += calculator.DoSubstruction;
            //caller += calculator.DoSum;


            //caller.Invoke(1000, 500);

            //caller.Invoke(43124124, 2142134);

            //caller.Invoke(124123, 23424);


            Apartment.RunControl();


            Console.WriteLine("Press any key...");
            Console.ReadKey();
                        
        }
    }
}
