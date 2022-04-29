
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
             RestService service = new RestService("http://localhost:60996/","book");
               

            
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
        }
    }
}
