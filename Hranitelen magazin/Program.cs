using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hranitelen_magazin
{

    internal class Program
    {
        private static string filePath = "hrani";
        private static List<Product> products = new List<Product>();
        private static string menuActionChoice;

        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            PrintMenu();
            LoadFlights();

            while (true)
            {
                menuActionChoice = Console.ReadLine();
                switch (menuActionChoice)
                {
                    case "1":
                        ShowActionTitle("Създаване на нов полет");
                        AddNewProduct();
                        break;
                    case "2":
                        BuyProduct();
                        break;
                    case "3":
                        ShowActionTitle("Търсене на полет по номер или дестинация");
                        SearchProduct();
                        break;
                    case "4":
                        ShowActionTitle("Списък на всички полети");
                        ListProducts();
                        break;
                    case "x" or "X":
                        Exit();
                        break;
                    default:
                        // todo: implement default case

                        break;
                }
            }
        }
        private static void Exit()
        {
            throw new NotImplementedException();
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

        private static void LoadFlights()
        {
            throw new NotImplementedException();
        }

        private static void PrintMenu()
        {
            throw new NotImplementedException();
        }
    }
}
