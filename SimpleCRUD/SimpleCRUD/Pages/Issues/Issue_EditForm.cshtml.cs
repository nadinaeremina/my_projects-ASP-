using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesSimpleCRUD.Model;

namespace RazorPagesSimpleCRUD.Pages.Issues
{
    public class Issue_EditFormModel : PageModel
    {
        // менеджер для работы с БД
        private readonly ApplicationDbContext _db;

        // конструктор
        public Issue_EditFormModel(ApplicationDbContext db)
        {
            _db = db;
        }

        // объект, который будет отображаться на странице для редактирования
        // и через который будут передаваться данные формы
        [BindProperty]
        public Issue EditingIssue { get; set; } = new();

        public async Task<IActionResult> OnGetAsync(int id)
        {
            // получить удаляемую запись
            Issue? editing = await _db.Issues.FirstOrDefaultAsync(i => i.Id == id);
            if (editing == null)
            {
                // 404 страница
                return NotFound();
            }
            EditingIssue = editing;
            // 200 + текущая страница
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            // получить удаляемую запись
            Issue? editing = await _db.Issues.FirstOrDefaultAsync(i => i.Id == EditingIssue.Id);
            if (editing == null)
            {
                // 404 страница
                return NotFound();
            }
            // выполнить обновление записи
            editing.Title = EditingIssue.Title;
            editing.Description = EditingIssue.Description;
            editing.CreatedAt = EditingIssue.CreatedAt;  
            editing.Deadline = EditingIssue.Deadline;
            editing.Priority = EditingIssue.Priority;
            editing.Done = EditingIssue.Done;
            await _db.SaveChangesAsync();
            // в качестве результата выполнить перенаправление на список дел
            return RedirectToPage("/Issues/Issue_List");
        }
    }
}
