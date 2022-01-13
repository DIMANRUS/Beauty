using System;
using System.Globalization;
using Xamarin.Forms;

namespace Beauty.Converters {
    internal class UserRoleConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            var parametr = parameter.ToString();
            return value?.ToString() switch {
                "USER" => parametr is "UserVisible" or "AllVisible",
                "WORKER" => parametr is "WorkerAndSalonVisible" or "AllVisible" or "WorkerAndWorkerSalonVisible",
                "SALON" => parametr is "WorkerAndSalonVisible" or "SalonVisible" or "AllVisible" or "WorkerAndSalonAndWorkerSalonVisible",
                "WORKERSALON" => parametr is "WorkerSalonVisible" or "AllVisible" or "WorkerVisible" or "WorkerAndWorkerSalonVisible" or "WorkerAndSalonAndWorkerSalonVisible",
                _ => false
            };
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => "";
    }
}