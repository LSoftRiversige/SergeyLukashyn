using System;
using System.Collections.Generic;
using System.Text;

namespace DelegatesAndEvents
{
    public class Apartment
    {
        private const int ExitTemp = 999;
        private double _airTemperature;

        public Apartment(Switcher heaterOn, Switcher heaterOff, Switcher acOn, Switcher acOff, int airTemperature = 20)
        {
            _airTemperature = airTemperature;
            HeaterOn = heaterOn;
            HeaterOff = heaterOff;
            AcOn = acOn;
            AcOff = acOff;

            
        }

        public event Switcher HeaterOn, HeaterOff, AcOn, AcOff;

        public double AirTemperature
        {
            get => _airTemperature;

            set
            {
                if (_airTemperature != value)
                {

                    //При повышении температуры выше 25 градусов - включаем кондиционер, 
                    //при понижении ниже 24 градусов - выключаем кондиционер. 
                    //При понижении ниже 14 градусов - включаем отопление, 
                    //при повышении выше 18 градусов - 
                    //выключаем отопление

                    _airTemperature = value;
                    if (value > 25) AcOn?.Invoke();
                    if (value < 24) AcOff?.Invoke();
                    if (value < 14) HeaterOn?.Invoke();
                    if (value > 18) HeaterOff?.Invoke();
                }
                
            }
         }
                

        public static void RunControl()
        {
            var heater = new Heater(States.Off);
            var ac = new AC(States.Off);

            var apartmet = new Apartment(heater.SwitchOn, heater.SwitchOff, ac.SwitchOn, ac.SwitchOff, 21);

            
            while (true)
            {
                Console.WriteLine($"Управление температурой помещения (текущая температура={apartmet.AirTemperature})");

                double t = ReadTemperature();

                if (t == ExitTemp) break;
                else apartmet.AirTemperature = t;

            }
        }

        private static double ReadTemperature()
        {
            bool tryAgain = true;
            double t=0;
            string userinput = "";
            while (tryAgain)
            {
                Console.WriteLine($"Введите температуру воздуха в помещении (введите {ExitTemp}: для окончания ввода):");
                userinput = Console.ReadLine();
                try
                {
                    t = double.Parse(userinput);
                    tryAgain = false;
                }
                catch (Exception)
                {
                    Console.WriteLine("Значение недопустимо, повторите ввод");
                    tryAgain = true;
                }
                
            }
            return t;
        }
    }

    public delegate void Switcher();

}
