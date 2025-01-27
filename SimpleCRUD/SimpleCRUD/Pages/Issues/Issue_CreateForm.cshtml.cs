using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesSimpleCRUD.Model;

namespace RazorPagesSimpleCRUD.Pages.Issues
{
    public class Issue_CreateFormModel : PageModel
    {
        // менеджер для работы с БД
        private readonly ApplicationDbContext _db;

        // конструктор
        public Issue_CreateFormModel(ApplicationDbContext db)
        {
            _db = db;
        }

        // объект сущности, связанный с параметрами запроса - т.е. с формой
        [BindProperty]
        public Issue NewIssue { get; set; } = new();

        public void OnGet()
        {
            
        }

        // пар-ры, передающиеся в этот метод, перекладутся в эту сущность
        // имена пар-ов должны соответствовать именам св-в сущности (регистр игнорируется, а подчеркивание нет)
        // заполнятся только те поля, которые будут переданы
        public async Task<IActionResult> OnPostAsync()
        {
            // в NewIssue в соответствующий POST-параметрам полях записаны значения из формы
            // необходимо дозаполнить сущность и сохранить ее в БД
            NewIssue.CreatedAt = DateTime.Today;
            await _db.Issues.AddAsync(NewIssue);
            await _db.SaveChangesAsync();
            // redirect - перенаправление
            // в качестве результата выполнить перенаправление на список дел
            return RedirectToPage("/Issues/Issue_List");
        }
    }
}
