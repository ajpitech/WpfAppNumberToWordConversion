using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfAppNumberToWordConversion
{
    public class MainWindowViewModel : BaseViewModel
    {
        public int Number { get; set; }
        public string WordNumber { get; set; }

       
        public CurrencyType SelectdCurrency { get; set; }
        public ICommand WordToNumberConvertCommand { get; set; }
        public List<CurrencyType> currencyTypes { get; set; }
        NumberToWordService numberToWordService;
        public MainWindowViewModel()
        {
            numberToWordService = (NumberToWordService)ApanaRegistry.GetInstance<INumberToWordService>();
            WordToNumberConvertCommand = new RelayCommand(WordConverClick);
            currencyTypes= numberToWordService.FillCurrncyType();
        }

        private void WordConverClick(object obj)
        {
            if (SelectdCurrency != null)
            {
                CurrencyTypeEnum EnumNumber=(CurrencyTypeEnum)1 ;
                Array enumValueArray = Enum.GetValues(typeof(CurrencyTypeEnum));
                foreach (CurrencyTypeEnum enumValue in enumValueArray)
                {
                    if (Enum.GetName(typeof(CurrencyTypeEnum), enumValue) == SelectdCurrency.CurrencyName.ToString())
                    {
                        EnumNumber = enumValue;
                    }
                }
                
                    WordNumber = numberToWordService.NumberToWord(Number, EnumNumber);
                
            
                OnPropertyChanged(nameof(WordNumber));
            }
            else
            {
                WordNumber = "Pleae Select Proper Currency";
                OnPropertyChanged(nameof(WordNumber));
            }
        }


    }
}
