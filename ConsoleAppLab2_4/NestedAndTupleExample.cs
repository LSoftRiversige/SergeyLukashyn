using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppLab2_4
{
    //3.Работа с nested class & tuples
    public class NestedAndTupleExample
    {
        public void Run()
        {
            //Из метода мейн в переменную вернуть значение GetRandomCoordinates; Переменную объявит неявно через var.Вывести на экран что получилось
            (GeoCoordinate Latitude, GeoCoordinate Longtitude) coordinates; 
            coordinates = GetRandomCoordinates();
            Console.WriteLine($"coordinates={DisplayCoordinates(coordinates)}");

        }

        private string DisplayCoordinates((GeoCoordinate Latitude, GeoCoordinate Longtitude) coordinates)
        {
            return $"{coordinates.Latitude.ToString()} {coordinates.Longtitude.ToString()}";
        }

        //Создать вложенный enum Compass со значениям сторон света(N, S, E, W)
        enum Compass
        {
            N, S, E, W
        }
        enum Meridian
        {
            Latitude, Longtitude
        }
        //Создать влаженною структуру GeoCoordinate(свойства Value типа double; Suffix типа Compass)
        struct GeoCoordinate
        {
            public double Value { get; set; }
            public Compass Suffix { get; set; }
            public override string ToString()
            {
                const char degree = (char)176;
                return $"{Value.ToString()}{degree}{Suffix.ToString()}";
            }
        }

        //Создать метод GetRandomCoordinates возвращаюший кортеж(tuple) типа(GeoCoordinate Latitude, GeoCoordinate Longtitude)
        //В этом методе создать локальную функцию генерирующую GeoCoordinate из случайных чисел(случайное число для value, и случайное для Compass) : 
        //на вход ограничение для координат(широта на больше 90 долгота не больше 180, стороны света должны соответствовать)
        private (GeoCoordinate Latitude /*широта*/, GeoCoordinate Longtitude /*долгота*/) GetRandomCoordinates()
        {
            GeoCoordinate DefineCoordinatesRandom(int max, Meridian meridian)
            {
                var r = new Random();
                return new GeoCoordinate() { Value = r.Next(max), Suffix = GetRandomSuffix(meridian) };
            }

            //долгота - восток запад
            //широта - сервер - юг
            GeoCoordinate latitude  = DefineCoordinatesRandom(90, Meridian.Latitude);
            GeoCoordinate logtitude = DefineCoordinatesRandom(180, Meridian.Longtitude);
            return (latitude, logtitude);
        }

        private Compass GetRandomSuffix(Meridian meridian)
        {
            int min=0, max=0;
            switch (meridian)
            {
                case Meridian.Latitude:
                    min = 0;
                    max = 1;
                    break;
                case Meridian.Longtitude:
                    min = 2;
                    max = 3;
                    break;
                default:
                    break;
            }
            Random r = new Random(min);
            return (Compass)r.Next(max);
        }
    }
}
