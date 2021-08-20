using System;
using System.Globalization;
using Xamarin.Forms;

namespace Beauty.Converters {
    class SelfEmployedConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => "Самозанятый";

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) =>
            value?.ToString() switch {
                "Салон" => false,
                _ => true
            };
    }
}