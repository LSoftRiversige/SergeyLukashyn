using ConsoleAppLab2_4.B2B;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppLab2_4
{
    public class DynamicExplore
    {
        //7. Dynamic & overflow
        //Исследовать явление arithmetic overflow в контексте использования dynamic
        //Объявим переменную типа dynamic и запишем в нее long.maxvalue  (dynamic dyn = long.MaxValue)
        //Объявить переменную типа int и через приведение типов присвоем ей значение прошлой переменной(int bigInt = (int)dyn)
        //Посмотреть значение одной и другой переменной.
        //Выполнить все это внутри блока checked и получить ошибку

        public void Run()
        {
            dynamic d = long.MaxValue;
            checked {
                int bigint = (int)d;
            }
        }
    }
}
