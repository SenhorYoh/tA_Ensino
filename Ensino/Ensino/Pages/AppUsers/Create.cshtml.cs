using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Ensino.Data;
using Ensino.Data.Model;

namespace Ensino.Pages.AppUsers
{
    public class CreateModel : PageModel
    {
        private readonly Ensino.Data.ApplicationDbContext _context;

        public CreateModel(Ensino.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public MyUser MyUser { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.MyUser.Add(MyUser);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
