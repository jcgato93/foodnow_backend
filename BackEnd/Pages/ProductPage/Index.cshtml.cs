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
    public class IndexModel : PageModel
    {
        private readonly BackEnd.Contexts.ApplicationDbContext _context;

        public IndexModel(BackEnd.Contexts.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Product> Product { get;set; }

        public async Task OnGetAsync()
        {
            Product = await _context.Products
                .Include(p => p.category)
                .Include(p => p.restaurant).ToListAsync();
        }
    }
}
