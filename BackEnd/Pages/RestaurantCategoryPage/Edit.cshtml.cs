using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BackEnd.Contexts;
using BackEnd.Models;

namespace BackEnd.Pages.RestaurantCategoryPage
{
    public class EditModel : PageModel
    {
        private readonly BackEnd.Contexts.ApplicationDbContext _context;

        public EditModel(BackEnd.Contexts.ApplicationDbContext context)
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
           ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name");
           ViewData["RestaurantId"] = new SelectList(_context.Restaurants, "Id", "Name");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(RestaurantCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RestaurantCategoryExists(RestaurantCategory.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool RestaurantCategoryExists(int id)
        {
            return _context.RestaurantCategories.Any(e => e.Id == id);
        }
    }
}
