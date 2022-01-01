using System;
using System.Globalization;
using Xamarin.Forms;

namespace Beauty.Converters {
    class NullCheckConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            => value ?? "";


        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => value ?? "";
    }
}