using System.ComponentModel.DataAnnotations;
using Horas.Api.Request;
using Horas.Domain.Entities;
using Horas.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Horas.Pages
{
    public class CalculadoraModel : PageModel
    {
        private readonly HourService _hourService;

        public CalculadoraModel(HourService hourService) => _hourService = hourService;

        [BindProperty]
        public OperandoInput A { get; set; } = new();

        [BindProperty]
        public OperandoInput B { get; set; } = new();

        public Hour? Resultado { get; private set; }

        public void OnGet() { }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            var request = new SumRequest
            {
                H1 = A.H, M1 = A.M, S1 = A.S,
                H2 = B.H, M2 = B.M, S2 = B.S
            };

            Resultado = _hourService.Sum(request);
            return Page();
        }
    }

    public class OperandoInput
    {
        [Range(0, 999, ErrorMessage = "0–999")]
        public int H { get; set; }

        [Range(0, 59, ErrorMessage = "0–59")]
        public int M { get; set; }

        [Range(0, 59, ErrorMessage = "0–59")]
        public int S { get; set; }
    }
}
