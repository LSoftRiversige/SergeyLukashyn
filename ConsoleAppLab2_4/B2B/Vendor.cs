using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppLab2_4.B2B
{
    //+Класс Vendor наследумый от Company.
    //+Имеет вложенный класс ProductsToSell со свойствами Product типа ProductBase, Qty (количество), Supplier (типа Vendor).  
    //+Имеет свойство ProductsInStock типа массив ProductsToSell. 
    //+реализация ListProducts выводит на экран списко продкуктов из массива ProductsToSell. 
    //+Имеет свойство CompleteOrder примающее аргуметом объект типа Order и проставлящее объекту 
    //+CompletionDate = текущее время и меняет статус. 
    //+Должна быть проверка чтоб в заказе были только товары, которые есть у вендора в количетсве не большем, 
    //+чем есть на складе, иначе - сообщение о том, что невозможно закрыть заказ и ставить заказу статус UnableToComplete
    public class Vendor : Company, IClonable
    {
        private Order _completeOrder;

        public ProductsToSell[] ProductsInStock { get; set; }

        public class ProductsToSell : IClonable
        {
            public BaseProduct Product { get; set; }
            public int Qty { get; set; }
            public Vendor Supplier { get; set; }
            public override string ToString()
            {
                return $"{Qty}{Product.UnitName} {Product.ToString()} от поставщика {Supplier}";
            }
            public object Clone()
            {
                var clone = (ProductsToSell)MemberwiseClone();
                

                clone.Product = (BaseProduct)Product?.Clone();
                clone.Supplier = (Vendor)Supplier?.Clone();

                
                return clone;
            }
        }

        public new object Clone()
        {
            var clone = (Vendor)MemberwiseClone();
            base.Clone();
            if (ProductsInStock != null)
            {
                clone.ProductsInStock = new ProductsToSell[ProductsInStock.Length];
                for (int i = 0; i < ProductsInStock.Length; i++)
                {
                    clone.ProductsInStock[i] = (ProductsToSell)ProductsInStock[i].Clone();
                }
            }
            return clone;
        }

        public Order CompleteOrder
        {
            get => _completeOrder; set
            {
                _completeOrder = value;
                value.CompletionDate = DateTime.Now;
                value.Status = OrderStatus.Completed;
                //Должна быть проверка чтоб в заказе были только товары, которые есть у вендора в количетсве не большем, 
                //чем есть на складе, иначе - сообщение о том, что невозможно закрыть заказ и ставить заказу статус UnableToComplete
                if (CheckOrder(value))
                {
                    Console.WriteLine("\nЗаказ подтвержден поставщиком");
                }
                else
                {
                    //удалить покупки клиента
                    value.Customer.ProductsInUse = null;
                    Console.WriteLine("\nЗаказ выполнить невозможно");
                }
            }
        }

        private bool CheckOrder(Order order)
        {
            //перебираем товары заказа
            for (int i = 0; i < order.LineItems.Length; i++)
            {
                //проверить допустимость заказа товара у поставщика
                if (!CheckProduct(order.LineItems[i]))
                {

                    order.Status = OrderStatus.UnableToComplete;
                    return false;
                }
            }
            return true;
        }

        private bool CheckProduct((BaseProduct product, int Qty) productToOrder)
        {
            bool found = false;
            bool ok = true;
            string productToOrderName = productToOrder.product.ToString();
            string unit = productToOrder.product.UnitName;

            //перебираем товары на складе
            for (int i = 0; i < ProductsInStock.Length; i++)
            {
                //если найден, то проверяем количество
                if (ProductsInStock[i].Product.Id == productToOrder.product.Id)
                {
                    found = true;

                    //расчет возможного дефицита
                    int deficit = productToOrder.Qty - ProductsInStock[i].Qty;
                    if (deficit > 0)
                    {
                        Console.WriteLine($"\nТовара {productToOrderName} недостаточно на складе у поставщика, дефицит составляет {deficit}{unit}");
                        ok = false;
                    }
                    break;

                }
            }

            //в процессе перебора склада товар не найден
            if (!found)
            {
                ok = false;
                Console.WriteLine($"\nТовара {productToOrderName} нет на складе у поставщика");
            }
            return ok;
        }

        public override BaseProduct[] ListProducts(string message)
        {
            Console.WriteLine($"{message}");
            var products = new BaseProduct[ProductsInStock.Length];
            for (int i = 0; i < ProductsInStock.Length; i++)
            {
                products[i] = ProductsInStock[i].Product;
                Console.WriteLine(ProductsInStock[i].ToString());
            }

            return products;
        }

        //8. Cast operators
        //Создать explicit operator таким образом, чтоб можно было преобразовать Vendor в Customer и наоборот.
        //ProductsInStock должны соответсвовать ProductsInUse, при этом будет терятся часть информации. 
        //В ProductsToSell Vendor будет null, в PurchasedProduct время покупки будет DateTime.Min

        public static explicit operator Customer(Vendor vendor)
        {
            Customer c = new Customer() {
                BillingAddresss =vendor.BillingAddresss,
                BusinessOwner =vendor.BusinessOwner,
                FinanceContact =vendor.FinanceContact,
                Id =vendor.Id,
                SalesContact =vendor.SalesContact,
                ShippingAddress =vendor.ShippingAddress,
                TaxIdentificationNumber =vendor.TaxIdentificationNumber
            };
            c.ProductsInUse = new Customer.PurchasedProduct[vendor.ProductsInStock.Length];
            for (int i = 0; i < vendor.ProductsInStock.Length; i++)
            {
                c.ProductsInUse[i] = new Customer.PurchasedProduct {
                    Product = vendor.ProductsInStock[i].Product,
                    PurchaseTime = DateTime.MinValue,
                    Qty = vendor.ProductsInStock[i].Qty
                };
            }
            return c;
        }
    }
}
