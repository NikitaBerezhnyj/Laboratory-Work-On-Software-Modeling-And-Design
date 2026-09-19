using PW1.Models;
using PW1.Repository;
using PW1.Services;

Console.OutputEncoding = System.Text.Encoding.Unicode;

DBItem<Product> products = new();

products.AddItem(new Product("Ноутбук", 35000));
products.AddItem(new Product("Мишка", 800));
products.AddItem(new Product("Клавіатура", 1500));
products.AddItem(new Product("Монітор", 12000));

DBItem<Category> categories = new();

categories.AddItem(new Category("Комп'ютери"));
categories.AddItem(new Category("Периферія"));
categories.AddItem(new Category("Монітори"));

DBItem<Description> descriptions = new();

descriptions.AddItem(new Description("Потужний ноутбук для роботи", 1));
descriptions.AddItem(new Description("Бездротова мишка", 2));
descriptions.AddItem(new Description("Механічна клавіатура", 3));
descriptions.AddItem(new Description("Монітор з IPS матрицею", 4));

DBItem<ProductCategory> productCategories = new();

productCategories.AddItem(new ProductCategory(1, 1));
productCategories.AddItem(new ProductCategory(1, 2));
productCategories.AddItem(new ProductCategory(2, 2));
productCategories.AddItem(new ProductCategory(3, 2));
productCategories.AddItem(new ProductCategory(4, 3));

var service = new StoreService(
    products,
    descriptions,
    categories,
    productCategories
);

service.PrintProducts();