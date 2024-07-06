using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hranitelen_magazin
{
    public class Product
    {
        private int productId;
        private string name;
        private string category;
        private decimal price;
        private int quantity;

        public int ProductId { get; private set; } 
        public string Name { get; private set; }
        public string Category { get; private set; }
        public decimal Price
        {
            get
            {
                return price;
            }
            private set
            {
                if (price <= 0)
                {
                    throw new ArgumentException("Цената на продукта трябва да е положителна");
                }
            }
        }
        public int Quantity 
        {
            get
            {
                return quantity;
            }
            private set
            {
                if (quantity <= 0)
                {
                    throw new ArgumentException("Количеството на продукта трябва да е положително");
                }
            }
        }




    }
}
