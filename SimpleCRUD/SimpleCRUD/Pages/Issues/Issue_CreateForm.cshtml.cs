using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesSimpleCRUD.Model;

namespace RazorPagesSimpleCRUD.Pages.Issues
{
    public class Issue_CreateFormModel : PageModel
    {
        // �������� ��� ������ � ��
        private readonly ApplicationDbContext _db;

        // �����������
        public Issue_CreateFormModel(ApplicationDbContext db)
        {
            _db = db;
        }

        // ������ ��������, ��������� � ����������� ������� - �.�. � ������
        [BindProperty]
        public Issue NewIssue { get; set; } = new();

        public void OnGet()
        {
            
        }

        // ���-��, ������������ � ���� �����, ������������ � ��� ��������
        // ����� ���-�� ������ ��������������� ������ ��-� �������� (������� ������������, � ������������� ���)
        // ���������� ������ �� ����, ������� ����� ��������
        public async Task<IActionResult> OnPostAsync()
        {
            // � NewIssue � ��������������� POST-���������� ����� �������� �������� �� �����
            // ���������� ����������� �������� � ��������� �� � ��
            NewIssue.CreatedAt = DateTime.Today;
            await _db.Issues.AddAsync(NewIssue);
            await _db.SaveChangesAsync();
            // redirect - ���������������
            // � �������� ���������� ��������� ��������������� �� ������ ���
            return RedirectToPage("/Issues/Issue_List");
        }
    }
}
