using HomeworkCRUD.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace HomeworkCRUD.Pages.Cats
{
    public class Cat_editModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public Cat_editModel(ApplicationDbContext db)
        {
            _db = db;
        }
        [BindProperty]
        public Cat EditingCat { get; set; } = new();
        public async Task<IActionResult> OnGetAsync(int id)
        {
            Cat? editing = await _db.Cats.FirstOrDefaultAsync(i => i.Id == id);
            if (editing == null)
            {
                return NotFound();
            }
            EditingCat = editing;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            Cat? editing = await _db.Cats.FirstOrDefaultAsync(i => i.Id == EditingCat.Id);
            if (editing == null)
            {
                return NotFound();
            }
            editing.Nickname = EditingCat.Nickname;
            editing.Gender = EditingCat.Gender;
            editing.Breed = EditingCat.Breed;
            editing.Birthday = EditingCat.Birthday;
            editing.Rating = EditingCat.Rating;
            editing.Price = EditingCat.Price;
            await _db.SaveChangesAsync();
            return RedirectToPage("/Index");
        }
    }
}
