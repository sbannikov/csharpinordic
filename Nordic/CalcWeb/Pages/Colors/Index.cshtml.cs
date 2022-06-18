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
    public class IndexModel : PageModel
    {
        private readonly Calculator.Common.Storage.DB _context;

        public IndexModel()
        {
            _context = new DB();
        }

        public IList<Color> Color { get;set; }

        public async Task OnGetAsync()
        {
            Color = await _context.Colors.OrderBy(x=>x.Name).ToListAsync();
        }
    }
}
