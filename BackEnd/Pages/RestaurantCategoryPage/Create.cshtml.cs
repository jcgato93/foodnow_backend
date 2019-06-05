using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BackEnd.Contexts;
using BackEnd.Models;

namespace BackEnd.Pages.RestaurantCategoryPage
{
    public class CreateModel : PageModel
    {
        private readonly BackEnd.Contexts.ApplicationDbContext _context;

        public CreateModel(BackEnd.Contexts.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name");
        ViewData["RestaurantId"] = new SelectList(_context.Restaurants, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public RestaurantCategory RestaurantCategory { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.RestaurantCategories.Add(RestaurantCategory);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}