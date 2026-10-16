using LW2.Data;
using LW2.Models;
using LW2.Services;

Console.OutputEncoding = System.Text.Encoding.Unicode;

var db = new StoreDatabase();

int laptopId = db.Products.AddItem(new Product("Ноутбук", 35000));
int mouseId = db.Products.AddItem(new Product("Мишка", 800));
int keyboardId = db.Products.AddItem(new Product("Клавіатура", 1500));
int monitorId = db.Products.AddItem(new Product("Монітор", 12000));

int computersId = db.Categories.AddItem(new Category("Комп'ютери"));
int peripheralsId = db.Categories.AddItem(new Category("Периферія"));
int monitorsId = db.Categories.AddItem(new Category("Монітори"));

db.Descriptions.AddItem(new Description("Потужний ноутбук для роботи", laptopId));
db.Descriptions.AddItem(new Description("Бездротова мишка", mouseId));
db.Descriptions.AddItem(new Description("Механічна клавіатура", keyboardId));
db.Descriptions.AddItem(new Description("Монітор з IPS матрицею", monitorId));

db.ProductCategories.AddItem(new ProductCategory(laptopId, computersId));
db.ProductCategories.AddItem(new ProductCategory(laptopId, peripheralsId));
db.ProductCategories.AddItem(new ProductCategory(mouseId, peripheralsId));
db.ProductCategories.AddItem(new ProductCategory(keyboardId, peripheralsId));
db.ProductCategories.AddItem(new ProductCategory(monitorId, monitorsId));

int customer1Id = db.Customers.AddItem(new Customer("Олексій"));
int customer2Id = db.Customers.AddItem(new Customer("Марія"));

int employee1Id = db.Employees.AddItem(new Employee("Іван", "Менеджер"));
int employee2Id = db.Employees.AddItem(new Employee("Олена", "Продавець"));

int order1Id = db.Orders.AddItem(new Order("Замовлення №1", customer1Id, employee1Id));
int order2Id = db.Orders.AddItem(new Order("Замовлення №2", customer2Id, employee2Id));

db.OrderProducts.AddItem(new OrderProduct(order1Id, laptopId));
db.OrderProducts.AddItem(new OrderProduct(order1Id, mouseId));
db.OrderProducts.AddItem(new OrderProduct(order2Id, keyboardId));
db.OrderProducts.AddItem(new OrderProduct(order2Id, monitorId));

var service = new StoreService(db);

service.PrintProducts();
service.PrintOrders();