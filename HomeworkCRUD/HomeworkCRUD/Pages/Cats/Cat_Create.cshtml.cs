using HomeworkCRUD.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HomeworkCRUD.Pages.Cats
{
    public class Cat_CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public Cat_CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }
        [BindProperty]
        public Cat NewCat { get; set; } = new();
        public void OnGet() { }
        public async Task<IActionResult> OnPostAsync()
        {
            await _db.Cats.AddAsync(NewCat);
            await _db.SaveChangesAsync();
            return RedirectToPage("/Index");
        }
    }
}
