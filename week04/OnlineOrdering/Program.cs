using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the OnlineOrdering Project.");
        
        Customer customer1 = new Customer("Siyanda Mpofu", new Address("20 Sagewood St", "Midrand", "GP", "South Africa"));
        Customer customer2 = new Customer("Alice Ngwenya", new Address("18 Castor St", "Soweto", "GP", "South Africa"));

        Product product1 = new Product("Laptop", "P001", 999.99m, 1);
        Product product2 = new Product("Mouse", "P002", 25.50m, 2);
        Product product3 = new Product("Keyboard", "P003", 49.99m, 1);
        Product product4 = new Product("Monitor", "P004", 199.99m, 1);
        Product product5 = new Product("Headphones", "P005", 79.99m, 2);

        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);
        order1.AddProduct(product3);

        Order order2 = new Order(customer2);
        order2.AddProduct(product4);
        order2.AddProduct(product5);

        DisplayOrderDetails(order1);
        DisplayOrderDetails(order2);
    }

    static void DisplayOrderDetails(Order order)
    {
        Console.WriteLine("Packing Label:");
        Console.WriteLine(order.GetPackingLabel());
        Console.WriteLine();

        Console.WriteLine("Shipping Label:");
        Console.WriteLine(order.GetShippingLabel());
        Console.WriteLine();

        Console.WriteLine($"Total Cost: ${order.GetTotalPrice():F2}");
        Console.WriteLine(new string('-', 40));
    }
}

class Product
{
    private string _name;
    private string _productId;
    private decimal _price;
    private int _quantity;

    public Product(string name, string productId, decimal price, int quantity)
    {
        _name = name;
        _productId = productId;
        _price = price;
        _quantity = quantity;
    }

    public string GetName() => _name;
    public string GetProductId() => _productId;
    public decimal GetTotalCost() => _price * _quantity;
}

class Customer
{
    private string _name;
    private Address _address;

    public Customer(string name, Address address)
    {
        _name = name;
        _address = address;
    }

    public string GetName() => _name;
    public Address GetAddress() => _address;
    public bool IsInUSA() => _address.IsInUSA();
}

class Address
{
    private string _street;
    private string _city;
    private string _state;
    private string _country;

    public Address(string street, string city, string state, string country)
    {
        _street = street;
        _city = city;
        _state = state;
        _country = country;
    }

    public bool IsInUSA() => _country.ToUpper() == "USA";

    public string GetFullAddress()
    {
        return $"{_street}\n{_city}, {_state}\n{_country}";
    }
}

class Order
{
    private List<Product> _products;
    private Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public decimal GetTotalPrice()
    {
        decimal totalCost = 0;
        foreach (var product in _products)
        {
            totalCost += product.GetTotalCost();
        }

        // Add shipping cost
        totalCost += _customer.IsInUSA() ? 5 : 35;
        return totalCost;
    }

    public string GetPackingLabel()
    {
        string packingLabel = "";
        foreach (var product in _products)
        {
            packingLabel += $"{product.GetName()} (ID: {product.GetProductId()})\n";
        }
        return packingLabel;
    }

    public string GetShippingLabel()
    {
        return $"{_customer.GetName()}\n{_customer.GetAddress().GetFullAddress()}";
    }
}