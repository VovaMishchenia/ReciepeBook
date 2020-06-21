using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ReciepeBook.ViewModel.Helper
{
    class ConvertStringToInt:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string rec = value.ToString();
            return rec;
        }

       
        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int rec = System.Convert.ToInt32(value);
            return rec;
        }
    }
}
