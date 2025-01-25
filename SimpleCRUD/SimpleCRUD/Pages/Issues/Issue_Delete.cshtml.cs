using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesSimpleCRUD.Model;

namespace RazorPagesSimpleCRUD.Pages.Issues
{
    public class Issue_DeleteModel : PageModel
    {
        // менеджер дл€ работы с Ѕƒ
        private readonly ApplicationDbContext _db;

        // конструктор
        public Issue_DeleteModel(ApplicationDbContext db)
        {
            _db = db;
        }

        // объект, который будет отображатьс€ на странице дл€ удалени€
        public Issue DeletingIssue { get; private set; } = new();

        public async Task<IActionResult> OnGetAsync(int id)
        {
            // получить удал€емую запись
            Issue? deleting = await _db.Issues.FirstOrDefaultAsync(i => i.Id == id);
            if (deleting == null)
            {
                // 404 страница
                return NotFound();
            }
            DeletingIssue = deleting;
            // 200 + текуща€ страница
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            // получить удал€емую запись
            Issue? deleting = await _db.Issues.FirstOrDefaultAsync(i => i.Id == id);
            if (deleting == null)
            {
                // 404 страница
                return NotFound();
            }
            _db.Issues.Remove(deleting);
            await _db.SaveChangesAsync();
            // в качестве результата выполнить перенаправление на список дел
            return RedirectToPage("/Issues/Issue_List");
        }
    }
}
