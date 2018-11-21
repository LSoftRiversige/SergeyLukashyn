using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppLab2_4.B2B
{
    /*
     * Интерфейс IBillingAddressable: включает свойство BillingAddresss типа Address и метод GetBillingInfo;
     * 
     
     */
    public interface IBillingAddressable
    {
        Address BillingAddresss { get; set; }
        string GetBillingInfo();
        
    }
}
