using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesSimpleCRUD.Model;

namespace RazorPagesSimpleCRUD.Pages.Issues
{
    public class Issue_EditFormModel : PageModel
    {
        // �������� ��� ������ � ��
        private readonly ApplicationDbContext _db;

        // �����������
        public Issue_EditFormModel(ApplicationDbContext db)
        {
            _db = db;
        }

        // ������, ������� ����� ������������ �� �������� ��� ��������������
        // � ����� ������� ����� ������������ ������ �����
        [BindProperty]
        public Issue EditingIssue { get; set; } = new();

        public async Task<IActionResult> OnGetAsync(int id)
        {
            // �������� ��������� ������
            Issue? editing = await _db.Issues.FirstOrDefaultAsync(i => i.Id == id);
            if (editing == null)
            {
                // 404 ��������
                return NotFound();
            }
            EditingIssue = editing;
            // 200 + ������� ��������
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            // �������� ��������� ������
            Issue? editing = await _db.Issues.FirstOrDefaultAsync(i => i.Id == EditingIssue.Id);
            if (editing == null)
            {
                // 404 ��������
                return NotFound();
            }
            // ��������� ���������� ������
            editing.Title = EditingIssue.Title;
            editing.Description = EditingIssue.Description;
            editing.CreatedAt = EditingIssue.CreatedAt;  
            editing.Deadline = EditingIssue.Deadline;
            editing.Priority = EditingIssue.Priority;
            editing.Done = EditingIssue.Done;
            await _db.SaveChangesAsync();
            // � �������� ���������� ��������� ��������������� �� ������ ���
            return RedirectToPage("/Issues/Issue_List");
        }
    }
}
