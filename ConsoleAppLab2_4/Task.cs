using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppLab2_4
{
    

//3.Работа с nested class & tuples
//Создать вложенный enum Compass со значениям сторон света(N, S, E, W)
//Создать влаженною структуру GeoCoordinate(свойства Value типа double; Suffix типа Compass)
//Создать метод GetRandomCoordinates возвращаюший кортеж(tuple) типа(GeoCoordinate Latitude, GeoCoordinate Longtitude)
//В этом методе создать локальную функцию генерирующую GeoCoordinate из случайных чисел(случайное число для value, и случайное для Compass) : на вход ограничение для координат(широта на больше 90 долгота не больше 180, стороны света должны соответствовать)
//Из метода мейн в переменную вернуть значение GetRandomCoordinates; Переменную объявит неявно через var.Вывести на экран что получилось

//4. Написать модель данных B2B магазина
//+Класс BaseProduct со свойства Id(типа int),  Name, ListPrice, UnitName(еденица измерения) RegularDiscountQty, PremiumDiscountQty.В сетере свойства нейм сделать проверку строка не была пустой(!string.IsNullOrEmpty), в сетере свойства прайс - чтоб цена была больше нуля.В сетере RegularDiscountQty - количество товара не должно быть меньше 10 (едениц товара). в сетере PremiumDiscountQty - количество товара не должно быть меньше чем значение RegularDiscountQty.ДОбавить метод GetSalesPrice.На вход qty - количество.В нем учесть: если qty больше RegularDiscountQty но меньше PremiumDiscountQty - возвращаем цену со скидкой 10%, если больше PremiumDiscountQty - цену со скидкой 15%. Перезаписать ToSting() с тем чтоб нам возвращалось описание продукта.Инкапсулировать вызов ToSting в методе GetDesciption();

//+Класс UsageBaseProduct наследуемый от BaseProduct.Добавляем SubscriptionId типа гуид и ConsumptionLimit(максимльное количество товара которое можно потребить). Перезаписать ToSting() с учетом новых свойств

//+Класс LicenseBasedProduct наследуемый от BaseProduct.Добавляем свойтсва NumberOfLicenses и NumberOfDevices - сколько лицензий даем на продукт и на скольких устройствах можное его использовать.Перезаписать  ToSting() с учетом новых свойств


//+Класс Address со своствами AddressLine1, AddressLine2, City, PostalCode, Province, Country.Перезаписать метод ToString так чтоб нам возвращалась строка содержащая корректную запись адреса в полном форме (Украина, Харьковская обл. г.Харьков ул.Отакара Яроша 14)

//+Абстрактный класс Person: Id(типа int), FirstName, LastName, Email.В сеттерах свойст сделать проверку чтоб строка не была пустой(!string.IsNullOrEmpty) и чтоб имейл содержал в себе знак @ и знак точки.

//+Энумка Position: BusinessOwner, SalesManager, Accountant

//+Класс Contact наследуемы от Person.Добавлены свойства PhoneNumber, Position.Добавлен метод SendEmail принимающий текст.На консольку выводим $"Email with {text} has been successfully send to address  {Email}". Используем интерполяцию строк через знак доллара в начале строки. { Email}
//    в данном случае имейл контакта

//+Класс User наслеуемы от Person.Добавлены свойства DisplayName, Password, добавлен метод Login, Logout.В сеттерах свойст сделать проверку чтоб строка не была пустой (!string.IsNullOrEmpty). В логин передаем email и пассворд, выдаем сообщение если данные совпадают с данными объекта, если нет - сообщения(password is wrong, email not found)

//+Интерфейс IBillingAddressable: включает свойство BillingAddresss типа Address и метод GetBillingInfo;

//    +Интерфейс IShippingAddressable: включает свойство ShippingAddress типа Address и метод GetShippingInfo;

//    +Интерфейс ITaxable: включает свойство TaxIdentificationNumber типа string и метод GetTaxInfo(); FileFinancialStatementsToTaxAuthority();

//    +Абстрактный класс Company.Id(типа int). Реализует интерфейсы выше.GetBillingInfo и GetShippingInfo реализуются через перегрузку ToString() на адресах.
// +Также нужны свойства BusinessOwner, SalesContact и FinanceContact типа Contact; FileFinancialStatementsToTaxAuthority() должен содержать проверку на то, что FinanceContact задан.Добавить абстрактный метод ListProducts, который возвращает массив BaseProduct.Также имеет свойтво с именем Orders типа Order[] и метод ListOrders.

//+Класс Customer наследумый от Company.Имеет вложенный класс PurchasedProduct со свойствами Product типа ProductBase, Qty(количество), время покупки.Имеет свойство ProductsInUse типа массив PurchasedProduct.реализация ListProducts выводит на экран списко продкуктов из массива PurchasedProduct.  Имеет метод CreateOrder принимающий массив кортежей (таплов) под названием LineItems типа (BaseProduct, Qty) и возращающий объект типа Order с CreationDate = текущее время.Метод ApproveOrder проставляет ApprovalDate заказу и меняет статус


//+Класс Vendor наследумый от Company.Имеет вложенный класс ProductsToSell со свойствами Product типа ProductBase, Qty (количество), Supplier (типа Vendor).  Имеет свойство ProductsInStock типа массив ProductsToSell. реализация ListProducts выводит на экран списко продкуктов из массива ProductsToSell. 
//+Имеет свойство CompleteOrder примающее аргуметом объект типа Order и проставлящее объекту CompletionDate = текущее время и меняет статус. Должна быть проверка чтоб в заказе были только товары, которые есть у вендора в количетсве не большем, чем есть на складе, иначе - сообщение о том, что невозможно закрыть заказ и ставить заказу статус UnableToComplete

//+Класс Order.Свойства CreationDate, ApprovalDate, CompletionDate типа DateTime, массив кортежей (таплов) под названием LineItems типа (BaseProduct, Qty), свойство типа OrderStatus.
//+Перезаписать ToSting() для вывода информации о заказе


//+Enum OrderStatus: Created, Approved, Completed, UnableToComplete

//####
//В Program.Main создать несколько продуктов, кастомера, вендора, создать заказ, выполнить заказ.

//5. IClonable
//Реализовать IClonable на классах из задания 4. Рассмотреть варианты deep copy, shallow copy собственной релизации, shallow copy через this.MemberwiseClone

//6. Dynamic
//Записать в переменную типа Dynamic объект типа BaseProduct из задания 4. Вызвать ToSting(). Вызвать GetDesciption().
//Записать в эту же переменную объект типа Address. Вызвать ToSting()
//Записать в эту же переменну объект типа Vendor.Вызвать FileFinancialStatementsToTaxAuthority()

//7. Dynamic & overflow
//Исследовать явление arithmetic overflow в контексте использования dynamic
//Объявим переменную типа dynamic и запишем в нее long.maxvalue  (dynamic dyn = long.MaxValue)
//Объявить переменную типа int и через приведение типов присвоем ей значение прошлой переменной(int bigInt = (int)dyn)
//Посмотреть значение одной и другой переменной.
//Выполнить все это внутри блока checked и получить ошибку

//8. Cast operators
//Создать explicit operator таким образом, чтоб можно было преобразовать Vendor в Customer и наоборот.ProductsInStock должны соответсвовать ProductsInUse, при этом будет терятся часть информации. В ProductsToSell Vendor будет null, в PurchasedProduct время покупки будет DateTime.Min

//9*(со звездочкой). Консолькный интрфейс магазина
//Создать вендора, продукты, кастомера, юзера для вендора и для кастомера.
//Мы дожны иметь возможность залогиниться, просмотреть продукты, создать заказ, одобрить заказ.
//Хранение данных можем организовать через static class InMemoryDb, который должен заполняться при загрузке программы.В этом классе в статические поля размещаем вендора и кастомера
//В Program.Main - while loop, который заверашется только если с консоли считываем слово exit.

//Примеры комманд которые принимаем через ReadLine

//login -email send@example.com -password !dp3%
//логин должне определить в кастомера или вендора мы зашли.в InMemoryDb в специальном поле должна хранится информация о том, кто сейчас залогинен

//view -products --onsale
//видим список продуктов доступных на продажу (берем у вендора)

//view -products --purchased
//видим список продуктов купленных кастомером(комманда доступна только кастомеру)

//product -buy --id 1 --qty 1
//помещаем продукт в заказ(в один момент времени у кастомера только один заказ со статусом Created)

//view -orders
//видим список заказов

//order -approve --id 1
//закрывает заказ со стороны кастомера и "отправляет" вендору - копируем заказ из массива кастомер в массив вендора(комманда доступна только кастомеру)

//order -complete --id 1
//выполняем заказ со стороны вендора(комманда доступна только вендору)

//###
//Можно расширять и вносить изминения в модель данных.Допустим вместо массива таплов использовать класс с индексером на котором реализовать методы Add, Delete
//Можно придумать комманды для вендора - изминение цены товара.Или реализовать финансовые опирации - добавить поле "кошелек" типа decimal для компании и при выполнении заказа производить трансфер денег между компаниями
//Предполгается что программа выполняется в цикле, экран после каждой комманды очищается, данные хранятся в статик классе и мы можем заходить под разными юзерам: залогинились, сделали заказ, вышли, залогинились как юзер от вендора, выполнили заказ.







}
