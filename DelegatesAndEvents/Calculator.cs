using System;
using System.Collections.Generic;
using System.Text;

namespace DelegatesAndEvents
{
    //Кейс по делегатам
    //Создать класс калькулятор с методами DoSum, DoSubstraction, DoDivision, DoMultiplication.Каждый из них принимает два инта и возвращает дабл.
    //Создать делегат примающий два инта и возвращающий дабл.
    //Создать инстанс делегата и записать в его invocation list указанные четыре метода калькулятора. 
    //Вызвать методы из инвокейшн листа делегата через его метод Invoke (передать в Invoke пару переменных типа инт)
    public class Calculator
    {
        public double DoSum(int x, int y)
        {
            double r = x + y;
            Console.WriteLine($"{r}");
            return r;
        }

        public double DoDivision(int x, int y)
        {
            double r= x / y;
            Console.WriteLine($"{r}");
            return r;
        }

        public double DoSubstruction(int x, int y)
        {
            double r= x - y;
            Console.WriteLine($"{r}");
            return r;
        }
        public double DoMultiplication(int x, int y)
        {
            double r= x * y;
            Console.WriteLine($"{r}");
            return r;
        }
        
    }

    public delegate double Notification(int x, int y);

}
