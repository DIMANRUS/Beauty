using System;
using System.Globalization;
using Xamarin.Forms;

namespace Beauty.Converters {
    class UserRoleConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) =>
             value?.ToString() switch {
                 "Мастер" => parameter.ToString() switch {
                     "Master" => true,
                     "MasterSalon" => true,
                     "User" => false,
                     _ => false
                 },
                 "Салон" => parameter.ToString() switch {
                     "MasterSalon" => true,
                     "Master" => false,
                     "User" => false,
                     _ => false
                 },
                 "Пользователь" => parameter.ToString() switch {
                     "MasterSalon" => false,
                     "Master" => false,
                     "User" => true,
                     _ => false
                 },
                 "USER" => (parameter.ToString() == "User" || parameter.ToString() == "All") ? true : false,
                 "MASTER" => (parameter.ToString() == "MasterSalon" || parameter.ToString() == "All") ? true : false,
                 "SALON" => (parameter.ToString() == "MasterSalon" || parameter.ToString() == "Salon" || parameter.ToString() == "All") ? true : false,
                 _ => false
             };

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => "";
    }
}