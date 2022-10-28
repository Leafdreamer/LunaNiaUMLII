using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PizzaStore
{
    public class Menu
    {
        private CustomerList _customerList;
        private PizzaDictionary _pizzaDictionary;
        public Menu(CustomerList customerList, PizzaDictionary pizzaDictionary)
        {
            _customerList = customerList;
            _pizzaDictionary = pizzaDictionary;
        }

        public int ReadUserChoice()
        {
            string choice = Console.ReadLine();
            int input = -1;
            if (int.TryParse(choice, out input))
            {
                return input;
            }
            else
            {
                return -1;
            }
        }

        public int ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("\t---------------Customer Methods--------------------");
            Console.WriteLine("\t1.\tAdd a Customer");
            Console.WriteLine("\t2.\tRemove a Customer");
            Console.WriteLine("\t3.\tUpdate a Customer");
            Console.WriteLine("\t4.\tSearch for a Customer");
            Console.WriteLine("\t5.\tPrint out all Customers");
            Console.WriteLine("\t---------------Pizza Methods--------------------");
            Console.WriteLine("\t6.\tAdd a Pizza");
            Console.WriteLine("\t7.\tRemove a Pizza");
            Console.WriteLine("\t8.\tUpdate a Pizza");
            Console.WriteLine("\t9.\tSearch for a Pizza");
            Console.WriteLine("\t10.\tPrint out all Pizzas");
            Console.WriteLine("\t---------------Other Methods--------------------");
            Console.WriteLine("\t0.\tClose program");
            Console.WriteLine("\t-----------------------------------");
            Console.Write("\tEnter number: ");
            return ReadUserChoice();
        }

        public void Run()
        {
            int valg = ShowMenu();
            while (valg != 0)
            {
                switch (valg)
                {
                    case 1:
                        Console.Clear();
                        // Method that adds a customer to the database
                        AddCustomerToList();
                        break;
                    case 2:
                        // Method that deletes a customer from the database, found through their name
                        Console.Clear();
                        DeleteCustomerFromList();
                        break;
                    case 3:
                        // Method that updates a customer from the database based on their name
                        Console.Clear();
                        UpdateCustomerList();
                        break;
                    case 4:
                        // Method that searches for a customer from the database according to their name
                        Console.Clear();
                        SearchCustomerList();
                        break;
                    case 5:
                        // Prints out all customers from the database
                        Console.Clear();
                        Console.WriteLine("Printing customers...");
                        _customerList.PrintCustomerList();
                        break;
                    case 6:
                        // Adds a pizza to the database
                        Console.Clear();
                        AddPizzaToList();
                        break;
                    case 7:
                        // Deletes a pizza from the database based on its number
                        Console.Clear();
                        DeletePizzaFromList();
                        break;
                    case 8:
                        // Updates a pizza based on its number
                        Console.Clear();
                        UpdatePizzaList();
                        break;
                    case 9:
                        // Searches for a pizza based on its number
                        Console.Clear();
                        SearchPizzaList();
                        break;
                    case 10:
                        // Prints out all pizzas from the database
                        Console.Clear();
                        Console.WriteLine("Printing pizzas...");
                        _pizzaDictionary.PrintPizzaList();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Something unexpected happened. Perhaps you typed something incorrectly?");
                        break;
                }
                Console.ReadLine();
                Console.Clear();
                valg = ShowMenu();

            }

        }



        private void AddCustomerToList()
        {
            Console.WriteLine("Adding customer...");
            Console.WriteLine("Enter name: ");
            string name = Console.ReadLine();
            if (name == null)
                Console.WriteLine("Error, customer name must not be empty.");
            else
            {
                Console.WriteLine("Enter address: ");
                string address = Console.ReadLine();
                if (address == null)
                    Console.WriteLine("Error, address field must not be empty.");
                else
                {
                    Console.WriteLine("Enter phone number:");
                    string phone = Console.ReadLine();
                    if (phone == null)
                        Console.WriteLine("Error, phone number must not be empty.");
                    else
                    {
                        Customer a = new Customer(name, address, phone);
                        _customerList.AddCustomer(a);
                        Console.WriteLine($"Customer added, say hi to {name}!");
                    }
                }
            }
        }
        private void DeleteCustomerFromList()
        {
            Console.WriteLine("Deleting customer...");
            Console.WriteLine("Enter name: ");
            string name = Console.ReadLine();
            if (name == null)
                Console.WriteLine("Error, customer name must not be empty.");
            else
            {
                _customerList.DeleteCustomer(name);
                Console.WriteLine("Customer deletion successful. If they were there, they certainly aren't now.");
            }
        }

        private void SearchCustomerList()
        {
            Console.WriteLine("Searching for customer...");
            Console.WriteLine("Enter name: ");
            string name = Console.ReadLine();
            if (name == null)
                Console.WriteLine("Error, customer name must not be empty.");
            else
            {
                Customer b = _customerList.LookupCustomer(name);
                if (b == null)
                {
                    Console.WriteLine("No customer with that name found.");
                }
                else
                {
                    Console.WriteLine(b);
                }
                Console.ReadLine();
            }
        }

        private void UpdateCustomerList()
        {
            Console.WriteLine("Updating customer...");
            Console.WriteLine("Enter name: ");
            string name0 = Console.ReadLine();
            if (name0 == null)
                Console.WriteLine("Error, customer name must not be empty.");
            else
            {
                Customer c = _customerList.LookupCustomer(name0);
                if (c == null)
                {
                    Console.WriteLine("No customer with that name found.");
                }
                else
                {
                    Console.WriteLine("Customer found, enter new details...");
                    Console.WriteLine("Enter name: ");
                    string name = Console.ReadLine();
                    if (name == null)
                        Console.WriteLine("Error, customer name must not be empty.");
                    else
                    {
                        Console.WriteLine("Enter address: ");
                        string address = Console.ReadLine();
                        if (address == null)
                            Console.WriteLine("Error, address field must not be empty.");
                        else
                        {
                            Console.WriteLine("Enter phone number:");
                            string phone = Console.ReadLine();
                            if (phone == null)
                                Console.WriteLine("Error, phone number must not be empty.");
                            else
                            {
                                Customer c1 = new Customer(name, address, phone);

                                _customerList.UpdateCustomer(name0, c1);
                                Console.WriteLine($"Customer updated successfully, say hi again to {name}.");
                                Console.ReadLine();
                            }
                        }
                    }

                }

            
            }
        }

        private void AddPizzaToList()
        {
            Console.WriteLine("Adding pizza...");
            Console.WriteLine("Enter pizza number: ");
            string pizzaNo = Console.ReadLine();
            int number;
            bool isParsable = Int32.TryParse(pizzaNo, out number);
            if (isParsable == false)
                Console.WriteLine("Error, input was likely not a valid pizza number.");
            else
            {
                if (_pizzaDictionary.CheckPizza(number))
                    Console.WriteLine("Error, pizza with that number already exists.");
                else
                {
                    Console.WriteLine("Enter pizza size: ");
                    string pizzaSize = Console.ReadLine();
                    if (pizzaSize == null)
                        Console.WriteLine("Error, pizza size value must not be empty.");
                    else
                    {
                        Console.WriteLine("Enter pizza price:");
                        string pizzaPrice = Console.ReadLine();
                        double price;
                        bool isParsable2 = Double.TryParse(pizzaPrice, out price);
                        if (isParsable == false)
                            Console.WriteLine();
                        else
                        {
                            Pizza a = new Pizza(number, pizzaSize, price);
                            _pizzaDictionary.AddPizza(a);
                            Console.WriteLine("Pizza has been added.");
                        }
                    }
                }
                
            }
            
        }

        private void DeletePizzaFromList()
        {
            Console.WriteLine("Deleting pizza...");
            Console.WriteLine("Enter pizza number: ");
            string pizzaNo = Console.ReadLine();
            int number;
            bool isParsable = Int32.TryParse(pizzaNo, out number);
            if (isParsable)
            {
                if (_pizzaDictionary.CheckPizza(number))
                {
                    _pizzaDictionary.DeletePizza(number);
                    Console.WriteLine("Pizza deletion successful.");
                }
                else
                    Console.WriteLine("No pizza found under that number.");
                
            }
            else
                Console.WriteLine("Error, input was likely not a valid pizza number.");

        }


        private void SearchPizzaList()
        {
            Console.WriteLine("Searching for pizza...");
            Console.WriteLine("Enter pizza number: ");
            string pizzaNo = Console.ReadLine();
            int number;
            bool isParsable = Int32.TryParse(pizzaNo, out number);
            if (isParsable)
            {
                Pizza b = _pizzaDictionary.LookupPizza(number);
                if (b == null)
                {
                    Console.WriteLine("No pizza found under that number.");
                }
                else
                {
                    Console.WriteLine(b);
                }
                Console.ReadLine();
            }
            else
                Console.WriteLine("Error, input was likely not a valid pizza number.");
            
        }

        private void UpdatePizzaList()
        {
            Console.WriteLine("Updating pizza...");
            Console.WriteLine("Enter pizza number: ");
            string pizzaName0 = Console.ReadLine();
            int oldNumber;
            bool isParsable = Int32.TryParse(pizzaName0, out oldNumber);
            if (isParsable)
            {
                Pizza c = _pizzaDictionary.LookupPizza(oldNumber);
                if (c == null)
                {
                    Console.WriteLine("No pizza found under that number.");
                }
                else
                {
                    Console.WriteLine("Pizza found, enter new details...");
                    Console.WriteLine("Enter pizza number: ");
                    string pizzaNo = Console.ReadLine();
                    int number;
                    bool isParsable1 = Int32.TryParse(pizzaNo, out number);
                    if (isParsable1 == false)
                        Console.WriteLine("Error, input was likely not a valid pizza number.");
                    else
                    {
                        if (_pizzaDictionary.CheckPizza(number))
                            if (number != oldNumber)
                            {
                                Console.WriteLine("Error, pizza with that number already exists.");
                                return;
                            }

                        Console.WriteLine("Enter pizza size: ");
                        string pizzaSize = Console.ReadLine();
                        if (pizzaSize == null)
                            Console.WriteLine("Error, pizza size value must not be empty.");
                        else
                        {
                            Console.WriteLine("Enter pizza price:");
                            string pizzaPrice = Console.ReadLine();
                            double price;
                            bool isParsable2 = Double.TryParse(pizzaPrice, out price);
                            if (isParsable == false)
                                Console.WriteLine();
                            else
                            {
                                Pizza a = new Pizza(number, pizzaSize, price);
                                _pizzaDictionary.UpdatePizza(oldNumber, a);
                                Console.WriteLine("Pizza successfully updated.");
                            }
                        }


                    }
                }
            }
            else
                Console.WriteLine("Error, input was likely not a valid pizza number.");
        }





    }
}
