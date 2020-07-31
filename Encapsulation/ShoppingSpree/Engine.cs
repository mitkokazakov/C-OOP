using ShoppingSpree.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ShoppingSpree
{
    public class Engine
    {
        private List<Person> people;
        private List<Product> products;

        public Engine()
        {
            this.people = new List<Person>();
            this.products = new List<Product>();
        }

        public void Run()
        {
            AddPerson();
            AddProduct();

            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] inputInfo = input.Split();
                string personName = inputInfo[0];
                string productName = inputInfo[1];

                Person currentPerson = this.people.First(p => p.Name == personName);
                Product currentProduct = this.products.First(p => p.Name == productName);


                try
                {
                    currentPerson.BuyProduct(currentProduct);
                    Console.WriteLine($"{currentPerson.Name} bought {currentProduct.Name}");
                }
                catch (Exception ex)
                {

                    Console.WriteLine(String.Format(ex.Message, currentPerson.Name, currentProduct.Name));
                }

                input = Console.ReadLine();
            }

            foreach (var person in this.people)
            {
                string allProducts = person.Bag.Count == 0 ? "Nothing bought" : String.Join(", ", person.Bag);

                Console.WriteLine($"{person.Name} - {allProducts}");
            }
        }

        private void AddProduct()
        {
            string[] productInfo = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < productInfo.Length; i++)
            {
                string[] currentProduct = productInfo[i].Split("=", StringSplitOptions.RemoveEmptyEntries);

                string productName = currentProduct[0];
                decimal cost = decimal.Parse(currentProduct[1]);


                Product product = new Product(productName, cost);
                this.products.Add(product);

            }
        }

        private void AddPerson()
        {
            string[] personInfo = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);


            for (int i = 0; i < personInfo.Length; i++)
            {
                string[] currentPerson = personInfo[i].Split("=", StringSplitOptions.RemoveEmptyEntries);

                string name = currentPerson[0];
                decimal money = decimal.Parse(currentPerson[1]);

                Person person = new Person(name, money);
                this.people.Add(person);

            }
        }

    }
}
