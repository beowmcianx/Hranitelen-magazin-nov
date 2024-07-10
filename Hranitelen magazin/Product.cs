using System;

namespace Hranitelen_magazin
{
    public class Product
    {
        private int productId;
        private string name;
        private string category;
        private double price;
        private int quantity;

        public Product(int productId, string name, string category, double price, int quantity)
        {
            ProductId = productId;
            Name = name;
            Category = category;
            Price = price;
            Quantity = quantity;
        }

        public int ProductId
        {
            get { return productId; }
            private set { productId = value; }
        }

        public string Name
        {
            get { return name; }
            private set { name = value; }
        }

        public string Category
        {
            get { return category; }
            private set { category = value; }
        }

        public double Price
        {
            get { return price; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Цената на продукта трябва да е положителна");
                }
                price = value;
            }
        }

        public int Quantity
        {
            get { return quantity; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Количеството на продукта не може да е отрицателно");
                }
                quantity = value;
            }
        }

        public void SetQuantity(int newQuantity)
        {
            if (newQuantity < 0)
            {
                throw new ArgumentException("Количеството на продукта не може да е отрицателно");
            }
            Quantity = newQuantity;
        }

        public override string ToString()
        {
            return $"{ProductId}, {Name}, {Category}, {Price}, {Quantity}";
        }
    }
}
