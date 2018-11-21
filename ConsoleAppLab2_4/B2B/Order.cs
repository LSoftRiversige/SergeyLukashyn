using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppLab2_4.B2B
{
    //Класс Order.Свойства CreationDate, ApprovalDate, CompletionDate типа DateTime, 
    //массив кортежей (таплов) под названием LineItems типа (BaseProduct, Qty), свойство типа OrderStatus.
    public class Order: IClonable
    {
        public DateTime CreationDate { get; set; }
        public DateTime ApprovalDate { get; set; }
        public DateTime CompletionDate { get; set; }
        public (BaseProduct Product, int Qty)[] LineItems;
        public OrderStatus Status { get; set; }
        public Customer Customer { get; set; } //покупатель, который сделал заказ

        public object Clone()
        {
            Order clone = (Order)MemberwiseClone();
            if (LineItems != null)
            {
                clone.LineItems = new (BaseProduct, int)[LineItems.Length];
                for (int i = 0; i < LineItems.Length; i++)
                {
                    clone.LineItems[i] = LineItems[i];
                }
            }
            
            clone.Customer = (Customer)Customer?.Clone();
            return clone;
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            //шапка заказа
            result.Append($"Заказ от {CreationDate} находится в состоянии {Status}\n");
            
            //список заказанных товаров
            foreach (var item in LineItems)
            {
                result.Append($"{item.Product.ToString()}\t\t; заказано {item.Qty}{item.Product.UnitName}");
            }

            return result.ToString();
        }

    }
}
