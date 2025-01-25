using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesSimpleCRUD.Model;

namespace RazorPagesSimpleCRUD.Pages.Issues
{
    public class Issue_DeleteModel : PageModel
    {
        // �������� ��� ������ � ��
        private readonly ApplicationDbContext _db;

        // �����������
        public Issue_DeleteModel(ApplicationDbContext db)
        {
            _db = db;
        }

        // ������, ������� ����� ������������ �� �������� ��� ��������
        public Issue DeletingIssue { get; private set; } = new();

        public async Task<IActionResult> OnGetAsync(int id)
        {
            // �������� ��������� ������
            Issue? deleting = await _db.Issues.FirstOrDefaultAsync(i => i.Id == id);
            if (deleting == null)
            {
                // 404 ��������
                return NotFound();
            }
            DeletingIssue = deleting;
            // 200 + ������� ��������
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            // �������� ��������� ������
            Issue? deleting = await _db.Issues.FirstOrDefaultAsync(i => i.Id == id);
            if (deleting == null)
            {
                // 404 ��������
                return NotFound();
            }
            _db.Issues.Remove(deleting);
            await _db.SaveChangesAsync();
            // � �������� ���������� ��������� ��������������� �� ������ ���
            return RedirectToPage("/Issues/Issue_List");
        }
    }
}
