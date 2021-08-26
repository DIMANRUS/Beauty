using Beauty.ViewModels.Shared;
using System;

namespace Beauty.ViewModels {
    public class CalendarPageVM : BaseVM {
        public string DateNow { get; private set; } = DateTime.Now.Day + (DateTime.Now.DayOfWeek.ToString() switch {
            "Monday" => " ПН",
            "Tuesday" => " ВТ",
            "Wednasday" => " СР",
            "Thursday" => " ЧТ",
            "Friday" => " ПТ",
            "Saturday" => " СБ",
            "Sunday" => " ВС",
            _ => " ДНИ"
        });
    }
}