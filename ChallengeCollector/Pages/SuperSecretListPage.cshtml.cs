using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ChallengeCollector;
using ChallengeCollector.Models;

namespace ChallengeCollector.Pages
{
    public class SuperSecretListPageModel : PageModel
    {
        private readonly ChallengeCollector.ChallengeCollectorDbContext _context;

        public SuperSecretListPageModel(ChallengeCollector.ChallengeCollectorDbContext context)
        {
            _context = context;
        }

        public IList<ChallengeResponseListItem> ChallengeResponse { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.ChallengeResponses != null)
            {
                ChallengeResponse = await _context.ChallengeResponses
                    .OrderByDescending(a => a.CreatedAtUtc)
                    .Select(a => new ChallengeResponseListItem { 
                        Id = a.Id,
                        ResultFileSize = a.ResultFileSize,
                        TestFileSize = a.TestFileSize,
                        CreatedAtUtc = a.CreatedAtUtc,
                        Passphrase = a.Passphrase,
                        UniqueHandle = a.UniqueHandle,
                    })
                    .ToListAsync();
            }
        }
    }
    
    public class ChallengeResponseListItem
    {
        public required Guid Id { get; set; }
        public required long ResultFileSize { get; set; }
        public required long? TestFileSize { get; set; }
        public required DateTimeOffset CreatedAtUtc { get; set; }
        public required string Passphrase { get; set; }
        public required string UniqueHandle { get; set; }
    }
}
