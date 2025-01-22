using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Calculator.Pages
{
    public class IndexModel : PageModel
    {

        // Задача: Онлайн калькулятор нахождения площади и длины окружности по диаметру либо радиусу (и то, и то)
        public string Title { get; private set; } = "Razor Pages Sandbox!";
        public Dictionary<int, string> DayByNumber { get; private set; } = new Dictionary<int, string>()
        {
            {1, "понедельник"},
            {2, "вторник"},
            {3, "среда"},
            {4, "четверг"},
            {5, "пятница"},
            {6, "суббота"},
            {7, "воскресенье"},
            {8, "воскресенье"},
            {9, "воскресенье"},
            {10, "воскресенье"},
            {11, "воскресенье"},
            {12, "воскресенье"}
        };
        public int TodayNumber { get; private set; } = (int)DateTime.Now.DayOfWeek;
        public void OnGet()
        {
            // выполним вычисления для обработки запроса
            // при каждом запуске будет пересчитываться
            TodayNumber = (int)DateTime.Now.DayOfWeek;
        }
    }
}
