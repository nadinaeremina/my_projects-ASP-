using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesSimpleCRUD.Model;

namespace RazorPagesSimpleCRUD.Pages.Issues
{
    public class Issue_DetailsModel : PageModel
    {

        // �������� ��� ������ � ��
        private readonly ApplicationDbContext _db;

        // �����������
        public Issue_DetailsModel(ApplicationDbContext db)
        {
            _db = db;
        }

        // ������, ������� ����� ������������ �� ��������
        public Issue Issue { get; private set; } = new();

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Issue? issue = await _db.Issues.FirstOrDefaultAsync(i => i.Id == id);
            if (issue == null)
            {
                // 404 ��������
                return NotFound();
            }
            Issue = issue;
            // 200 + ������� ��������
            return Page();
        }
    }
}
