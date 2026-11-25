using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SignalRazorCrud.Models;

namespace SignalRazorCrud.Pages.Courses
{
    public class IndexModel : PageModel
    {
        private readonly SignalRazorCrud.Models.SchoolContextDBContext _context;

        public IndexModel(SignalRazorCrud.Models.SchoolContextDBContext context)
        {
            _context = context;
        }

        public IList<Course> Course { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Courses != null)
            {
                Course = await _context.Courses
                .Include(c => c.Department).ToListAsync();
            }
        }
    }
}
