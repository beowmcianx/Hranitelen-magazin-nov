using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hranitelen_magazin
{

    internal class Program
    {
        private static string filePath = "hrani.txt";
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
                        ShowActionTitle("Добавяне на ноив продукт");
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

        private static void ListProducts()
        {
            throw new NotImplementedException();
        }

        private static void SearchProduct()
        {
            throw new NotImplementedException();
        }

        private static void BuyProduct()
        {
            throw new NotImplementedException();
        }

        private static void AddNewProduct()
        {
            throw new NotImplementedException();
        }
        private static void ShowActionTitle(string v)
        {
            throw new NotImplementedException();
        }
        private static void LoadProducts()
        {
            throw new NotImplementedException();
        }
        private static void PrintMenu()
        {
            throw new NotImplementedException();
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
