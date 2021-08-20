using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace Beauty.Converters {
    class UserRoleConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) =>
             value?.ToString() switch {
                 "Мастер" => parameter.ToString() switch {
                     "Master" => true,
                     "MasterSalon" => true,
                     "User" => false
                 },
                 "Салон" => parameter.ToString() switch {
                     "MasterSalon" => true,
                     "Master" => false,
                     "User" => false
                 },
                 "Пользователь" => parameter.ToString() switch {
                     "MasterSalon" => false,
                     "Master" => false,
                     "User" => true
                 },
                 "User" => (parameter.ToString() == "User") ? true : false,
                 "Master" => (parameter.ToString() == "MasterSalon") ? true : false,
                 "Salon" => (parameter.ToString() == "MasterSalon" || parameter.ToString() == "Salon") ? true : false
             };

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => "";
    }
}