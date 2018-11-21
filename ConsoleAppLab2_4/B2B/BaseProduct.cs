using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppLab2_4.B2B
{
    //Класс BaseProduct со свойства Id(типа int),  
    //+В сетере свойства нейм сделать проверку строка не была пустой(!string.IsNullOrEmpty), 
    //+в сетере свойства прайс - чтоб цена была больше нуля.
    //+В сетере RegularDiscountQty - количество товара не должно быть меньше 10 (едениц товара). 
    //+в сетере PremiumDiscountQty - количество товара не должно быть меньше чем значение RegularDiscountQty.
    //+ДОбавить метод GetSalesPrice.
    //На вход qty - количество.
    //В нем учесть: если qty больше RegularDiscountQty но меньше PremiumDiscountQty - возвращаем цену со скидкой 10%, 
    //если больше PremiumDiscountQty - цену со скидкой 15%. 
    //+Перезаписать ToSting() с тем чтоб нам возвращалось описание продукта.
    //+Инкапсулировать вызов ToSting в методе GetDesciption();

    public class BaseProduct: ICloneable
    {
        const int MinimalDiscountQty = 10;
        private string _name;
        private decimal _listPrice;
        private int _regularDiscountQty;
        private int _premiumDiscountQty;

        public int Id { get; set; }
        public string Name { get => _name; set => _name = string.IsNullOrEmpty(value) ? throw new Exception("Имя товара не может быть пустым") : value; }
        public decimal ListPrice { get => _listPrice; set => _listPrice = value <= 0 ? throw new Exception("Цена должна быть больше нуля") : value; }


        public string UnitName { get; set; }
        public int RegularDiscountQty { get => _regularDiscountQty; set => _regularDiscountQty = value < MinimalDiscountQty ? throw new Exception($"Количество для обычной скидки меньше допустимого ({MinimalDiscountQty} шт.)") : value; }
        public int PremiumDiscountQty { get => _premiumDiscountQty; set => _premiumDiscountQty = value < RegularDiscountQty? throw new Exception($"Количество для премиум скидки не может быть меньше количества для обычной скидки ({RegularDiscountQty} шт.)"): value; }

        public string GetDescription()
        {
            return ToString();
        }


        public override string ToString()
        {
            return $"{Name} по цене {ListPrice} грн. за {UnitName}, скидка -{RegularDiscountQty}% при покупке от {RegularDiscountQty}{UnitName}, -{PremiumDiscountQty}% - {RegularDiscountQty}{UnitName}";
        }

        public decimal GetSalesPrice(int qty)
        {
            int discount;
            if (qty > RegularDiscountQty && qty < PremiumDiscountQty)
            {
                discount = -10;
            }
            else
            if (qty > PremiumDiscountQty)
            {
                discount = -15;
            }
            else discount = 0;

            return CalcPrice(ListPrice, discount);
        }

        private decimal CalcPrice(decimal value, int percent)
        {
            return value + value * percent / 100;
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
