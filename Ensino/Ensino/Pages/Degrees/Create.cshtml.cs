using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Ensino.Data;
using Ensino.Data.Model;

namespace Ensino.Pages.Degrees
{
    public class CreateModel : PageModel
    {
        /// <summary>
        /// Base de dados do projeto, injetada via construtor
        /// </summary>
        private readonly Ensino.Data.ApplicationDbContext _context;

        public CreateModel(Ensino.Data.ApplicationDbContext context)
        {
            IWebHostEnvironment webHostEnvironment;
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        /// <summary>
        /// mostrar a página do Create, quando o pedido é feito em HTTP GET
        /// </summary>
        /// <returns>Create page</returns>
        public IActionResult OnGet()
        {
            return Page();
        }

        /// <summary>
        /// atributo que define o objeto a ser processado na vista(page)
        /// </summary>

        [BindProperty]
        public Degree Degree { get; set; } = default!;

        /// <summary>
        /// atributo para receber o ficheiro de imagem do curso
        /// </summary>
        /// <returns></returns>
        [BindProperty]
        public IFormFile ImagemLogo { get; set; }

        // For more information, see https://aka.ms/RazorPagesCRUD.

        /// <summary>
        /// Processa o pedido HTTP POST, 
        /// quando o formulário é submetido, 
        /// para criar um novo curso na base de dados
        /// </summary>
        /// <returns>página de listagem de todos os cursos</returns>
        public async Task<IActionResult> OnPostAsync()
        {

            if(ImagemLogo == null)
            {

            }

            if(ImagemLogo.ContentType != "image/jpg" && ImagemLogo.ContentType != "image/jpeg"){

                ModelState.AddModelError("ImagemLogo", "O ficheiro de imagem deve ser JPEG ou PNG");
                return Page();
                
            }

            var filename = Guid.NewGuid().ToString() + Path.GetExtension(ImagemLogo.FileName);



            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                _context.Degree.Add(Degree);
                await _context.SaveChangesAsync();

                return RedirectToPage("./Index");
            }
            catch (Exception ex){

                //throw;
                /*
                 * se ocorrer um erro ao guardar o curso na base de dados,
                 * ou na operação de guardar a imagem no disco rigido do servidor,
                 * devemos tratar o problema
                 * - registar o erro num ficheiro de log, para que os pro
                 * - o registo na BD e a imagem devem ser destruídas
                 * - mostrar uma mensagem de erro ao utilizador
                 * - devolver o controlo à página do create, para que o utilizador
                 */

                ModelState.AddModelError(string.Empty, "Ocorreu um erro ao guardar o curso. Tente novamente, por favor");
                return Page();
            }
        }
    }
}
