// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");

using System.Security.Cryptography;
using PizzaStore;

CustomerList customerList = new CustomerList();
PizzaDictionary pizzaDictionary = new PizzaDictionary();

Menu menu = new Menu(customerList, pizzaDictionary);
menu.Run();
Console.ReadLine();