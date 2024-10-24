using Microsoft.AspNetCore.Mvc.RazorPages;
using GroceryStore_CheckoutSystem.Models;
using System.Collections.Generic;

public class ProductsModel : PageModel
{
    private readonly Store _store;

    public ProductsModel(Store store)
    {
        _store = store;
    }

    public List<Product> Products { get; private set; }

    public void OnGet()
    {
        Products = _store.Products;  // Hämta alla produkter från Store
    }
}
