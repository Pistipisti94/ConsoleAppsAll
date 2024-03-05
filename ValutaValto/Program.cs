using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Valutak;

namespace ValutaValto
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            
                await Menu();
            
        }

        private static async Task Menu()
        {
            Console.WriteLine("Üdvözöllek a Valutaváltóban \n\nKérlek válassz az alábbi lehetőségek közül:\n\n");
            Console.WriteLine("1.Forint -> Euro \n2.USA Dollár -> Euro\n3.AED -> Euro\n4.BOB -> Euro");

            string menu = Console.ReadLine();
            string penz = "";
            switch (menu)
            {
                case "1":
                    Console.WriteLine("HUF -> EURO");
                    penz = "HUF";
                    break;
                case "2":
                    Console.WriteLine("USD -> EURO");
                    penz = "USD";
                    break;
                case "3":
                    Console.WriteLine("AED -> EURO");
                    penz = "AED";
                    break;
                case "4":
                    Console.WriteLine("BOB -> EURO");
                    penz = "BOB";
                    break;

                default:
                    Console.WriteLine("HUF -> EURO");
                    penz = "HUF";
                    break;
            }
            await szamolas(penz);
        }

        private static async Task szamolas(string penz)
        {
            List<Valuts> valutak = new List<Valuts>();
            valutak = await valutaAdatok();

            Console.WriteLine("Írj be egy pénzösszeget amit szeretnél átváltani más pénznembe");

            string penzosszeg = Console.ReadLine();
            try
            {
            int numVal = Int32.Parse(penzosszeg);
            Console.WriteLine($"{numVal} {penz} az {Math.Round(numVal / valutak[0].Rates[penz],2)} EURO");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
           

            await Console.Out.WriteLineAsync("Nyomja le az 'esc' billentyűt a kilépéshez vagy bármelyik gombot az újrakezdéshez");            
            ConsoleKeyInfo keyinfo;
            keyinfo = Console.ReadKey();

            if (keyinfo.Key == ConsoleKey.Escape)
            {
                Environment.Exit(0);
            }
            else
            {
            Console.Clear();
            await Menu();
            }
        }

        private static async Task<List<Valuts>> valutaAdatok()
        {
            List<Valuts> valutak = new List<Valuts>();
            HttpClient client = new HttpClient();
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage();
            HttpResponseMessage responseMessage = await client.GetAsync("http://infojegyzet.hu/webszerkesztes/php/valuta/api/v1/arfolyam/");
            if (responseMessage.IsSuccessStatusCode)
            {
                string jsonString = await responseMessage.Content.ReadAsStringAsync();
                valutak.Add(Valuts.FromJson(jsonString));
            }
            return valutak;
        }
    }
}