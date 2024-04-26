using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DrinkShopWebApp2.Data;
using DrinkShopWebApp2.Models;

namespace DrinkShopWebApp2.Pages.Drinks
{
    public class EditModel : PageModel
    {
        private readonly DrinkShopWebApp2.Data.DrinkShopWebAppDbContext _context;

        public EditModel(DrinkShopWebApp2.Data.DrinkShopWebAppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Drink Drink { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Drinks == null)
            {
                return NotFound();
            }

            var drink =  await _context.Drinks.FirstOrDefaultAsync(m => m.DrinkId == id);
            if (drink == null)
            {
                return NotFound();
            }
            Drink = drink;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Drink).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DrinkExists(Drink.DrinkId))
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

        private bool DrinkExists(int id)
        {
          return (_context.Drinks?.Any(e => e.DrinkId == id)).GetValueOrDefault();
        }
    }
}
