using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppLab2_4.B2B
{
    //4. Написать модель данных B2B магазина
    

    //    Класс UsageBaseProduct наследуемый от BaseProduct.Добавляем SubscriptionId типа гуид и ConsumptionLimit(максимльное количество товара которое можно потребить). Перезаписать ToSting() с учетом новых свойств

    //Класс LicenseBasedProduct наследуемый от BaseProduct.Добавляем свойтсва NumberOfLicenses и NumberOfDevices - сколько лицензий даем на продукт и на скольких устройствах можное его использовать.Перезаписать  ToSting() с учетом новых свойств


    //Класс Address со своствами AddressLine1, AddressLine2, City, PostalCode, Province, Country.Перезаписать метод ToString так чтоб нам возвращалась строка содержащая корректную запись адреса в полном форме (Украина, Харьковская обл. г.Харьков ул.Отакара Яроша 14)

    //Абстрактный класс Person: Id(типа int), FirstName, LastName, Email.В сеттерах свойст сделать проверку чтоб строка не была пустой(!string.IsNullOrEmpty) и чтоб имейл содержал в себе знак @ и знак точки.

    //Энумка Position: BusinessOwner, SalesManager, Accountant

    //Класс Contact наследуемы от Person.Добавлены свойства PhoneNumber, Position.Добавлен метод SendEmail принимающий текст.На консольку выводим $"Email with {text} has been successfully send to address  {Email}". Используем интерполяцию строк через знак доллара в начале строки. { Email}
    //    в данном случае имейл контакта

    //Класс User наслеуемы от Person.Добавлены свойства DisplayName, Password, добавлен метод Login, Logout.В сеттерах свойст сделать проверку чтоб строка не была пустой (!string.IsNullOrEmpty). В логин передаем email и пассворд, выдаем сообщение если данные совпадают с данными объекта, если нет - сообщения(password is wrong, email not found)

    //Интерфейс IBillingAddressable: включает свойство BillingAddresss типа Address и метод GetBillingInfo;

    //    Интерфейс IShippingAddressable: включает свойство ShippingAddress типа Address и метод GetShippingInfo;

    //    Интерфейс ITaxable: включает свойство TaxIdentificationNumber типа string и метод GetTaxInfo(); FileFinancialStatementsToTaxAuthority();

    //    Абстрактный класс Company.Id(типа int). Реализует интерфейсы выше.GetBillingInfo и GetShippingInfo реализуются через перегрузку ToString() на адресах.
    // Также нужны свойства BusinessOwner, SalesContact и FinanceContact типа Contact; FileFinancialStatementsToTaxAuthority() должен содержать проверку на то, что FinanceContact задан.Добавить абстрактный метод ListProducts, который возвращает массив BaseProduct.Также имеет свойтво с именем Orders типа Order[] и метод ListOrders.

    //Класс Customer наследумый от Company.Имеет вложенный класс PurchasedProduct со свойствами Product типа ProductBase, Qty(количество), время покупки.Имеет свойство ProductsInUse типа массив PurchasedProduct.реализация ListProducts выводит на экран списко продкуктов из массива PurchasedProduct.  Имеет метод CreateOrder принимающий массив кортежей (таплов) под названием LineItems типа (BaseProduct, Qty) и возращающий объект типа Order с CreationDate = текущее время.Метод ApproveOrder проставляет ApprovalDate заказу и меняет статус


    //Класс Vendor наследумый от Company.Имеет вложенный класс ProductsToSell со свойствами Product типа ProductBase, Qty (количество), Supplier (типа Vendor).  Имеет свойство ProductsInStock типа массив ProductsToSell. реализация ListProducts выводит на экран списко продкуктов из массива ProductsToSell. 
    //Имеет свойство CompleteOrder примающее аргуметом объект типа Order и проставлящее объекту CompletionDate = текущее время и меняет статус. Должна быть проверка чтоб в заказе были только товары, которые есть у вендора в количетсве не большем, чем есть на складе, иначе - сообщение о том, что невозможно закрыть заказ и ставить заказу статус UnableToComplete

    //Класс Order.Свойства CreationDate, ApprovalDate, CompletionDate типа DateTime, массив кортежей (таплов) под названием LineItems типа (BaseProduct, Qty), свойство типа OrderStatus.
    //Перезаписать ToSting() для вывода информации о заказе


    //Enum OrderStatus: Created, Approved, Completed, UnableToComplete

    //####
    //В Program.Main создать несколько продуктов, кастомера, вендора, создать заказ, выполнить заказ.

    public class B2b
    {
        //public Main()
        //{
        //    while (true)
        //    {
        //        PrintMenu();
        //        string userinput = Console.ReadLine();
        //        switch (userinput)
        //        {

        //            default:
        //                break;
        //        }
        //    }
        //}

        private void PrintMenu()
        {
            //login -email send@example.com -password !dp3%
            //логин должне определить в кастомера или вендора мы зашли.в InMemoryDb в специальном поле должна хранится информация о том, кто сейчас залогинен
            Console.WriteLine("1. Login");

            //view -products --onsale
            //видим список продуктов доступных на продажу (берем у вендора)
            Console.WriteLine("2. Список продуктов доступных на продажу");

            //view -products --purchased
            //видим список продуктов купленных кастомером(комманда доступна только кастомеру)
            Console.WriteLine("3.Cписок продуктов купленных кастомером");

            //product -buy --id 1 --qty 1
            //помещаем продукт в заказ(в один момент времени у кастомера только один заказ со статусом Created)
            Console.WriteLine("");

            //view -orders
            //видим список заказов

            //order -approve --id 1
            //закрывает заказ со стороны кастомера и "отправляет" вендору - копируем заказ из массива кастомер в массив вендора(комманда доступна только кастомеру)

            //order -complete --id 1
            //выполняем заказ со стороны вендора(комманда доступна только вендору)
        }

        public void Run()
        {

            Console.WindowHeight = Console.LargestWindowHeight;
            Console.WindowWidth = Console.LargestWindowWidth;

            Console.WindowLeft = 0;
            Console.WindowTop = 0;


            //описание товаров
            var products = new BaseProduct[10] {
                new BaseProduct { Id=1, ListPrice=80.3m, Name="Лицензия Ультра", PremiumDiscountQty=15, RegularDiscountQty=12, UnitName="шт."},
                new BaseProduct { Id=2, ListPrice=12.35m, Name="Лицензия Старт", PremiumDiscountQty=15, RegularDiscountQty=12, UnitName="шт."},
                new BaseProduct { Id=3, ListPrice=2312, Name="Лицензия 1", PremiumDiscountQty=15, RegularDiscountQty=12, UnitName="шт."},
                new BaseProduct { Id=4, ListPrice=121, Name="Лицензия 2", PremiumDiscountQty=15, RegularDiscountQty=12, UnitName="шт."},
                new BaseProduct { Id=5, ListPrice=8764, Name="Лицензия 3", PremiumDiscountQty=15, RegularDiscountQty=12, UnitName="шт."},
                new BaseProduct { Id=6, ListPrice=243, Name="Лицензия 4", PremiumDiscountQty=15, RegularDiscountQty=12, UnitName="шт."},
                new BaseProduct { Id=7, ListPrice=423, Name="Лицензия 5", PremiumDiscountQty=15, RegularDiscountQty=12, UnitName="шт."},
                new BaseProduct { Id=8, ListPrice=234, Name="Лицензия 6", PremiumDiscountQty=15, RegularDiscountQty=12, UnitName="шт."},
                new BaseProduct { Id=9, ListPrice=765, Name="Лицензия 7", PremiumDiscountQty=15, RegularDiscountQty=12, UnitName="шт."},
                new BaseProduct { Id=10, ListPrice=623, Name="Лицензия 8", PremiumDiscountQty=15, RegularDiscountQty=12, UnitName="шт."}
            };

            var vendor = new Vendor
            {
                BillingAddresss = new Address { AddressLine1 = "пр. Науки", AddressLine2 = "д.2, кв.23", City = "Харьков", Country = "Украина", PostalCode = "61093", Province = "Харьковская" },
                BusinessOwner = new Contact { Email = "itester@gmail.com", FirstName = "Петр", Id = 2, LastName = "Крылов", PhoneNumber = "0678238282", Position = Position.SalesManager },
                ProductsInStock = new Vendor.ProductsToSell[10]
                {
                    new Vendor.ProductsToSell {Product=products[0],  Qty=10},
                    new Vendor.ProductsToSell {Product=products[1],  Qty=9 },
                    new Vendor.ProductsToSell {Product=products[2],  Qty=9 },
                    new Vendor.ProductsToSell {Product=products[3],  Qty=6 },
                    new Vendor.ProductsToSell {Product=products[4],  Qty=17 },
                    new Vendor.ProductsToSell {Product=products[5],  Qty=12 },
                    new Vendor.ProductsToSell {Product=products[6],   Qty=24 },
                    new Vendor.ProductsToSell {Product=products[7],   Qty=2 },
                    new Vendor.ProductsToSell {Product=products[8],   Qty=3 },
                    new Vendor.ProductsToSell {Product=products[9],    Qty=102 }
                }
            };
            
            var customer = new Customer
            {
                BillingAddresss = new Address { AddressLine1 = "ул. О.Яроша", AddressLine2 = "д.23, кв.59", City = "Харьков", Country = "Украина", PostalCode = "61072", Province = "Харьковская" },
                BusinessOwner = new Contact { Email = "i@gmail.com", FirstName = "Иван", Id = 1, LastName = "Иванов", PhoneNumber = "05089418924", Position = Position.BusinessOwner },
                FinanceContact = new Contact { Email = "i@gmail.com", FirstName = "Иван", Id = 1, LastName = "Иванов", PhoneNumber = "05089418924", Position = Position.BusinessOwner },
                ShippingAddress = new Address { AddressLine1 = "ул. О.Яроша", AddressLine2 = "д.23, кв.59", City = "Харьков", Country = "Украина", PostalCode = "61072", Province = "Харьковская" },
                Id = 1,
                TaxIdentificationNumber = "1287627836",
                SalesContact = new Contact { Email = "i@gmail.com", FirstName = "Иван", Id = 1, LastName = "Иванов", PhoneNumber = "05089418924", Position = Position.BusinessOwner },

            };
                       
            //просмотр состояния склада поставщика
            vendor.ListProducts("\nСклад поставщика");

            //создаем заказ из 2 товаров
            var order = customer.CreateOrder(new (BaseProduct, int)[2] { (products[5], 1), (products[8], 2) });

            //покупатель утверждает заказ
            customer.ApproveOrder(order);

            //поставщик завершает заказ
            vendor.CompleteOrder = order;

            //просмотр покупок покупателя
            customer.ListProducts("\nСписок покупок");
                        
            //заказ, который не может быть удовлетворен
            order = customer.CreateOrder(new (BaseProduct, int)[3] { (products[1], 100), (products[8], 2), (new BaseProduct { Id = 999999 }, 1) });

            //покупатель утверждает заказ
            customer.ApproveOrder(order);

            //поставщик завершает заказ, проверяет доступность товаров
            vendor.CompleteOrder = order;

            //просмотр покупок покупателя
            customer.ListProducts("\nСписок покупок");


            //6. Dynamic
            //Записать в переменную типа Dynamic объект типа BaseProduct из задания 4. Вызвать ToSting(). Вызвать GetDesciption().
            //Записать в эту же переменную объект типа Address. Вызвать ToSting()
            //Записать в эту же переменну объект типа Vendor.Вызвать FileFinancialStatementsToTaxAuthority()
            dynamic dyn = products[1];
            Console.WriteLine($"dyn.ToString()={dyn.ToString()}");
            Console.WriteLine($"dyn.GetDescription()={dyn.GetDescription()}");

            dyn = vendor.BillingAddresss;
            Console.WriteLine($"BillingAddresss={dyn.ToString()}");

            dyn = vendor;
            // error! dyn.FileFinancialStatementsToTaxAuthority();

            customer = (Customer)vendor;
            Console.WriteLine($"{customer.ListProducts("Покупки после конвертации из поставщика")}");


            //глубокое копирование
            //var orderClone = (Order)order.Clone();
            //orderClone.ToString();

            //var cloneVendor = (Vendor)vendor.Clone();

            var user = new User { DisplayName="user1", FirstName="Jonh", Id=10};
            var userClone = (User)user.Clone();
        }
    }
}
