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
    static List<Games> games = new List<Games>();
        static string ital = "";        
        static string etel = "";        
        static string jatek = "";        
        static async Task Main(string[] args)
        {
            Console.Title = "Api the Trilogy";
            Console.WriteLine("         Üdvözöllek!");
            vissza:
            Console.WriteLine("\nMit szeretnél megnézni? Írd be a sorszámát.\n\n1.Koktélok\n2.Ételek\n3.Játékok");
            try
            {
                int valaszt = int.Parse(Console.ReadLine());
                switch (valaszt)
                {
                    case 1:
                        Console.Clear();
                        DrinkMenu();
                        await DrinkAdatok();                        
                        DrinkskiIras();
                        break;
                    case 2:
                        Console.Clear();
                        FoodMenu();
                        await FoodAdatok();
                        FoodskiIras();
                        break;
                    case 3:
                        Console.Clear();
                        GameMenu();
                        await GameAdatok();
                        GameskiIras();
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

        private static void DrinkMenu()
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
                
            }
            catch (Exception)
            {
                Console.Clear();
                goto vissza;
            }
        }
        private static void FoodMenu()
        {
            vissza:
            try
            {
                Console.WriteLine("Választható italok:\n1.Yaki Udon\n2.\n3.\n4.\n5.Véletlen étel");
                int b;
                b = int.Parse(Console.ReadLine());
                switch (b)
                {
                    case 1:
                        etel = "search.php?s=Yaki%20Udon";
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
                
            }
            catch (Exception)
            {
                Console.Clear();
                goto vissza;
            }
        }
        private static void GameMenu()
        {
            vissza:
            try
            {
                Console.WriteLine("Választható Játékok:\n1.Dauntless\n2.The Elder Scrolls: Legends\n3.Battle Teams 2\n4.Cabals: Card Blitz\n5.Véletlen étel");
                int c;
                c = int.Parse(Console.ReadLine());
                switch (c)
                {
                    case 1:
                        jatek = "?id=1";
                        break;
                    case 2:
                        jatek = "?id=102";
                        break;
                    case 3:
                        jatek = "?id=576";
                        break;
                    case 4:
                        jatek = "?id=69";
                        break;
                    case 5:
                        Random random = new Random();
                        
                        jatek = "?id=" + random.Next(1,576).ToString();
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
                    if (kvp.Value != "" && kvp.Value != null)
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
        private static void GameskiIras()
        {
            Console.Clear();




            Console.WriteLine($"Id: {games[0].Id}\nNév:  {games[0].Title}\nRövid leírás: {games[0].ShortDescription}\nLeírás:   {games[0].Description}\nMűfaj:   {games[0].Genre}\nMegjelenés:  {games[0].ReleaseDate}\nFejlesztő:  {games[0].Developer}\nMegosztó: {games[0].Publisher}\nPlatform: {games[0].Platform}");
                 Thread.Sleep(100);
                

            
        vissza:
            Console.WriteLine("Nyomja le az 'esc' billentyűt a kilépéshez vagy az 'enter' billentyűt az újrakezdéshez");
            ConsoleKeyInfo keyinfo;
            keyinfo = Console.ReadKey();

            if (keyinfo.Key == ConsoleKey.Escape)
            {
                Environment.Exit(0);
            }
            else if (keyinfo.Key == ConsoleKey.Enter)
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
        private static async Task DrinkAdatok()
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
        private static async Task FoodAdatok()
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
        private static async Task GameAdatok()
        {
            HttpClient client = new HttpClient();
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage();
            HttpResponseMessage responseMessage = await client.GetAsync($"https://www.freetogame.com/api/game{jatek}");
            if (responseMessage.IsSuccessStatusCode)
            {
                string jsonString = await responseMessage.Content.ReadAsStringAsync();                
                games.Add(Games.FromJson(jsonString)); 
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
