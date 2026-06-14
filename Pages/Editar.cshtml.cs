using System.ComponentModel.DataAnnotations;
using Horas.Api.Request;
using Horas.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Horas.Pages
{
    public class EditarModel : PageModel
    {
        private readonly HourService _hourService;

        public EditarModel(HourService hourService) => _hourService = hourService;

        [BindProperty]
        public EditInput Input { get; set; } = new();

        public DateTime LastModified { get; private set; }

        public IActionResult OnGet(int id)
        {
            var hour = _hourService.Get(id);
            Input = new EditInput { Id = hour.Id, H = hour.H, M = hour.M, S = hour.S };
            LastModified = hour.LastModified;
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            _hourService.Update(new PutRequest
            {
                Id = Input.Id,
                H = Input.H,
                M = Input.M,
                S = Input.S
            });

            return RedirectToPage("Index");
        }
    }

    public class EditInput
    {
        public int Id { get; set; }

        [Range(0, 999, ErrorMessage = "0–999")]
        public int H { get; set; }

        [Range(0, 59, ErrorMessage = "0–59")]
        public int M { get; set; }

        [Range(0, 59, ErrorMessage = "0–59")]
        public int S { get; set; }
    }
}
