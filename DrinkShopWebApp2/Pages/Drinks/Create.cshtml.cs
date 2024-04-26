using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DrinkShopWebApp2.Data;
using DrinkShopWebApp2.Models;

namespace DrinkShopWebApp2.Pages.Drinks
{
    public class CreateModel : PageModel
    {
        private readonly DrinkShopWebApp2.Data.DrinkShopWebAppDbContext _context;

        public CreateModel(DrinkShopWebApp2.Data.DrinkShopWebAppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Drink Drink { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Drinks == null || Drink == null)
            {
                return Page();
            }

            _context.Drinks.Add(Drink);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
