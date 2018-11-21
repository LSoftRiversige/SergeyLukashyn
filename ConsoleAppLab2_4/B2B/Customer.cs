using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppLab2_4.B2B
{
    /* 
     * Класс Customer наследумый от Company.Имеет вложенный класс PurchasedProduct со свойствами Product типа ProductBase, Qty(количество), 
     * время покупки.
     * Имеет свойство ProductsInUse типа массив PurchasedProduct.
     * 
     * реализация ListProducts выводит на экран списко продкуктов из массива PurchasedProduct.  
     * 
     * Имеет метод CreateOrder принимающий массив кортежей (таплов) под названием LineItems типа (BaseProduct, Qty) 
     * и возращающий объект типа Order с CreationDate = текущее время.
     * 
     * Метод ApproveOrder проставляет ApprovalDate заказу и меняет статус
     */
    public class Customer : Company, ICloneable
    {

        public new object Clone()
        {
            var clone = (Customer)MemberwiseClone();
            if (ProductsInUse != null)
            {
                clone.ProductsInUse = new PurchasedProduct[ProductsInUse.Length];
                for (int i = 0; i < ProductsInUse.Length; i++)
                {
                    clone.ProductsInUse[i] = (PurchasedProduct)ProductsInUse[i].Clone();
                }
            }
            
            return clone;
        }

        public PurchasedProduct[] ProductsInUse { get; set; }

        public class PurchasedProduct: IClonable
        {
            public BaseProduct Product { get; set; }
            public int Qty { get; set; }
            public DateTime PurchaseTime { get; set; }
            public override string ToString()
            {
                return $"Куплено {Qty}{Product.UnitName} {Product.ToString()}";
            }
            public object Clone()
            {
                PurchasedProduct clone = (PurchasedProduct)MemberwiseClone();
                if (Product != null) { clone.Product = (BaseProduct)Product.Clone(); }
                return clone;
            }
        }

        public void ApproveOrder(Order order)
        {
            order.ApprovalDate = DateTime.Now;
            order.Status = OrderStatus.Approved;

            //создать список покупок клиента по товарам заказа
            ProductsInUse = new PurchasedProduct[order.LineItems.Length];

            var items = order.LineItems;

            //записать в список покупок информацию о заказе
            for (int i = 0; i < items.Length; i++)
            {
                ProductsInUse[i] = new PurchasedProduct
                {
                    Product = items[i].Product,
                    Qty = items[i].Qty,
                    PurchaseTime = DateTime.Now
                };
            };

            Console.WriteLine("Клиент утвердил заказ");

        }
           
        public Order CreateOrder((BaseProduct Product, int Qty)[] lineItems)
        {
            var order = new Order
            {
                CreationDate = DateTime.Now,
                LineItems = lineItems,
                Customer = this
            };
            return order;
        }

        public override BaseProduct[] ListProducts(string message)
        {
            if (ProductsInUse != null)
            {
                Console.WriteLine($"{message}");
                var products = new BaseProduct[ProductsInUse.Length];
                for (int i = 0; i < ProductsInUse.Length; i++)
                {
                    products[i] = ProductsInUse[i].Product;
                    Console.WriteLine($"{ProductsInUse[i].ToString()}");
                }
                return products;
            }
            else
            {
                Console.WriteLine("Список покупок пуст");
                return null;
            }
        }

        
    }
}
