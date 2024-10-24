using Microsoft.AspNetCore.Mvc.RazorPages;
using GroceryStore_CheckoutSystem.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

public class CustomerOrderModel : PageModel
{
    private readonly Store _store;

    public CustomerOrderModel(Store store)
    {
        _store = store;
        AvailableProducts = new List<Product>();
    }

    [BindProperty]
    public int ProductId { get; set; }

    [BindProperty]
    public int Quantity { get; set; }

    public List<Product> AvailableProducts { get; private set; }

    public List<(Product Product, int Quantity)> Cart { get; private set; } = new List<(Product, int)>();

    public void OnGet()
    {
        AvailableProducts = _store.Products ?? new List<Product>();
    }

    public void OnPostAddToCart()
    {
        var product = _store.Products.Find(p => p.ProductId == ProductId);
        if (product != null)
        {
            Cart.Add((product, Quantity));
        }
        AvailableProducts = _store.Products;
    }

    public void OnPostGenerateReceipt()
    {
        string folderPath = @"C:\Users\nelly\Desktop\RazorStore\GroceryStore_CheckoutSystem\GroceryStore_CheckoutSystem";
        string receiptFileName = "PAY.txt";
        string filePath = Path.Combine(folderPath, receiptFileName);

        // Kontrollera om mappen finns, annars skapa den
        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }

        // Generera kvittoinnehåll
        string receiptContent = "Receipt:\n";
        decimal totalAmount = 0;

        foreach (var item in Cart)
        {
            decimal itemTotal = item.Product.Price * item.Quantity;
            totalAmount += itemTotal;
            receiptContent += $"{item.Quantity} x {item.Product.Name} @ {item.Product.Price:C2} = {itemTotal:C2}\n";
        }

        receiptContent += $"\nTotal: {totalAmount:C2}\n";

        // Skriv kvittot till filen
        System.IO.File.WriteAllText(filePath, receiptContent);  // Använd fullständiga System.IO.File
    }
}