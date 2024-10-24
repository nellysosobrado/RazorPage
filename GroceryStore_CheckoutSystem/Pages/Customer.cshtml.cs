using GroceryStore_CheckoutSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GroceryStore_CheckoutSystem.Pages
{
    public class CustomerModel : PageModel
    {
        private readonly Store _store;

        public CustomerModel(Store store)
        {
            _store = store;
        }

        public List<Product> AvailableProducts { get; private set; }
        public List<(Product Product, int Quantity)> Cart { get; private set; } = new List<(Product, int)>();

        [BindProperty]
        public List<int> SelectedProductIds { get; set; }
        [BindProperty]
        public List<int> Quantities { get; set; }

        public void OnGet()
        {
            AvailableProducts = _store.Products;
        }

        public void OnPost()
        {
            for (int i = 0; i < SelectedProductIds.Count; i++)
            {
                var product = _store.Products.Find(p => p.ProductId == SelectedProductIds[i]);
                if (product != null)
                {
                    Cart.Add((product, Quantities[i]));
                }
            }
            // Generera kvittot här
        }
    }
}
