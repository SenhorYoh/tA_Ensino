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
    public class DeleteModel : PageModel
    {
        private readonly Ensino.Data.ApplicationDbContext _context;

        public DeleteModel(Ensino.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var myuser = await _context.MyUser.FindAsync(id);
            if (myuser != null)
            {
                MyUser = myuser;
                _context.MyUser.Remove(MyUser);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
