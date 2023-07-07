using System;
using System.Collections.Generic;

namespace WpfAppNumberToWordConversion
{
    public interface INumberToWordService
    {
         String NumberToWord(long Number, CurrencyTypeEnum EnumNumber);
        List<CurrencyType> FillCurrncyType();
    }
}