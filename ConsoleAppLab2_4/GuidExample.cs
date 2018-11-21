using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppLab2_4
{
    //1. Работа с Guid
    public class GuidExample
    {
        public void Run()
        {
            //Сгенерировать пустой гуид
            Guid empty = Guid.Empty;

            //Сгенерировать новый гуид
            Guid newGuid = Guid.NewGuid();

            //Привести гуид к строке и записать в переменную типа стринг
            string strGuid = newGuid.ToString();

            //Изменить строку по своему усмотрению(помнить о формате гуида - 32 символа 0-F с дефисами)
            Console.WriteLine(strGuid);
            Change(ref strGuid);
            Console.WriteLine(strGuid);

            //СОздать переменную типа гуид, распарсить строку полученную ранее и записать в созданную переменную.
            Guid guid1 = Guid.Parse(strGuid);
            Console.WriteLine(guid1);

            //Повторить предыдущий пункт через try parse, притом инициализировать переменную 
            //в аргументе метода try parse как out параметр, а сам метод Guid.TryParse поместить в if как условие. 
            //        Если условие выполнено и строка распаршено успешно - вывести гуид на экран с сообщение Parsed 
            //    successfully, если нет - вывести сообщение "String is not a valid guid"

            strGuid = "kjashaksjfhaslkjfhasklj";

            if (Guid.TryParse(strGuid, out guid1))
            { Console.WriteLine($"Parsed successfully: {guid1}"); }
            else { Console.WriteLine($"String '{strGuid}' is not a valid guid"); }

            
        }

        private void Change(ref string s)
        {
            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < s.Length; i++)
            {
                string symbol;
                //если встретили символ, то подменяем его на f
                if (Char.IsLetter(s[i]))
                {
                    symbol = "f";
                }
                else
                {
                    symbol = s[i].ToString();
                }

                //собираем новую строку
                builder.Append(symbol);
            }

            s = builder.ToString();
        }
    }
}
