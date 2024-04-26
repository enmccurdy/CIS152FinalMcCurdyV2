using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DrinkShopWebApp2.Data;
using DrinkShopWebApp2.Models;

namespace DrinkShopWebApp2.Pages.Orders
{
    public class DetailsModel : PageModel
    {
        private readonly DrinkShopWebApp2.Data.DrinkShopWebAppDbContext _context;

        public DetailsModel(DrinkShopWebApp2.Data.DrinkShopWebAppDbContext context)
        {
            _context = context;
        }

      public Order Order { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Orders == null)
            {
                return NotFound();
            }

            var order = await _context.Orders.FirstOrDefaultAsync(m => m.OrderId == id);
            if (order == null)
            {
                return NotFound();
            }
            else 
            {
                Order = order;
            }
            return Page();
        }
    }
}
