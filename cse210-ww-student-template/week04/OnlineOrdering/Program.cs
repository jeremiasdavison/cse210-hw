using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("1234 Corrientes Ave", "Buenos Aires", "CABA", "Argentina");
        Customer customer1 = new Customer("Jeremias Davison", address1);
        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Mechanical Keyboard", "P001", 45.00, 1));
        order1.AddProduct(new Product("Wireless Mouse", "P002", 20.00, 2));

        Address address2 = new Address("123 Main St", "Rexburg", "Idaho", "USA");
        Customer customer2 = new Customer("John Smith", address2);
        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("24-inch Monitor", "P003", 150.00, 1));
        order2.AddProduct(new Product("HDMI Cable", "P004", 8.50, 3));
        order2.AddProduct(new Product("Monitor Stand", "P005", 25.00, 1));

        List<Order> orders = new List<Order> { order1, order2 };

        int orderNumber = 1;
        foreach (Order order in orders)
        {
            Console.WriteLine($"--- Order {orderNumber} ---");
            Console.WriteLine("Packing Label:");
            Console.WriteLine(order.GetPackingLabel());
            Console.WriteLine();
            Console.WriteLine("Shipping Label:");
            Console.WriteLine(order.GetShippingLabel());
            Console.WriteLine();
            Console.WriteLine($"Total Cost: ${order.GetTotalCost():0.00}");
            Console.WriteLine();
            orderNumber++;
        }
    }
}
