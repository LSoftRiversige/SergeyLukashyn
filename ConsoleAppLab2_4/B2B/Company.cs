using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppLab2_4.B2B
{
    /*
     * +Абстрактный класс Company.Id(типа int). Реализует интерфейсы выше.GetBillingInfo и GetShippingInfo реализуются через перегрузку ToString() на адресах.
     * +Также нужны свойства BusinessOwner, SalesContact и FinanceContact типа Contact; 
     * +FileFinancialStatementsToTaxAuthority() должен содержать проверку на то, что FinanceContact задан.
     * +Добавить абстрактный метод ListProducts, который возвращает массив BaseProduct.
     * Также имеет свойтво с именем Orders типа Order[] и метод ListOrders.
    */ 
    public abstract class Company: IBillingAddressable, IShippingAddressable, ITaxable, ICloneable
    {
        public int Id { get; set; }
        public Address BillingAddresss { get; set; }
        public Address ShippingAddress { get; set; }
        public string TaxIdentificationNumber { get; set; }
        public Contact BusinessOwner { get; set; }
        public Contact SalesContact { get; set; }
        public Contact FinanceContact { get; set; }
        public Order[] Orders { get; set; }

        /// <summary>
        /// список товаров
        /// </summary>
        /// <returns></returns>
        public abstract BaseProduct[] ListProducts(string message);
        

        /// <summary>
        /// проверка на то, что FinanceContact задан
        /// </summary>
        public bool FileFinancialStatementsToTaxAuthority()
        {
            return !FinanceContact.IsEmpty();
        }

        public string GetBillingInfo()
        {
            return BillingAddresss.ToString();
        }

        public string GetShippingInfo()
        {
            return ShippingAddress.ToString();
        }

        public string GetTaxInfo()
        {
            throw new NotImplementedException();
        }

        public object Clone()
        {
            Company clone;
            clone=(Company)MemberwiseClone();
            clone.BillingAddresss = (Address)BillingAddresss?.Clone();
            clone.BusinessOwner = (Contact)BusinessOwner?.Clone();
            return clone;
        }
    }
}
