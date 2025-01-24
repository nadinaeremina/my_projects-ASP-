using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesSimpleCRUD.Model;

namespace RazorPagesSimpleCRUD.Pages.Issues
{
    public class Issue_ListModel : PageModel
    {
        // менеджер для работы с БД
        private readonly ApplicationDbContext _db;

        // конструктор
        public Issue_ListModel(ApplicationDbContext db)
        {
            _db = db;
        }

        // свойства модели страницы
        public List<Issue> Issues { get; private set; } = new();

        // конструктор
        public async Task OnGetAsync()
        {
            // получаем список объектов
            Issues = await _db.Issues.ToListAsync();
        }
    }
}
