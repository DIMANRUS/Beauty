using System;
using System.Globalization;
using Xamarin.Forms;

namespace Beauty.Converters {
    internal class PickerRoleConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) =>
            value switch {
                "USER" => "Пользователь",
                "WORKER" or "WORKERSALON " => "Мастер",
                "SALON" => "Салон",
                _ => "Пользователь"
            };

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => value?.ToString() switch {
            "Пользователь" => "USER",
            "Мастер" => "WORKER",
            "Салон" => "SALON",
            _ => "USER"
        };
    }
}