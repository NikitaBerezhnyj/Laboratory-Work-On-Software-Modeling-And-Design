using PW1.Models;
using PW1.Repository;

namespace PW1.Services
{
    internal class StoreService
    {
        private readonly DBItem<Product> products;
        private readonly DBItem<Description> descriptions;
        private readonly DBItem<Category> categories;
        private readonly DBItem<ProductCategory> productCategories;

        public StoreService(
            DBItem<Product> products,
            DBItem<Description> descriptions,
            DBItem<Category> categories,
            DBItem<ProductCategory> productCategories)
        {
            this.products = products;
            this.descriptions = descriptions;
            this.categories = categories;
            this.productCategories = productCategories;
        }

        public void PrintProducts()
        {
            foreach (Product product in products.Items)
            {
                Console.WriteLine($"Товар: {product}");

                foreach (Description description in descriptions.Items)
                {
                    if (description.ProductId == product.Id)
                    {
                        Console.WriteLine($"\tОпис: {description.Text}");
                    }
                }

                Console.WriteLine("\tКатегорії:");

                foreach (ProductCategory productCategory in productCategories.Items)
                {
                    if (productCategory.ProductId != product.Id)
                    {
                        continue;
                    }

                    foreach (Category category in categories.Items)
                    {
                        if (category.Id == productCategory.CategoryId)
                        {
                            Console.WriteLine($"\t\t{category.Name}");
                        }
                    }
                }

                Console.WriteLine();
            }
        }
    }
}
