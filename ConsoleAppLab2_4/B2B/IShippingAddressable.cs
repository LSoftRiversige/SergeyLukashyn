using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppLab2_4.B2B
{
    //Интерфейс IShippingAddressable: включает свойство ShippingAddress типа Address и метод GetShippingInfo;
    public interface IShippingAddressable
    {
        Address ShippingAddress { get; set; }
        string GetShippingInfo();
    }
}
