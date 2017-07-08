namespace ShoppingSpree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            try
            {
                var people = GetPeople();
                var products = GetProducts();

                people = BuyProducts(people, products);

                PrintBuyersWithProducts(people);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void PrintBuyersWithProducts(List<Person> people)
        {
            foreach (var person in people)
            {
                var boughtProducts = person.GetProducts();
                var result = boughtProducts.Any()
                            ? string.Join(", ", boughtProducts.Select(p => p.Name).ToList())
                            : "Nothing bought";
                Console.WriteLine($"{person.Name} - {result}");
            }
        }

        private static List<Person> BuyProducts(List<Person> people, List<Product> products)
        {
            while (true)
            {
                var purchase = Console.ReadLine();
                if (purchase == "END") break;

                var purchaseTokens = purchase.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var buyer = people.FirstOrDefault(b => b.Name == purchaseTokens[0]);
                var product = products.FirstOrDefault(p => p.Name == purchaseTokens[1]);

                try
                {
                    buyer.BuyProduct(product);
                    Console.WriteLine($"{buyer.Name} bought {product.Name}");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            return people;
        }

        private static List<Product> GetProducts()
        {
            var products = new List<Product>();

            var productsInfo = Console.ReadLine().Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var token in productsInfo)
            {
                var productInfo = token.Split(new[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
                products.Add(new Product(productInfo[0], decimal.Parse(productInfo[1])));
            }

            return products;
        }

        private static List<Person> GetPeople()
        {
            var people = new List<Person>();

            var personsInfo = Console.ReadLine().Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var token in personsInfo)
            {
                var personInfo = token.Split(new[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
                people.Add(new Person(personInfo[0], decimal.Parse(personInfo[1])));
            }

            return people;
        }
    }
}
