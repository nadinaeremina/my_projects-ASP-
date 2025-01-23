using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyCalendar.Pages
{
    public class IndexModel : PageModel
    {
        public string Title { get; private set; } = "Calendar";
        public DateTime Now_date { get; private set; } = new DateTime();
        public DateTime Begin_of_month { get; private set; } = new DateTime();
        public DateTime Previous_Month { get; private set; } = new DateTime();
        public int Day_of_week { get; private set; } = 0;
        public int Count_days { get; private set; } = 0; 
        public int Count_days_prev_month { get; set; } = 0;

        public void OnGet()
        {
            Now_date = DateTime.Now;
            Begin_of_month = new DateTime(Now_date.Year, Now_date.Month, 1);
            Previous_Month = Now_date.AddMonths(-1);
            Day_of_week = Convert.ToInt32(Begin_of_month.DayOfWeek);
            Count_days = DateTime.DaysInMonth(Convert.ToInt16(Now_date.Year), Convert.ToInt32(Now_date.Month));
            Count_days_prev_month = DateTime.DaysInMonth(Convert.ToInt16(Previous_Month.Year), Convert.ToInt32(Previous_Month.Month));
            if (Day_of_week > 2)
            {
                Count_days_prev_month = Count_days_prev_month - (Day_of_week - 2);
            }
        }
    }
}
