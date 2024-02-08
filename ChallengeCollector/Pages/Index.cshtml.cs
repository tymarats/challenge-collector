using ChallengeCollector;
using ChallengeCollector.Models;
using CSharpVitamins;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class IndexModel : PageModel
{
    private readonly ChallengeCollectorDbContext _context;

    [BindProperty]
    public IFormFile? FileUpload { get; set; }
    [BindProperty]
    public IFormFile? TestFileUpload { get; set; }
    [BindProperty]
    public string? Passphrase { get; set; }

    public string? ErrorMessage { get; set; }

    public IndexModel(ChallengeCollectorDbContext context)
    {
        _context = context;
    }

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (string.IsNullOrWhiteSpace(Passphrase) || Passphrase.Length > 200)
        {
            ErrorMessage = "You need to provide a passphrase (200 characters or less) before you submit.";
            return Page();
        }

        if (FileUpload == null)
        {
            ErrorMessage = "You need to select a file before you submit.";
            return Page();
        }

        var ms1 = new MemoryStream();
        var ms2 = new MemoryStream();

        FileUpload.CopyTo(ms1);
        if (TestFileUpload != null)
            TestFileUpload.CopyTo(ms2);

        var response = new ChallengeResponse
        {
            Id = Guid.NewGuid(),
            ResultFile = ms1.ToArray(),
            ResultFileSize = FileUpload.Length,
            TestFile = ms2.ToArray(),
            TestFileSize = TestFileUpload?.Length,
            CreatedAtUtc = DateTimeOffset.UtcNow,
            Passphrase = Passphrase,
            UniqueHandle = ShortGuid.Encode(Guid.NewGuid())
        };
        
        _context.ChallengeResponses.Add(response);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Success", new { id = $"{response.Id}" });
    }
}