using HomeworkCRUD.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace HomeworkCRUD.Pages.Cats
{
    public class Cat_DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public Cat_DetailsModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public Cat Cat { get; private set; } = new();

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Cat? cat = await _db.Cats.FirstOrDefaultAsync(i => i.Id == id);
            if (cat == null)
            {
                return NotFound();
            }
            Cat = cat;
            return Page();
        }
    }
}
