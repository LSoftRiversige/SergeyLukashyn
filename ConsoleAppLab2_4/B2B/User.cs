using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppLab2_4.B2B
{
    /*
     * Класс User наслеуемы от Person.
     * Добавлены свойства DisplayName, Password, добавлен метод Login, Logout.
     * В сеттерах свойст сделать проверку чтоб строка не была пустой (!string.IsNullOrEmpty). 
     * В логин передаем email и пассворд, выдаем сообщение если данные совпадают с данными объекта, 
     * если нет - сообщения(password is wrong, email not found)
    */
    public class User : Person, IClonable
    {
        private string _displayName;
        private string _password;

        public string DisplayName { get => _displayName; set => _displayName = string.IsNullOrEmpty(value) ? throw new Exception($"Имя пользователя (DisplayName) должно быть заполнено") : value; }
        public string Password { get => _password; set => _password = string.IsNullOrEmpty(value)? throw new Exception($"Пустой пароль недопустим") : value; }
        public bool Login(string email, string password)
        {
            bool ok = string.Equals(email, Email) && string.Equals(password, Password);
            if (ok) Console.WriteLine($"Учетные данные введены правильно");
            else Console.WriteLine($"Неправильный пароль или Email не найден");
            return ok;
        }

        public void Logout()
        {

        }
                
    }
}
