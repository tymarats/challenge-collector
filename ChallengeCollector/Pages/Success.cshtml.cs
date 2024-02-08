using ChallengeCollector;
using CSharpVitamins;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class SuccessModel : PageModel
{
    private readonly ChallengeCollectorDbContext _context;

    public long FileSize { get; private set; }
    public string? UniqueHandle { get; private set; }
    public string Passphrase { get; set; }

    public SuccessModel(ChallengeCollectorDbContext context)
    {
        _context = context;
    }

    public void OnGet(string id)
    {
        if (!Guid.TryParse(id, out Guid guid))
            guid = Guid.NewGuid();

        var response = _context.ChallengeResponses.FirstOrDefault(a => a.Id == guid);
       
        FileSize = response?.ResultFileSize ?? Random.Shared.NextInt64(100000);
        Passphrase = response?.Passphrase ?? "holly molly";
        UniqueHandle = response?.UniqueHandle ?? ShortGuid.Encode(guid);
    }
}