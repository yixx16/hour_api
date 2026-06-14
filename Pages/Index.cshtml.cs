using Horas.Domain.Entities;
using Horas.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Horas.Pages
{
    public class IndexModel : PageModel
    {
        private readonly HourService _hourService;

        public IndexModel(HourService hourService) => _hourService = hourService;

        public IReadOnlyList<Hour> Hours { get; private set; } = Array.Empty<Hour>();

        public void OnGet()
        {
            Hours = _hourService.GetAll()
                .OrderByDescending(h => h.LastModified)
                .ToList();
        }

        public IActionResult OnPostDelete(int id)
        {
            _hourService.Del(id);
            return RedirectToPage();
        }
    }
}
