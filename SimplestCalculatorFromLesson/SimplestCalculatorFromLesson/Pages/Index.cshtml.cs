using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SimplestCalculatorFromLesson.Pages
{
    public class IndexModel : PageModel
    {
        // �������� ������ ��������
        public int N { get; private set; }          // �������� ����� N
        public long NFact { get; private set; }     // ��������� N
        public string? Error { get; private set; }  // ������
        public void OnGet(int n = 5)
        {
            // ���������� �������� ������
            N = n;
            // ��������� ������� ��������
            if (N < 0 || N > 20)
            {
                Error = "`n` must be in range [0; 20]";
                return;
            }
            Error = null;
            // ��������� ��������� N
            NFact = Factorial(N);
        }
        // factorial - ����� ���������� ����������
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
