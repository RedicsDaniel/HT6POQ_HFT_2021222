
using ConsoleTools;
using HT6POQ_HTF_2021222.Models;
using System;
using System.Linq;

namespace HT6POQ_HFT_2021222
{
    internal class Program
    {

        static void Main(string[] args)
        {
            System.Threading.Thread.Sleep(5000);
            RestService service = new RestService("http://localhost:60996/", "book");
            Option(service);
            var books = service.Get<Book>("book");
            var authors = service.Get<Author>("author");
            var shop = service.Get<Shop>("shop");

            ;

            Console.ReadKey();

            
        }
        static void Option(RestService service)
        {
            Console.WriteLine(" 1 : Book table ");
            Console.WriteLine(" 2 : Author table ");
            Console.WriteLine(" 3 : Shop table ");
            Console.WriteLine(" 4 : Book CRUD ");
            Console.WriteLine(" 5 : Author CRUD ");
            Console.WriteLine(" 6 : Shop CRUD ");
            Console.WriteLine(" 7 : Book NON-CRUD ");
            Console.WriteLine(" 8 : Author NON-CRUD ");

            int res = int.Parse(Console.ReadLine());
            if (res == 1)
            {
                var books = service.Get<Book>("book");
                foreach (var item in books)
                {
                    Console.WriteLine(" ID : " + item.Id
                        + "| Author name : "
                        + item.Author.Name + "| PageNumber : "
                        + item.PageNumber + "| Price : "
                        + item.Price + "| Shop : " + item.Shop.Name + "| Type : " + item.Type);
                }
                Option(service);
            }
            else if (res == 2)
            {
                var aut = service.Get<Author>("author");
                foreach (var item in aut)
                {
                    Console.WriteLine("ID : " + item.Id+"| Name : " + item.Name + "| Age : "+ item.Age+"| Nationality : "+item. Nationality);
                }
                Option(service);
            }
            else if (res == 3)
            {
                var shop = service.Get<Shop>("shop");
                foreach (var item in shop)
                {
                    Console.WriteLine("ID : "+ item.Id + "| Name : "+item. Name+"| Location : "+ item.Location);
                }
                Option(service);
            }
            else if (res == 4)
            {
                Console.WriteLine(" 1 : Book Get");
                Console.WriteLine(" 2 : Book Post");
                Console.WriteLine(" 3 : Book Put");
                Console.WriteLine(" 4 : Book Delete");
                int x = int.Parse(Console.ReadLine());
                if (x == 1)
                {
                    Console.WriteLine(" ID OF SEARCHED BOOK : ");
                    int i = int.Parse(Console.ReadLine());
                    var i2 = service.GetSingle<Book>($"/book/{i}");
                    Console.WriteLine(i2.Title);
                    Option(service);
                }
                else if (x == 2)
                {
                    Console.WriteLine("Title : ");
                    string a = Console.ReadLine();
                    Console.WriteLine("Price : ");
                    int b = int.Parse(Console.ReadLine());
                    Console.WriteLine("PageNumber : ");
                    int c = int.Parse(Console.ReadLine());
                    Console.WriteLine("AuthorID : ");
                    int d = int.Parse(Console.ReadLine());
                    Console.WriteLine("ShopID : ");
                    int e = int.Parse(Console.ReadLine());
                    Book z = new Book();
                    z.Title = a;
                    z.PageNumber = c;
                    z.ShopId = e;
                    z.AuthorId = d;
                    z.Price = b;
                    service.Post<Book>(z, "/book");
                    Option(service);
                }
                else if (x == 3)
                {
                    Console.WriteLine("Enter an ID : ");
                    int y = int.Parse(Console.ReadLine());

                }
            }
        }
    }
}
