using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppLab2_4.B2B
{
    //Интерфейс ITaxable: включает свойство TaxIdentificationNumber типа string и метод GetTaxInfo(); FileFinancialStatementsToTaxAuthority();
    public interface ITaxable
    {
        string TaxIdentificationNumber { get; set; }
        string GetTaxInfo();
        bool FileFinancialStatementsToTaxAuthority();
    }
}
