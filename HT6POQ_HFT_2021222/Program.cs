
using ConsoleTools;
using HT6POQ_HTF_2021222.Models;
using System;
using System.Collections;
using System.Collections.Generic;
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
                    var inv = service.GetSingle<Book>($"/book{y}");
                    Console.WriteLine("Enter title : ");
                    inv.Title = Console.ReadLine();
                    Console.WriteLine("Enter pagenumber : ");
                    inv.PageNumber = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter ShopID : ");
                    inv.ShopId = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter AuthorID : ");
                    inv.AuthorId = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter price : ");
                    inv.Price = int.Parse(Console.ReadLine());
                    service.Put(inv, "/book");
                    Option(service);
                }
                else if (x == 4)
                {
                    Console.WriteLine("Enter ID: ");
                    int id = int.Parse(Console.ReadLine());
                    service.Delete(id, "book");
                    Option(service);
                }
                else
                {
                    Option(service);
                }
            }
            else if (res == 5)
            {
                Console.WriteLine("1 : Author Get");
                Console.WriteLine("2 : Author Post");
                Console.WriteLine("3 : Author Put");
                Console.WriteLine("4 : Author Delete");
                int a = int.Parse(Console.ReadLine());
                if (a == 1)
                {
                    Console.WriteLine("Enter ID of searched author : ");
                    int z = int.Parse(Console.ReadLine());
                    var resm = service.GetSingle<Author>($"/author/{z}");
                    Console.WriteLine(resm.Name);
                    Option(service);
                }
                else if (a == 2)
                {
                    Console.WriteLine("Enter age : ");
                    int f = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter name : ");
                    string n = Console.ReadLine();
                    Console.WriteLine("Enter nationality : ");
                    string m = Console.ReadLine();
                    Console.WriteLine("Enter number of books");
                    int k = int.Parse(Console.ReadLine());
                    Author au = new Author();
                    au.Age = f;
                    au.Name = n;
                    au.Nationality = m;
                    au.NumberOfBooks = k;
                    service.Post<Author>(au, "/author");
                    Option(service);
                }
                else if (a == 3)
                {
                    Console.WriteLine("Enter an ID : ");
                    int l = int.Parse(Console.ReadLine());
                    var o = service.GetSingle<Author>($"/author/{l}");
                    Console.WriteLine("Enter age : ");
                    int f = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter name : ");
                    string n = Console.ReadLine();
                    Console.WriteLine("Enter nationality : ");
                    string m = Console.ReadLine();
                    Console.WriteLine("Enter number of books");
                    int k = int.Parse(Console.ReadLine());
                    o.Age = f;
                    o.Name = n;
                    o.Nationality = m;
                    o.NumberOfBooks = k;
                    service.Put(o, "/author");
                    Option(service);
                }
                else if (a == 4)
                {
                    Console.WriteLine("Enter an ID : ");
                    int e = int.Parse(Console.ReadLine());
                    service.Delete(e, "author");
                    Option(service);
                }
            }
            else if (res == 6)
            {
                Console.WriteLine("1 : Shop Get");
                Console.WriteLine("2 : Shop Post");
                Console.WriteLine("3 : Shop Put");
                Console.WriteLine("4 : Shop Delete");
                int f = int.Parse(Console.ReadLine());
                if (f == 1)
                {
                    Console.WriteLine("Enter an ID : ");
                    int i = int.Parse(Console.ReadLine());
                    var res3 = service.GetSingle<Shop>($"/shop/{i}");
                    Console.WriteLine(res3.Name);
                    Option(service);
                }
                else if (f == 2)
                {
                    Console.WriteLine("Enter a name : ");
                    string c = Console.ReadLine();
                    Console.WriteLine("Enter a location : ");
                    string log = Console.ReadLine();
                    Shop x = new Shop();
                    x.Name = c;
                    x.Location = log;
                    service.Post<Shop>(x, "/shop");
                    Option(service);
                }
                else if (f == 3)
                {
                    Console.WriteLine("Enter an ID : ");
                    int id = int.Parse(Console.ReadLine());
                    var ress = service.GetSingle<Shop>($"/shop/{id}");
                    Console.WriteLine("Enter a name : ");
                    ress.Name = Console.ReadLine();
                    Console.WriteLine("Enter a location : ");
                    ress.Location = Console.ReadLine();
                    service.Put<Shop>(ress, "/shop");
                    Option(service);
                }
                else if (f == 4)
                {
                    Console.WriteLine("Enter an ID : ");
                    int d = int.Parse(Console.ReadLine());
                    service.Delete(d, "shop");
                }
            }
            else if (res == 7)
            {
                var u = service.GetSingle<int>("/stat/AVGPRicesOfBooks");
                Console.WriteLine("Summed prices of books : "+u);
                Console.WriteLine("----------------------------");
                var u2 = service.GetSingle<IEnumerable<KeyValuePair<string, double>>>("/stat/AverageBookPriceByShops");
                Console.WriteLine("Average bookprice by stores : ");
                foreach (var item in u2)
                {
                    Console.WriteLine(item.Key + " - " +item.Value);
                }
                Console.WriteLine("----------------------------");
                var u3 = service.GetSingle<double>("/stat/AVGPricesOfBooks");
                Console.WriteLine("average price of all books - "+u3 );
                Console.WriteLine("----------------------------");
                var u4 = service.GetSingle<IEnumerable<Author>>("/stat/AveragePricedAuthors");
                Console.WriteLine("Authors that wrote an average priced book : ");
                foreach (var item in u4)
                {
                    Console.WriteLine( item.Name);
                }
                Console.WriteLine("----------------------------");
                var u5 = service.GetSingle<IEnumerable<Shop>>("/stat/ExpensiveBookStores");
                Console.WriteLine("Stores that sell expensive books - ");
                foreach (var item in u5)
                {
                    Console.WriteLine( item.Name);
                }
                Console.WriteLine("----------------------------");
                var u6 = service.GetSingle<IEnumerable<Shop>>("/stat/MostExpensiveBookStore");
                foreach (var item in u6)
                {
                    Console.WriteLine("Most expensive bookstore : "+item.Name);
                }
                Console.WriteLine("----------------------------");
                var u7 = service.GetSingle<IEnumerable<KeyValuePair<string, int>>>("/stat/MostExpensiveBooksByStores");
                Console.WriteLine("Most expensive books by store : ");
                foreach (var item in u7)
                {
                    Console.WriteLine(item.Key+ " - "+item.Value);
                }
                Console.WriteLine("----------------------------");
                var u8 = service.GetSingle<IEnumerable<KeyValuePair<string, int>>>("/stat/LeastExpensiveBooksByStores");
                Console.WriteLine("Least expensive books by store : ");
                foreach (var item in u8)
                {
                    Console.WriteLine(item.Key + " - " + item.Value);
                }
                Console.WriteLine("----------------------------");
                var u9 = service.GetSingle<IEnumerable<string>>("/stat/AuthorWithMostBook");
                foreach (var item in u9)
                {
                    Console.WriteLine("Author with most books : "+item);
                }
                Console.WriteLine("----------------------------");
                Option(service);

            }
        }
    }
}
