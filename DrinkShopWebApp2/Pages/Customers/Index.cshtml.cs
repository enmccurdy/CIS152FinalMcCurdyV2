using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DrinkShopWebApp2.Data;
using DrinkShopWebApp2.Models;

namespace DrinkShopWebApp2.Pages.Customers
{
    public class IndexModel : PageModel
    {
        private readonly DrinkShopWebApp2.Data.DrinkShopWebAppDbContext _context;

        public IndexModel(DrinkShopWebApp2.Data.DrinkShopWebAppDbContext context)
        {
            _context = context;
        }

        public IList<Customer> Customer { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Customers != null)
            {
                Customer = await _context.Customers.ToListAsync();
            }
        }
    }
}
