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
    public class DeleteModel : PageModel
    {
        private readonly BackEnd.Contexts.ApplicationDbContext _context;

        public DeleteModel(BackEnd.Contexts.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public RestaurantCategory RestaurantCategory { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            RestaurantCategory = await _context.RestaurantCategories
                .Include(r => r.Category)
                .Include(r => r.Restaurant).FirstOrDefaultAsync(m => m.Id == id);

            if (RestaurantCategory == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            RestaurantCategory = await _context.RestaurantCategories.FindAsync(id);

            if (RestaurantCategory != null)
            {
                _context.RestaurantCategories.Remove(RestaurantCategory);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
