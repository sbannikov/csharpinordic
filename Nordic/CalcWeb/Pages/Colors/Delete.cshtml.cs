using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Calculator.Common.Storage;

namespace CalcWeb.Pages.Colors
{
    public class DeleteModel : PageModel
    {
        private readonly Calculator.Common.Storage.DB _context;

        public DeleteModel()
        {
            _context = new DB();
        }

        [BindProperty]
        public Color Color { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Color = await _context.Colors.FirstOrDefaultAsync(m => m.ID == id);

            if (Color == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Color = await _context.Colors.FindAsync(id);

            if (Color != null)
            {
                _context.Colors.Remove(Color);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
