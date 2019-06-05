using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BackEnd.Contexts;
using BackEnd.Models;

namespace BackEnd.Pages.ProductPage
{
    public class DetailsModel : PageModel
    {
        private readonly BackEnd.Contexts.ApplicationDbContext _context;

        public DetailsModel(BackEnd.Contexts.ApplicationDbContext context)
        {
            _context = context;
        }

        public Product Product { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product = await _context.Products
                .Include(p => p.category)
                .Include(p => p.restaurant).FirstOrDefaultAsync(m => m.Id == id);

            if (Product == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
