using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Ensino.Data;
using Ensino.Data.Model;
using System.Globalization;

namespace Ensino.Pages.Students
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
            ViewData["DegreeFK"] = new SelectList(_context.Degree, "id", "name");
            return Page();
        }

        [BindProperty]
        public Student Student { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ViewData["DegreeFK"] = new SelectList(_context.Degree.OrderBy(d => d.Name), "id", "name");
                return Page();
            }

            Student.TuitionFee = Convert.ToDecimal(Student.TuitionFeeAux.Replace('.', ','), new CultureInfo("pt-PT"));

            try
            {
                _context.Student.Add(Student);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex){
                throw;
            }

            

            return RedirectToPage("./Index");
        }
    }
}
