using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Hranitelen_magazin
{
    internal class Program
    {
        private const string filePath = "hrani.txt";
        private static List<Product> products = new List<Product>();
        private static string menuActionChoice;

        public static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            LoadProducts();
            PrintMenu();

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
                        ShowActionTitle("Проверка на наличността на продукт");
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
                        Console.WriteLine("Невалиден избор. Моля, опитайте отново.");
                        break;
                }
            }
        }

        private static void Exit()
        {
            SaveProducts();
            Environment.Exit(0);
        }

        private static void BackToMenu()
        {
            AddLine();

            Console.Write("\tНатиснете произволен клавиш обратно към МЕНЮ: ");
            Console.WriteLine(" ");
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
            string output = $"\tНомер на продукта: {product.ProductId}\n" +
                            $"\tИме: {product.Name}\n" +
                            $"\tКатегория: {product.Category}\n" +
                            $"\tЦена: {product.Price}\n" +
                            $"\tКоличество: {product.Quantity}\n";
            Console.WriteLine(output);
        }


        private static void SearchProduct()
        {
            Console.Write("\tВъведете име на продукт: ");
            string filter = Console.ReadLine();
            AddLine();

            Product searchedProduct = products.FirstOrDefault(f => f.Name.Equals(filter, StringComparison.OrdinalIgnoreCase));

            if (searchedProduct != null)
            {
                Console.WriteLine("\tНалично количество на продукта: " + searchedProduct.Quantity);
                Console.WriteLine("\tЦена на продукта: " + searchedProduct.Price);
            }
            else
            {
                Console.WriteLine("\tПродуктът не е намерен.");
            }

            BackToMenu();
        }

        private static void BuyProduct()
        {
            Console.WriteLine("Списък с налични продукти:");
            foreach (var product in products)
            {
                PrintProductInfo(product);
            }

            Console.Write("\tВъведете име на продукт: ");
            string productName = Console.ReadLine();
            Product productToBuy = products.FirstOrDefault(p => p.Name.Equals(productName, StringComparison.OrdinalIgnoreCase));

            if (productToBuy == null)
            {
                Console.WriteLine("Продуктът не е намерен.");
                BackToMenu();
                return;
            }

            Console.Write("\tВъведете количеството, което искате да закупите: ");
            if (int.TryParse(Console.ReadLine(), out int quantity) && quantity > 0)
            {
                if (quantity <= productToBuy.Quantity)
                {
                    double productValue = quantity * productToBuy.Price;
                    productToBuy.SetQuantity(productToBuy.Quantity - quantity);

                    Console.WriteLine("Стойност на продукта: " + productValue);
                }
                else
                {
                    Console.WriteLine("Недостатъчно количество в наличност.");
                }
            }
            else
            {
                Console.WriteLine("Невалидно количество.");
            }

            BackToMenu();
        }


        private static void AddNewProduct()
        {
            Console.WriteLine("\tНомер на продукт: ");
            string productId = Console.ReadLine();

            Console.WriteLine("\tИме на продукт: ");
            string name = Console.ReadLine();

            Console.WriteLine("\tКатегория на продукт: ");
            string category = Console.ReadLine();

            Console.WriteLine("\tЦена на продуктът в лева: ");
            string price = Console.ReadLine();

            Console.WriteLine("\tКоличество на продукт: ");
            string quantity = Console.ReadLine();

            try
            {
                Product newProduct = new Product(int.Parse(productId), name, category, double.Parse(price), int.Parse(quantity));
                products.Add(newProduct);
                SaveProducts();
                Console.WriteLine("\tПродуктът е добавен успешно.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("\tГрешка при добавянето на продукта: " + ex.Message);
            }

            BackToMenu();
        }

        private static void ShowActionTitle(string title)
        {
            AddLine();
            Console.WriteLine("\t" + title);
            AddLine();
        }

        private static void LoadProducts()
        {
            if (!File.Exists(filePath))
                return;

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

                    Product currentProduct = new Product(productId, name, category, price, quantity);
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
            Console.WriteLine("\t[3]: Проверка на наличността на продукт");
            Console.WriteLine("\t[4]: Справка за всички продукти в магазина");
            Console.WriteLine("\t[x]: Изход от програмата");
            AddLine();
            Console.Write("\tВашият избор: ");
        }

        private static void AddLine(int count = 1)
        {
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine();
            }
        }

        private static void SaveProducts()
        {
            StreamWriter writer = new StreamWriter(filePath, false, Encoding.Unicode);
            using (writer)
            {
                foreach (Product product in products)
                {
                    writer.WriteLine($"{product.ProductId},{product.Name},{product.Category},{product.Price},{product.Quantity}");
                }
            }
        }
    }
}
