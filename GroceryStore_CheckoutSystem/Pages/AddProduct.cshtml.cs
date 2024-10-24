using Microsoft.AspNetCore.Mvc.RazorPages;
using GroceryStore_CheckoutSystem.Models;
using Microsoft.AspNetCore.Mvc;
public class AddProductModel : PageModel
{
    private readonly Store _store;

    public AddProductModel(Store store)
    {
        _store = store;
    }

    [BindProperty]
    public Product NewProduct { get; set; }

    public void OnPost()
    {
        if (ModelState.IsValid)
        {
            _store.AddProduct(NewProduct);
        }
    }
}