using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;                       // <-- FALTAVA ESTE (para Path, FileStream, Directory)
using Microsoft.AspNetCore.Http;       // <-- FALTAVA ESTE (para IFormFile)
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Hosting;
using Ensino.Data;
using Ensino.Data.Model;

namespace Ensino.Pages.Degrees
{
    public class CreateModel : PageModel
    {
        private readonly Ensino.Data.ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CreateModel(Ensino.Data.ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        [BindProperty]
        public Degree Degree { get; set; } = default!;

        [BindProperty]
        public IFormFile ImagemLogo { get; set; } = default!;

        public IActionResult OnGet() => Page();

        public async Task<IActionResult> OnPostAsync()
        {
            // 1. Verificação básica
            if (ImagemLogo == null || ImagemLogo.Length == 0)
            {
                ModelState.AddModelError("ImagemLogo", "Por favor, selecione uma imagem.");
                return Page();
            }

            // 2. Verificação de extensão/tipo
            var allowedTypes = new[] { "image/jpg", "image/jpeg", "image/png" };
            if (!allowedTypes.Contains(ImagemLogo.ContentType))
            {
                ModelState.AddModelError("ImagemLogo", "Formato inválido. Use JPG ou PNG.");
                return Page();
            }

            if (!ModelState.IsValid) return Page();

            // 3. Preparar o ficheiro
            string uniqueFileName = Guid.NewGuid().ToString() + "_" + ImagemLogo.FileName;
            string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);

            try
            {
                // Criar a pasta se ela não existir
                if (!Directory.Exists(uploadsFolder)) Directory.CreateDirectory(uploadsFolder);

                // GUARDAR NO DISCO
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await ImagemLogo.CopyToAsync(fileStream);
                }

                // GUARDAR NA BASE DE DADOS
                Degree.Logotype = uniqueFileName;
                _context.Degree.Add(Degree);
                await _context.SaveChangesAsync();

                return RedirectToPage("./Index");
            }
            catch (Exception)
            {
                // Se der erro ao guardar na BD, apaga a imagem que foi para o disco
                if (System.IO.File.Exists(filePath)) System.IO.File.Delete(filePath);

                ModelState.AddModelError(string.Empty, "Erro ao processar o registo. Tente novamente.");
                return Page();
            }
        }
    }
}