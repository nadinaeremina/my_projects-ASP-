using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesSimpleCRUD.Model;

namespace RazorPagesSimpleCRUD.Pages.Issues
{
    public class Issue_DetailsModel : PageModel
    {

        // менеджер для работы с БД
        private readonly ApplicationDbContext _db;

        // конструктор
        public Issue_DetailsModel(ApplicationDbContext db)
        {
            _db = db;
        }

        // объект, который будет отображаться на странице
        public Issue Issue { get; private set; } = new();

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Issue? issue = await _db.Issues.FirstOrDefaultAsync(i => i.Id == id);
            if (issue == null)
            {
                // 404 страница
                return NotFound();
            }
            Issue = issue;
            // 200 + текущая страница
            return Page();
        }
    }
}
