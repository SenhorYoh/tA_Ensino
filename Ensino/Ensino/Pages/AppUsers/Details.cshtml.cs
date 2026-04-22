using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Ensino.Data;
using Ensino.Data.Model;

namespace Ensino.Pages.AppUsers
{
    public class DetailsModel : PageModel
    {
        private readonly Ensino.Data.ApplicationDbContext _context;

        public DetailsModel(Ensino.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public MyUser MyUser { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var myuser = await _context.MyUser.FirstOrDefaultAsync(m => m.Id == id);

            if (myuser is not null)
            {
                MyUser = myuser;

                return Page();
            }

            return NotFound();
        }
    }
}
