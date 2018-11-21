using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppLab2_4.B2B
{
    /*
     Класс UsageBaseProduct наследуемый от BaseProduct.
     Добавляем SubscriptionId типа гуид и ConsumptionLimit(максимльное количество товара которое можно потребить). 
     Перезаписать ToSting() с учетом новых свойств
    */
    class UsageBaseProduct: BaseProduct, IClonable
    {
        public Guid SubscriptionId { get; set; }

        /// <summary>
        /// максимльное количество товара которое можно потребить
        /// </summary>
        public int ConsumptionLimit { get; set; }

        public override string ToString()
        {
            return $"{base.ToString()}, допустима покупка не более {ConsumptionLimit}{UnitName}";
        }
                
    }
}
