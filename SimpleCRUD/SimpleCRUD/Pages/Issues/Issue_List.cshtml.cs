using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesSimpleCRUD.Model;

namespace RazorPagesSimpleCRUD.Pages.Issues
{
    public class Issue_ListModel : PageModel
    {
        // �������� ��� ������ � ��
        private readonly ApplicationDbContext _db;

        // �����������
        public Issue_ListModel(ApplicationDbContext db)
        {
            _db = db;
        }

        // �������� ������ ��������
        public List<Issue> Issues { get; private set; } = new();

        // �����������
        public async Task OnGetAsync()
        {
            // �������� ������ ��������
            Issues = await _db.Issues.ToListAsync();
        }
    }
}
