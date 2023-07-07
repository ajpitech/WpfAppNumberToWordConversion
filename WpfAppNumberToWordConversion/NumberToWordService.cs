using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Xml.Linq;

namespace WpfAppNumberToWordConversion
{
    public class NumberToWordService : INumberToWordService
    {
        static string s;
        public String NumberToWord(long Number, CurrencyTypeEnum EnumNumber)
        {
            s = "";
            count = 0;
            if (EnumNumber == (CurrencyTypeEnum)1)
            {
                ConvertNumberToWord(Number);
            }
            else
            {
                ConvertNumberToWordIntenational(Number);
            }
            return Number.ToString() + " is " + s;
        }

        private string ConvertNumberToWordIntenational(long n)
        {
            int numberOfDigit = Convert.ToString(n).Length;

            if (count > 0 && n != 0)
            {
                s = s + " And ";
            }
            count++;
            switch (numberOfDigit)
            {
                case 1: s += SingleDigit(n); return s;
                case 2: s += DoubleDigit(n); return s;
                case 3: s += SingleDigit(n / 100) + " Hundred  " + ConvertNumberToWordIntenational(n - ((n / 100) * 100)); return s;
                case 4: s += SingleDigit(n / 1000) + " Thousand " + ConvertNumberToWordIntenational(n - ((n / 1000) * 1000)); return s;
                case 5: s += DoubleDigit(n / 1000) + " Thousand  " + ConvertNumberToWordIntenational(n - (n / 1000) * 1000); return s;
                case 6: s += SingleDigit(n / 100000) + " Million  " + ConvertNumberToWordIntenational(n - (n / 100000) * 100000); return s;
                case 7: s += DoubleDigit(n / 100000) + " Million  " + ConvertNumberToWordIntenational(n - (n / 100000) * 100000); return s;
                case 8: s += SingleDigit(n / 10000000) + " Billion  " + ConvertNumberToWordIntenational(n - (n / 10000000) * 10000000); return s;
                case 9: s += DoubleDigit(n / 10000000) + " Billion " + ConvertNumberToWordIntenational(n - (n / 10000000) * 10000000); return s;
                default:
                    if (numberOfDigit > 9)
                    {

                    }
                    break;

            }
            return s;
        }

        static int count = 0;
        private string ConvertNumberToWord(long n)
        {
            int numberOfDigit = Convert.ToString(n).Length;
          
            if (count>0&&n!=0)
            {
                s = s + " And ";
            } 
            count++;
            switch (numberOfDigit)
            {
                case 1: s += SingleDigit(n); return s;
                case 2: s += DoubleDigit(n); return s;
                case 3: s += SingleDigit(n / 100) + " Hundred  " + ConvertNumberToWord(n - ((n / 100) * 100)); return s;
                case 4: s += SingleDigit(n / 1000) + " Thousand " + ConvertNumberToWord(n - ((n / 1000) * 1000)); return s;
                case 5: s += DoubleDigit(n / 1000) + " Thousand  " + ConvertNumberToWord(n - (n / 1000) * 1000); return s;
                case 6: s += SingleDigit(n / 100000) + " Lakh " + ConvertNumberToWord(n - (n / 100000) * 100000); return s;
                case 7: s += DoubleDigit(n / 100000) + " Lakh " + ConvertNumberToWord(n - (n / 100000) * 100000); return s;
                case 8: s += SingleDigit(n / 10000000) + " Crore " + ConvertNumberToWord(n - (n / 10000000) * 10000000); return s;
                case 9: s += DoubleDigit(n / 10000000) + " Crore " + ConvertNumberToWord(n - (n / 10000000) * 10000000); return s;
                default:
                    if (numberOfDigit > 9)
                    {

                    }
                    break;

            }
            return s;

        }

        private static string SingleDigit(long n)
        {
            string word = "";
            switch (n)
            {
                case 0: if (count==0) { word = "Zero"; } break;
                case 1: word = "One"; break;
                case 2: word = "Two"; break;
                case 3: word = "Three"; break;
                case 4: word = "Four"; break;
                case 5: word = "Five"; break;
                case 6: word = "Six"; break;
                case 7: word = "Seven"; break;
                case 8: word = "Eight"; break;
                case 9: word = "Nine"; break;
            }
            return word;
        }
        private static string DoubleDigit(long n)
        {
            string word = "";
            switch (n)
            {
                case 10: word = "Ten"; break;
                case 11: word = "Eleven"; break;
                case 12: word = "Twelve"; break;
                case 13: word = "Thirteen"; break;
                case 14: word = "Fourteen"; break;
                case 15: word = "Fifteen"; break;
                case 16: word = "Sixteen"; break;
                case 17: word = "Seventeen"; break;
                case 18: word = "Eighteen"; break;
                case 19: word = "Nineteen"; break;
                //    }
                //    return word;
                //}
                //private static string DoubleTensDigit(int n)
                //{
                //    string word = "";
                //    switch (n)
                //    {
                case 20: word = "Twenty"; break;
                case 30: word = "Thirty"; break;
                case 40: word = "Forty"; break;
                case 50: word = "Fifty"; break;
                case 60: word = "Sixty"; break;
                case 70: word = "Seventy"; break;
                case 80: word = "Eighty"; break;
                case 90: word = "Ninety"; break;
                default:
                    if (n > 0)
                    {
                        word = DoubleDigit((n / 10) * 10) + " " + SingleDigit(n % 10);
                    }
                    break;
            }
            return word;
        }

        public List<CurrencyType> FillCurrncyType()
        {

            List<CurrencyType> currencyTypes = new List<CurrencyType>();
            foreach (var name in Enum.GetNames(typeof(CurrencyTypeEnum)))
            {
                CurrencyType c = new CurrencyType();
                c.CurrencyName = name;
                currencyTypes.Add(c);
            }
            return currencyTypes;






        }
    }
}
