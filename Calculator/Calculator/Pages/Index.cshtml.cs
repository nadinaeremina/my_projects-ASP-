using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Calculator.Pages
{
    public class IndexModel : PageModel
    {

        // ������: ������ ����������� ���������� ������� � ����� ���������� �� �������� ���� ������� (� ��, � ��)
        public string Title { get; private set; } = "Razor Pages Sandbox!";
        public Dictionary<int, string> DayByNumber { get; private set; } = new Dictionary<int, string>()
        {
            {1, "�����������"},
            {2, "�������"},
            {3, "�����"},
            {4, "�������"},
            {5, "�������"},
            {6, "�������"},
            {7, "�����������"},
            {8, "�����������"},
            {9, "�����������"},
            {10, "�����������"},
            {11, "�����������"},
            {12, "�����������"}
        };
        public int TodayNumber { get; private set; } = (int)DateTime.Now.DayOfWeek;
        public void OnGet()
        {
            // �������� ���������� ��� ��������� �������
            // ��� ������ ������� ����� ���������������
            TodayNumber = (int)DateTime.Now.DayOfWeek;
        }
    }
}
