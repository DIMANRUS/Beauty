using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace Beauty.Converters {
    class NullCheckConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            => (value == null) ? "" : value;


        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => (value == null) ? "" : value;
    }
}