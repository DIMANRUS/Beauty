using System;
using Beauty.ViewModels.Shared;

namespace Beauty.ViewModels.BarPagesVM.MasterSalon {
    public class CalendarPageVm : BaseVm {
        public string DateNow { get; } = DateTime.Now.Day + (DateTime.Now.DayOfWeek.ToString() switch {
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