using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppLab2_4.B2B
{
    /*
    Класс Contact наследуемы от Person.
    Добавлены свойства PhoneNumber, Position.
    Добавлен метод SendEmail принимающий текст.
    На консольку выводим $"Email with {text} has been successfully send to address  {Email}". 
    Используем интерполяцию строк через знак доллара в начале строки. { Email}
    в данном случае имейл контакта
    */
    public class Contact: Person, ICloneable
    {
        public string PhoneNumber { get; set; }
        public Position Position { get; set; }
               
        public bool IsEmpty()
        {
            return string.IsNullOrWhiteSpace(PhoneNumber);
        }

        public void SendEMail(string text)
        {
            Console.WriteLine($"Email with {text} has been successfully send to address  {Email}");
        }
    }
}
