using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppLab2_4.B2B
{
    /*
     * Класс LicenseBasedProduct наследуемый от BaseProduct.Добавляем свойтсва NumberOfLicenses и NumberOfDevices - 
     * сколько лицензий даем на продукт и на 
     * скольких устройствах можное его использовать.Перезаписать  ToSting() с учетом новых свойств
     */
    public class LicenseBasedProduct: BaseProduct, IClonable
    {
        /// <summary>
        /// количество лицензий на продукт
        /// </summary>
        public int NumberOfLicenses { get; set; }

        /// <summary>
        /// количество устройств, на которых можно использовать продукт
        /// </summary>
        public int NumberOfDevices { get; set; }

        public override string ToString()
        {
            return $"{base.ToString()} {NumberOfLicenses} лицензий, для {NumberOfDevices} устройств";
        }
       
    }
}
