using HDATA_PHARMACY.Extras;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace HDATA_PHARMACY.Converter
{
    public class DinheiroFormatConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                double valor = double.Parse(value.ToString());
                return HelperView.FormatDouble_MoneySimple(valor);
            }
            return HelperView.FormatDouble_MoneySimple(0);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
