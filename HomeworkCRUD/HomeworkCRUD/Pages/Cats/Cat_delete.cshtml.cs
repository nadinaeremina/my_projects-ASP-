using HomeworkCRUD.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace HomeworkCRUD.Pages.Cats
{
    public class Cat_deleteModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public Cat_deleteModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public Cat DeletingCat { get; private set; } = new();
        public async Task<IActionResult> OnGetAsync(int id)
        {
            Cat? deleting = await _db.Cats.FirstOrDefaultAsync(i => i.Id == id);
            if (deleting == null)
            {
                return NotFound();
            }
            DeletingCat = deleting;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            Cat? deleting = await _db.Cats.FirstOrDefaultAsync(i => i.Id == id);
            if (deleting == null)
            {
                return NotFound();
            }
            _db.Cats.Remove(deleting);
            await _db.SaveChangesAsync();
            return RedirectToPage("/Index");
        }
    }
}
