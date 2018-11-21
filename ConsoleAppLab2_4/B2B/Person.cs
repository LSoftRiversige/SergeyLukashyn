using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppLab2_4.B2B
{
    /*
     * Абстрактный класс Person: 
     * Id(типа int), FirstName, LastName, Email.
     * В сеттерах свойст сделать проверку чтоб строка не была пустой(!string.IsNullOrEmpty) и чтоб имейл содержал в себе знак @ и знак точки.
     */
    public abstract class Person: IClonable
    {
        private string _firstName;
        private string _lastName;
        private string _eMail;

        public int Id { get; set; }
        public string FirstName { get => _firstName; set => _firstName = string.IsNullOrEmpty(value) ? throw new Exception("Имя не может быть пустым") : value; }
        public string LastName { get => _lastName; set => _lastName = string.IsNullOrEmpty(value) ? throw new Exception("Фамилия должна быть заполнена") : value; }
        public string Email
        {
            get => _eMail; set
            {
                _eMail = string.IsNullOrEmpty(value) ? throw new Exception("EMail не может быть пустым") : value;
                if ( !_eMail.Contains('@') || !_eMail.Contains('.') ) { throw new Exception("Ошибка записи EMail"); }
            }
        }
        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
