public class Product
{
    // Id is an integer, a value type.
    public int Id { get; set; }

    // Name is a string, a reference type.
    public string Name { get; set; }

    // Description is a nullable string, a reference type that can be null.
    public string? Description { get; set; }

    // Price is a double, a value type.
    public double Price { get; set; }
}
public class Customer
{
    // CustomerId is an integer, a value type.
    public int CustomerId { get; set; }

    // Name is a string, a reference type.
    public string Name { get; set; }

    // Email is a nullable string, a reference type that can be null.
    public string? Email { get; set; }
}
public class Order
{
    // OrderId is an integer, a value type.
    public int OrderId { get; set; }

    // Products is a List of Product objects, a reference type.
    public List<Product> Products { get; set; }

    // Customer is a Customer object, a reference type.
    public Customer Customer { get; set; }

    // OrderDate is a nullable DateTime, a value type that can be null.
    public DateTime? OrderDate { get; set; }
}
public class StoreManager
{
    // A list of customers, a reference type.
    private List<Customer> customers = new List<Customer>();

    // A list of products, a reference type.
    private List<Product> products = new List<Product>();

    // A list of orders, a reference type.
    private List<Order> orders = new List<Order>();

    public void AddCustomer(Customer customer)
    {
        // Check if the customer's name is null, empty, or whitespace.
        if (string.IsNullOrWhiteSpace(customer.Name))
        {
            // If the customer's name is not valid, throw an exception.
            throw new ArgumentException("Customer name cannot be null or empty.");
        }
        // Add the customer to the list of customers.
        customers.Add(customer);
    }

    public void AddProduct(Product product)
    {
        // Check if the product's name is null, empty, or whitespace.
        if (string.IsNullOrWhiteSpace(product.Name))
        {
            // If the product's name is not valid, throw an exception.
            throw new ArgumentException("Product name cannot be null or empty.");
        }
        // Add the product to the list of products.
        products.Add(product);
    }

    public void AddOrder(Order order)
    {
        // Add the order to the list of orders.
        orders.Add(order);
    }

    public Order? FindOrderById(int orderId)
    {
        // Find an order by its ID. Returns null if not found.
        return orders.Find(x => x.OrderId == orderId);
    }

    public void GenerateReport()
    {
        // Loop through each order in the list of orders.
        foreach (var order in orders)
        {
            // Print the order ID and the customer's name.
            Console.WriteLine($"Order ID: {order.OrderId}");
            Console.WriteLine($"Customer: {order.Customer.Name}");
            Console.WriteLine("Products:");

            // Loop through each product in the order's product list.
            foreach (var product in order.Products)
            {
                // Print the product name and price.
                Console.WriteLine($"- {product.Name} ({product.Price})");
            }

            // Check if the order date has a value.
            if (order.OrderDate.HasValue)
            {
                // Print the order date.
                Console.WriteLine($"Order Date: {order.OrderDate.Value}");
            }
            else
            {
                // Print that the order date is not set.
                Console.WriteLine("Order Date: Not set");
            }

            // Print an empty line for spacing.
            Console.WriteLine();
        }
    }
}
public class Program
{
    public static void Main(string[] args)
    {
        // Create an instance of StoreManager.
        StoreManager storeManager = new StoreManager();

        // Fake customer data
        List<Customer> customers = new List<Customer>
        {
            new Customer { CustomerId = 1, Name = "John Doe", Email = "john@example.com" },
            new Customer { CustomerId = 2, Name = "Jane Smith", Email = null },
            new Customer { CustomerId = 3, Name = "Alice Johnson", Email = "alice@example.com" },
            new Customer { CustomerId = 4, Name = "Michael Brown", Email = "michael@example.com" },
            new Customer { CustomerId = 5, Name = "Emily Davis", Email = null }
        };

        // Fake product data
        List<Product> products = new List<Product>
        {
            new Product { Id = 1, Name = "Laptop", Price = 1500.00, Description = "High performance laptop" },
            new Product { Id = 2, Name = "Smartphone", Price = 800.00, Description = "Latest model smartphone" },
            new Product { Id = 3, Name = "Headphones", Price = 200.00, Description = null },
            new Product { Id = 4, Name = "Keyboard", Price = 50.00, Description = "Mechanical keyboard" },
            new Product { Id = 5, Name = "Mouse", Price = 25.00, Description = "Wireless mouse" }
        };

        // Fake order data
        List<Order> orders = new List<Order>
        {
            new Order { OrderId = 1, Customer = customers[0], Products = new List<Product> { products[0], products[1] }, OrderDate = DateTime.Now.AddDays(-10) },
            new Order { OrderId = 2, Customer = customers[1], Products = new List<Product> { products[2] }, OrderDate = DateTime.Now.AddDays(-5) },
            new Order { OrderId = 3, Customer = customers[2], Products = new List<Product> { products[3], products[4] }, OrderDate = null },
            new Order { OrderId = 4, Customer = customers[3], Products = new List<Product> { products[1], products[2], products[3] }, OrderDate = DateTime.Now.AddDays(-3) },
            new Order { OrderId = 5, Customer = customers[4], Products = new List<Product> { products[0], products[4] }, OrderDate = DateTime.Now.AddDays(-1) }
        };

        // Add fake customer data to the StoreManager
        foreach (var customer in customers)
        {
            storeManager.AddCustomer(customer);
        }

        // Add fake product data to the StoreManager
        foreach (var product in products)
        {
            storeManager.AddProduct(product);
        }

        // Add fake order data to the StoreManager
        foreach (var order in orders)
        {
            storeManager.AddOrder(order);
        }

        // Generate the report
        storeManager.GenerateReport();
    }
}
