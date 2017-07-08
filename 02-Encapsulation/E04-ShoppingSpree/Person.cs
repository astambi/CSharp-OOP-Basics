namespace ShoppingSpree
{
    using System;
    using System.Collections.Generic;

    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> bagOfProducts;

        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            this.bagOfProducts = new List<Product>();
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException($"{nameof(Name)} cannot be empty");
                }
                this.name = value;
            }
        }

        private decimal Money
        {
            get { return this.money; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException($"{nameof(Money)} cannot be negative");
                }
                this.money = value;
            }
        }

        public IList<Product> GetProducts()
        {
            return this.bagOfProducts.AsReadOnly();
        }

        public void BuyProduct(Product product)
        {
            if (product.Cost > this.money)
            {
                throw new InvalidOperationException($"{this.name} can't afford {product.Name}");
            }

            this.money -= product.Cost;
            this.bagOfProducts.Add(product);
        }
    }
}
