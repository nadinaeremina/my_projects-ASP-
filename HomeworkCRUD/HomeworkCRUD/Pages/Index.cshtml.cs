using HomeworkCRUD.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace HomeworkCRUD.Pages.Cats
{
    public class Cat_ListModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public Cat_ListModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public List<Cat> Cats { get; private set; } = new();
        public async Task OnGetAsync()
        {
            Cats = await _db.Cats.ToListAsync();
        }
    }
}
