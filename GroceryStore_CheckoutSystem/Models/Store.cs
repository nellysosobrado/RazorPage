namespace GroceryStore_CheckoutSystem.Models
{
    public class Store
    {
        public List<Product> Products { get; private set; }

        public Store()
        {
            // Starta med några exempelprodukter
            Products = new List<Product>
            {
                new Product { ProductId = 300, Name = "Apple", Price = 1.99m },
                new Product { ProductId = 301, Name = "Orange", Price = 1.49m }
            };
        }

        public void AddProduct(Product product)
        {
            Products.Add(product);
        }
    }
}