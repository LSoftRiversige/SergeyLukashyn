using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace ConsoleAppLab2_4
{
    //2. Работа со временем
    public class TimeExample
    {
        public void Run()
        {

            //Получить текущее локальное время
            DateTime today = DateTime.Now;
            Console.WriteLine($"Today is {today}");

            //Получить текущее локально время с указанием временного пояса

            Console.WriteLine($"Today is {today.ToLongDateString()} time zone is {TimeZoneInfo.Local}");


            //Получить текущее время UTC
            Console.WriteLine($"Текущее время UTC: {DateTime.UtcNow}");

            //Вычесть из текущего времени 3 дня
            DateTime dateBefore3 = today.AddDays(-3);
            Console.WriteLine($"Вычесть из текущего времени 3 дня: {dateBefore3}");

            //Получить период времени между текущим и временем 3 дня назад через а) оператор - б) метод Substract
            TimeSpan time3 = today - dateBefore3;
            Console.WriteLine($"Получить период времени между текущим и временем 3 дня назад через а) оператор: {time3}");

            time3 = today.Subtract(dateBefore3);
            Console.WriteLine($"Получить период времени между текущим и временем 3 дня назад через б) метод Substract: {time3}");

            //Привести текущее время к строке в различных форматах(longdate, longtime, shortdate, shorttime)
            Console.WriteLine($"longdate: {today.ToLongDateString()}");
            Console.WriteLine($"longtime: {today.ToLongTimeString()}");
            Console.WriteLine($"shortdate: {today.ToShortDateString()}");
            Console.WriteLine($"shorttime: {today.ToShortTimeString()}");

            //Создать объекты CultureInfo в таких культурах: ar-Bh, en-US, ru-RU, zh-HANS
            CultureInfo arBh = new CultureInfo("ar-Bh");
            CultureInfo enUs = new CultureInfo("en-US");
            CultureInfo ruRU = new CultureInfo("ru-RU");
            CultureInfo zhHANS = new CultureInfo("zh-HANS");

            //Привести текущее время к строке в различных форматах для каждой из культурах
            string s0 = CultureWriteTime(today, arBh);
            string s1 = CultureWriteTime(today, enUs);
            string s2 = CultureWriteTime(today, ruRU);
            string s3 = CultureWriteTime(today, zhHANS);

            //Распарсить эти строки обратно в DateTime
            Console.WriteLine($"{DateTime.Parse(s0)}");
            Console.WriteLine($"{DateTime.Parse(s1)}");
            Console.WriteLine($"{DateTime.Parse(s2)}");
            Console.WriteLine($"{DateTime.Parse(s3)}");

        }

        private static string CultureWriteTime(DateTime time, CultureInfo culture)
        {
            string s = time.ToString(culture.DateTimeFormat.LongTimePattern);
            Console.WriteLine($"{culture.DisplayName}: {s}");
            Console.WriteLine($"{culture.DisplayName}: {time.ToString(culture.DateTimeFormat.ShortTimePattern)}");
            return s; 
        }
    }
}
