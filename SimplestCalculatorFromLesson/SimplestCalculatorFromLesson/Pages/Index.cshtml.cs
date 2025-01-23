using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SimplestCalculatorFromLesson.Pages
{
    public class IndexModel : PageModel
    {
        // свойства модели страницы
        public int N { get; private set; }          // исходное число N
        public long NFact { get; private set; }     // факториал N
        public string? Error { get; private set; }  // ошибка
        public void OnGet(int n = 5)
        {
            // установить исходные данные
            N = n;
            // проверить входной параметр
            if (N < 0 || N > 20)
            {
                Error = "`n` must be in range [0; 20]";
                return;
            }
            Error = null;
            // вычислить факториал N
            NFact = Factorial(N);
        }
        // factorial - метод вычисления факториала
        private long Factorial(int n)
        {
            if (n < 2)
            {
                return 1;
            }
            long fact = 1;
            for (int i = 2; i <= n; i++)
            {
                fact *= i;
            }
            return fact;
        }
    }
}
