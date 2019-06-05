using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BackEnd.Contexts;
using BackEnd.Models;

namespace BackEnd.Pages.RestaurantCategoryPage
{
    public class IndexModel : PageModel
    {
        private readonly BackEnd.Contexts.ApplicationDbContext _context;

        public IndexModel(BackEnd.Contexts.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<RestaurantCategory> RestaurantCategory { get;set; }

        public async Task OnGetAsync()
        {
            RestaurantCategory = await _context.RestaurantCategories
                .Include(r => r.Category)
                .Include(r => r.Restaurant).ToListAsync();
        }
    }
}
