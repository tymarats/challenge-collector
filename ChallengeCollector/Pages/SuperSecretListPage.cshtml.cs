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

        public IList<ChallengeResponse> ChallengeResponse { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.ChallengeResponses != null)
            {
                ChallengeResponse = await _context.ChallengeResponses
                    .OrderByDescending(a => a.CreatedAtUtc)
                    .ToListAsync();
            }
        }
    }
}
