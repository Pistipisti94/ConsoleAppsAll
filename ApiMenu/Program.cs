using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ApiMenu;

namespace ApiMenu
{

    internal class Program
    {
    static List<Drinks> drinks = new List<Drinks>();
    static List<Foods> foods = new List<Foods>();
        static string ital = "";        
        static string etel = "";        
        static async Task Main(string[] args)
        {
            Console.Title = "Api the Trilogy";
            Console.WriteLine("         Üdvözöllek!");
            vissza:
            Console.WriteLine("\nMit szeretnél megnézni? Írd be a sorszámát.\n\n1.Koktélok\n2.Ételek\n3.");
            try
            {
                int valaszt = int.Parse(Console.ReadLine());
                switch (valaszt)
                {
                    case 1:
                        Console.Clear();
                        int a = DrinkMenu();
                        await DrinkAdatok(a);                        
                        DrinkskiIras();
                        break;
                    case 2:
                        Console.Clear();
                        int b = FoodMenu();
                        await FoodAdatok(b);
                        FoodskiIras();
                        break;
                    case 3:
                        Console.Clear();
                        //await DrinkAdatok();
                        break;
                    default:
                        break;
                }
            }
            catch (Exception)
            {
                Console.Clear();
                goto vissza;
                
            }
            
            Console.ReadKey();
        }

        private static int DrinkMenu()
        {
            vissza:
            try
            {
                Console.WriteLine("Választható italok:\n1.Lady Love Fizz\n2.Turkeyball\n3.Sidecar Cocktail\n4.White Wine Sangria\n5.Véletlen koktél");
                int a;
                a = int.Parse(Console.ReadLine());
                switch (a)
                {

                    case 1:
                        ital = "search.php?s=Lady%20Love%20Fizz";
                        break;
                    case 2:
                        ital = "search.php?s=Turkeyball";
                        break;
                    case 3:
                        ital = "search.php?s=Sidecar%20Cocktail";
                        break;
                    case 4:
                        ital = "search.php?s=White%20Wine%20Sangria";
                        break;
                    case 5:
                        ital = "random.php";
                        break;
                    default:
                        break;
                }
                return a;
            }
            catch (Exception)
            {
                Console.Clear();
                goto vissza;
            }
        }
        private static int FoodMenu()
        {
            vissza:
            try
            {
                Console.WriteLine("Választható italok:\n1.\n2.\n3.\n4.\n5.Véletlen étel");
                int b;
                b = int.Parse(Console.ReadLine());
                switch (b)
                {
                    case 1:
                        etel ="";
                        break;
                    case 2:
                        etel = "";
                        break;
                    case 3:
                        etel = "";
                        break;
                    case 4:
                        etel = "";
                        break;
                    case 5:
                        etel = "random.php";
                        break;
                    default:
                        break;
                }
                return b;
            }
            catch (Exception)
            {
                Console.Clear();
                goto vissza;
            }
        }

        private static void DrinkskiIras()
        {
            Console.Clear();
            
            foreach (var dictionary in drinks[0].DrinksDrinks)
            {
                foreach (var kvp in dictionary)
                {
                    if (kvp.Value != null)
                    {
                        Console.WriteLine($"{kvp.Key.TrimStart('s','t','r')}: {kvp.Value}\n");
                    }
                    Thread.Sleep(100);
                }
                
            }
            vissza:
            Console.WriteLine("Nyomja le az 'esc' billentyűt a kilépéshez vagy az 'enter' billentyűt az újrakezdéshez");
            ConsoleKeyInfo keyinfo;
            keyinfo = Console.ReadKey();

            if (keyinfo.Key == ConsoleKey.Escape)
            {
                Environment.Exit(0);
            }
            else if(keyinfo.Key == ConsoleKey.Enter)
            {
                Console.Clear();
                Again();
            }
            else
            {
                goto vissza;
            }

        }
        private static void FoodskiIras()
        {
            Console.Clear();
            
            foreach (var dictionary in foods[0].Foodees)
            {
                foreach (var kvp in dictionary)
                {
                    if (kvp.Value != null)
                    {
                        Console.WriteLine($"{kvp.Key.TrimStart('s','t','r')}: {kvp.Value}\n");
                    }
                    Thread.Sleep(100);
                }
                
            }
            vissza:
            Console.WriteLine("Nyomja le az 'esc' billentyűt a kilépéshez vagy az 'enter' billentyűt az újrakezdéshez");
            ConsoleKeyInfo keyinfo;
            keyinfo = Console.ReadKey();

            if (keyinfo.Key == ConsoleKey.Escape)
            {
                Environment.Exit(0);
            }
            else if(keyinfo.Key == ConsoleKey.Backspace)
            {
                Console.Clear();
                Again();
            }
            else
            {
                goto vissza;
            }

        }

        #region Adatok
        private static async Task DrinkAdatok(int a)
        {
            HttpClient client = new HttpClient();
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage();
            HttpResponseMessage responseMessage = await client.GetAsync($"https://www.thecocktaildb.com/api/json/v1/1/{ital}");
            if (responseMessage.IsSuccessStatusCode)
            {
                string jsonString = await responseMessage.Content.ReadAsStringAsync();
                drinks.Add(Drinks.FromJson(jsonString));
            }
        }
        private static async Task FoodAdatok(int b)
        {
            HttpClient client = new HttpClient();
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage();
            HttpResponseMessage responseMessage = await client.GetAsync($"https://www.themealdb.com/api/json/v1/1/{etel}");
            if (responseMessage.IsSuccessStatusCode)
            {
                string jsonString = await responseMessage.Content.ReadAsStringAsync();
                foods.Add(Foods.FromJson(jsonString));
            }
        }
        #endregion
        static void Again()
        {
            Task task = Main(null);
            task.Start();
        }

    }
}
