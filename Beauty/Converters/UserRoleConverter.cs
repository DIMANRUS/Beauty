using System;
using System.Globalization;
using Xamarin.Forms;

namespace Beauty.Converters {
    class UserRoleConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            string parametr = parameter.ToString();
            return value?.ToString() switch {
                //"Мастер" => parametr switch {
                //    "Master" => true,
                //    "MasterSalon" => true,
                //    "User" => false,
                //    _ => false
                //},
                //"Салон" => parametr switch {
                //    "MasterSalon" => true,
                //    "Master" => false,
                //    "User" => false,
                //    _ => false
                //},
                //"Пользователь" => parametr switch {
                //    "MasterSalon" => false,
                //    "Master" => false,
                //    "User" => true,
                //    _ => false
                //},
                "USER" => parametr is "USER" or "ALL",
                "WORKER" => parametr is "MasterSalon" or "ALL",
                "SALON" => parametr is "MasterSalon" or "SALON" or "ALL",
                "WORKERSALON" => parametr is "MasterSalon" or "ALL" or "WORKERSALON",
                _ => false
            };
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => "";
    }
}