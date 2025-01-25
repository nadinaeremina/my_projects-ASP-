using HomeworkCRUD.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace HomeworkCRUD.Pages.Cats
{
    public class Cat_ListModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        // конструктор
        public Cat_ListModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public List<Cat> Cats { get; private set; } = new();

        // конструктор
        public async Task OnGetAsync()
        {
            // получаем список объектов
            Cats = await _db.Cats.ToListAsync();
        }
    }
}
