using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hranitelen_magazin
{

    internal class Program
    {
        private const string filePath = "../../../hrani.txt";


        private static List<Product> products = new List<Product>();
        
        private static string menuActionChoice;

        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            PrintMenu();
            LoadProducts();

            while (true)
            {
                menuActionChoice = Console.ReadLine();
                switch (menuActionChoice)
                {
                    case "1":
                        ShowActionTitle("Добавяне на нов продукт");
                        AddNewProduct();
                        break;
                    case "2":
                        ShowActionTitle("Продажба на продукт");
                        BuyProduct();
                        break;
                    case "3":
                        ShowActionTitle("Поверка на наличността на продукт");
                        SearchProduct();
                        break;
                    case "4":
                        ShowActionTitle("Справка за всички продукти в магазина");
                        ListProducts();
                        break;
                    case "x":
                        Exit();
                        break;
                            default:
                        break;
                }
            }
        }

        private static void Exit()
        {
             Environment.Exit(0);
        }
        private static void BackToMenu()
        {
            AddLine();
            Console.Write("\tНатисни произвлен клавиш обратно към МЕНЮ: ");
            Console.ReadLine();
            PrintMenu();
        }
        private static void ListProducts()
        {
            foreach (Product product in products)
            {
                PrintProductInfo(product);
                AddLine();
            }
            BackToMenu();

        }
        private static void PrintProductInfo(Product product)
        {
            Console.WriteLine($"\tНомер на продукта: {product.ProductId}");
            Console.WriteLine($"\tИме:{product.Name}");
            Console.WriteLine($"\tКатегория: {product.Category}");
            Console.WriteLine($"\tЦена: {product.Price}");
            Console.WriteLine($"\tКоличество: {product.Quantity}");

           
        }


        private static void SearchProduct()
        {
            Console.Write("\tВъведете име на продукт: ");
            string filter = Console.ReadLine();
            AddLine();

             Product searchedProduct = products
                .FirstOrDefault(f => f.Name == filter);

            if(searchedProduct != null)
            {
                Console.WriteLine("Налично количество на продукта:" + searchedProduct.Quantity);
                Console.WriteLine("Цена на продукта:" + searchedProduct.Price);
            }

            BackToMenu();
        }

        private static void BuyProduct()
        {
            Product product = null;
            double productValue = 0;
            Console.WriteLine("Списък с налични продукти:");
            for (int i = 0; i < products.Count; i++)
            {
                Console.WriteLine(products[i]);
            }
            Console.Write("\tВъведете име на продукт:");
            string productName = Console.ReadLine();
            for (int i = 0; i < products.Count; i++)
            {
                if (productName.Equals(products[i].Name))
                {
                    product = products[i];
                }
            }
            Console.WriteLine("\tВъведете количеството, което искате да закупите:");
            int quantity = int.Parse(Console.ReadLine());
            if (quantity <= product.Quantity)
            {
                productValue += quantity * product.Price;
                product.SetQuantity(product.Quantity - quantity);
                Product newProduct = new Product(product.ProductId, product.Name, product.Category, product.Price, product.Quantity);
                products.Add(newProduct);
            }
            Console.WriteLine("Стойност на продукта:" + productValue);



        }

        private static void AddNewProduct()
        {
           
            Console.WriteLine("\tНомер на продукт: ");
            string productId = Console.ReadLine();
            
            Console.WriteLine("\tИме на продукт: ");
            string name = Console.ReadLine();
            
            Console.WriteLine("\tКатегория на продукт: ");
            string category = Console.ReadLine();
            
            Console.WriteLine("\tЦена на продукт: ");
            string price = Console.ReadLine();
            
            Console.WriteLine("\tКоличество на продукт: ");
            string quantity = Console.ReadLine();

            try
            {
               
                Product newProduct = new Product(int.Parse(productId), name, category, int.Parse(price), int.Parse(quantity));
                
            }
            catch (Exception)
            {

                throw;
            }
        }
        private static void ShowActionTitle(string v)
        {
            throw new NotImplementedException();
        }
        private static void LoadProducts()
        {
            StreamReader reader = new StreamReader(filePath, Encoding.Unicode);
            using (reader)
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] productInfo = line.Split(',');
                    int productId = int.Parse(productInfo[0]);
                    string name = productInfo[1];
                    string category = productInfo[2];
                    double price = double.Parse(productInfo[3]);
                    int quantity = int.Parse(productInfo[4]);
                  
                    Product currentProduct = new Product(productId, name, category , price, quantity);
                    products.Add(currentProduct); 
                }
            }
        }
        private static void PrintMenu()
        { 
            AddLine();
            Console.WriteLine("\tМ Е Н Ю");
            AddLine();
            Console.WriteLine("\tМоля изберете желаното действие:");
            AddLine();
            Console.WriteLine("\t[1]: Добавяне на нов продукт");
            Console.WriteLine("\t[2]: Продажба на продукт");
            Console.WriteLine("\t[3]: Проверка на личността на продукт");
            Console.WriteLine("\t[4]: Справка за всички продукти в магазина");
            Console.WriteLine("\t[x]: Изход от програмата");
            AddLine();
            Console.Write("\tВашият избор: ");
        }
         private static void AddLine(int count = 1)
        {
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(Environment.NewLine);
            }
        }
        private static void SaveProducts()
        {
            StreamWriter writer = new StreamWriter(filePath, false, Encoding.Unicode);
            using (writer)
            {
                foreach (Product product in products)
                {
                    writer.WriteLine(product);
                }
            }
        }
    }
}
