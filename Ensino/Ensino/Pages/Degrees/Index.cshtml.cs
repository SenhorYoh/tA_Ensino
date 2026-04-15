using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Ensino.Data;
using Ensino.Data.Model;

namespace Ensino.Pages.Degrees
{
    public class IndexModel : PageModel
    {
        private readonly Ensino.Data.ApplicationDbContext _context;

        public IndexModel(Ensino.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Degree> Degree { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Degree = await _context.Degree.ToListAsync();
        }
    }
}
