using System;
using System.Threading.Tasks;

namespace Task2
{
    class Program
    {
        static async Task add() { 

        }
        static async Task delete()
        {
        }
        static async Task Main(string[] args)
        {
            Console.WriteLine("Working with DB Farm");
           
            Console.WriteLine("'add'-add note");
            Console.WriteLine("'del'-delete");
            Console.WriteLine("'search1'-search by type");
            Console.WriteLine("'search2'-search by date birth");
            Console.WriteLine("'search3'-search by date birth of parent");
            Console.WriteLine("'search4'-search by gender");
            Console.WriteLine("Enter cmd to continue:");
            string cmd = Console.ReadLine();
            switch (cmd) {
                case "add":
                    await add();
                    break;
                case "del":
                    await delete();
                    break;
                case "search1":
                    break;
                case "search2":
                    break;
                case "search3":
                    break;
                case "search4":
                    break;
                default:
                    Console.WriteLine("Invalid num!");
                    break;
;            }

        }
    }
}
