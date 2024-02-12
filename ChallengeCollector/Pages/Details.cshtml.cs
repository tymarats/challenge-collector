using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ChallengeCollector;
using ChallengeCollector.Models;
using System.Text;

namespace ChallengeCollector.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly ChallengeCollector.ChallengeCollectorDbContext _context;

        public DetailsModel(ChallengeCollector.ChallengeCollectorDbContext context)
        {
            _context = context;
        }

        public ChallengeResponse ChallengeResponse { get; set; } = default!;

        public string ResultFileText { get; set; }
        public string? TestFileText { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.ChallengeResponses == null)
            {
                return NotFound();
            }

            var data = await _context.ChallengeResponses.FirstOrDefaultAsync(m => m.Id == id);
            
            if (data == null)
            {
                return NotFound();
            }
            else
            {
                ChallengeResponse = data;
                ResultFileText = Encoding.UTF8.GetString(data.ResultFile);
                TestFileText = data.TestFile != null ? Encoding.UTF8.GetString(data.TestFile) : null;
            }

            return Page();
        }
    }
}
