using ChallengeCollector.Models;
using CSharpVitamins;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ChallengeCollector.Pages
{
    public class ReviewModel : PageModel
    {
        private readonly ChallengeCollectorDbContext _context;

        [BindProperty]
        public string? Handle { get; set; }

        [BindProperty]
        public string? Passphrase { get; set; }

        public string? ErrorMessage { get; set; }

        public ReviewModel(ChallengeCollectorDbContext context)
        {
            _context = context;
        }

        public void OnGet() { }

        public async Task<IActionResult> OnPostAsync()
        {
            if (
                string.IsNullOrWhiteSpace(Passphrase)
                || Passphrase.Length > 200
                || string.IsNullOrEmpty(Handle)
                || Handle.Length > 200
            )
            {
                ErrorMessage = "Handle and passphrase are required.";
                return Page();
            }

            var db = await _context.ChallengeResponses.FirstOrDefaultAsync(
                a => a.UniqueHandle == Handle && a.Passphrase == Passphrase
            );
            if (db == null)
            {
                ErrorMessage = "Could not find solution with matching handle and passphrase.";
                return Page();
            }

            return RedirectToPage("Details", new { id = db.Id });
        }
    }
}
