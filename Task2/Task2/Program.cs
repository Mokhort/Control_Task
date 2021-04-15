using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task2
{
    struct Info_local {
        public string name;
        public string gender;
        public DateTime birthday;
        public string type_animal;
        public int id_parent;
    }
    class Program
    {
        static async Task add(Context context, Info_local info_local) {

            //check that this animal exists in table 

             int idType = context.Type_animal
                 .Where(c => c.type_name == info_local.type_animal)
                 .Select(c => c.id)
                 .FirstOrDefault();

            Console.WriteLine($"{idType}");
            // List<Type_animal> list_type= info_local.type_animal.ToList();
            if (idType != 0)
            {
                //foreach (Type_animal informations in information)
                 //   id = informations.id;
                context.Info.Add(new Info()
                {
                    name = info_local.name,
                    gender = info_local.gender,
                    date_of_birth = info_local.birthday,
                    parent_1 = info_local.id_parent,
                    typeid = idType
                }); 
            }
            else
            {
                context.Type_animal.Add(new Type_animal()
                {
                    type_name = info_local.type_animal
                });
                context.SaveChanges();
                //выбрать id type
                int idType2 = context.Type_animal
                     .Where(c => c.type_name == info_local.type_animal)
                     .Select(c => c.id)
                     .FirstOrDefault();

                Console.WriteLine($"Add new type animal with id {idType2}");

                context.Info.Add(new Info()
                {
                    name = info_local.name,
                    gender = info_local.gender,
                    date_of_birth = info_local.birthday,
                    parent_1 = info_local.id_parent,
                    typeid = idType2
                });
            }
            context.SaveChangesAsync();
            print_all_notes(context);
        }

        static void print_all_notes(Context context) {

            IQueryable<Info> information = from pr in context.Info select pr;
            List<Info> list = information.ToList();
            Console.WriteLine($"INFORMATION");
            foreach (Info informations in information)
                Console.WriteLine($"{informations.id} {informations.name} {informations.gender} {informations.date_of_birth} {informations.parent_1} {informations.typeid} ");
        }

        static async Task delete(Context context,int num)

        {
            // вывести все и удалить по номеру id     
            IQueryable<Info> information = from pr in context.Info where pr.id == num select pr;
            foreach (Info detail in information) {
                context.Info.Remove(detail);
            }
            await context.SaveChangesAsync();
            print_all_notes(context);
        }

        static async Task searchDate(Context context, DateTime date) {

            //все животные по дате рождения 
            IQueryable<Info> information = from pr in context.Info where pr.date_of_birth == date select pr;
            List<Info> list = information.ToList();
            Console.WriteLine($"=======Search by birthday=====");
            foreach (Info informations in information)
                Console.WriteLine($"{informations.id}{informations.name} {informations.gender} {informations.date_of_birth} {informations.parent_1} {informations.typeid}");
        }

        static async Task searchGender(Context context, string gen) {

            IQueryable<Info> information = from pr in context.Info where pr.gender == gen select pr;
            List<Info> list = information.ToList();
            Console.WriteLine($"=======Search by gender=====");
            foreach (Info informations in information)
                Console.WriteLine($"{informations.id} {informations.name} {informations.gender} {informations.date_of_birth} {informations.parent_1} {informations.typeid}");
        }

        static async Task searchType(Context context, string type) {

            int idType = context.Type_animal
                .Where(c => c.type_name == type)
                .Select(c => c.id)
                .FirstOrDefault();

            Console.WriteLine($"Id type for search {idType}");

            IQueryable<Info> information = from pr in context.Info where pr.typeid == idType select pr;
            List<Info> list = information.ToList();
            Console.WriteLine($"=======Search by type===========");
            foreach (Info informations in information)
                Console.WriteLine($"{informations.id} {informations.name} {informations.gender} {informations.date_of_birth} {informations.parent_1} {informations.typeid}");

        }
        static async Task Main(string[] args)
        {
            Context context = new Context();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            context.Type_animal.Add(new Type_animal()
            {
                type_name = "Ship"
            });
            context.Type_animal.Add(new Type_animal()
            {
                type_name = "Cow"
            });
            context.Type_animal.Add(new Type_animal()
            {
                type_name = "Horse"
            });

            context.Info.Add(new Info()
            {
                name = "Pola",
                gender = "m",
                date_of_birth = new DateTime(2020, 7, 20, 00, 00, 00),
                parent_1 = 0,
                typeid = 2
            });
            context.Info.Add(new Info()
            {
                name = "Luna",
                gender = "w",
                date_of_birth = new DateTime(2015, 7, 20, 00, 00, 00),
                parent_1 = 0,
                typeid = 3
            });
            context.SaveChanges();

            Console.WriteLine("Working with DB Farm");
            while (true)
            {
                Console.WriteLine("'1'-add note");
                Console.WriteLine("'2'-delete note");
                Console.WriteLine("'3'-search by type");
                Console.WriteLine("'4'-search by date birth");
                Console.WriteLine("'5'-search by gender");
                Console.WriteLine("'6'-print");
                Console.WriteLine("'7'-exit");
                Console.WriteLine("Enter cmd to continue:");
                string cmd = Console.ReadLine();

                Info_local info_local;
                switch (cmd)
                {
                    case "1":
                        Console.WriteLine("Enter name:");
                        info_local.name = Console.ReadLine();

                        Console.WriteLine("Enter gender(w/m):");
                        info_local.gender = Console.ReadLine();
                        if (!((info_local.gender == "w") || (info_local.gender == "m")))
                        {
                            Console.WriteLine("Invalid gender!");
                            break;
                        }
                        Console.WriteLine("Enter date of birth (dd.mm.yyyy):");
                        string date = Console.ReadLine();
                        info_local.birthday = Convert.ToDateTime(date);

                        Console.WriteLine("Enter type of animal:");
                       // string type = Console.ReadLine();
                        info_local.type_animal= Console.ReadLine();
                        //info_local.type_animal = Convert.ToInt32(type);

                        Console.WriteLine("Enter parent id:");
                        string id_par = Console.ReadLine();
                        info_local.id_parent = Convert.ToInt32(id_par);

                        await add(context, info_local);
                        break;
                    case "2":
                        Console.WriteLine($"Enter the num to delete:");
                        string cmd_del = Console.ReadLine();
                        int num = Convert.ToInt32(cmd_del);
                        print_all_notes(context);
                        await delete(context,num);
                        break;
                    case "3":
                        //by type
                        Console.WriteLine($"Enter type for search:");
                        info_local.type_animal = Console.ReadLine();
                        await searchType(context, info_local.type_animal);
                        break;
                    case "4":
                        Console.WriteLine("Enter Date (dd.mm.yyyy):");
                        string date_read = Console.ReadLine();
                        info_local.birthday = Convert.ToDateTime(date_read);
                        await searchDate(context, info_local.birthday);
                        break; 
                    case "5":
                        Console.WriteLine("Enter gender (w/m):");
                        info_local.gender = Console.ReadLine();
                        if ((info_local.gender=="w")||(info_local.gender == "m"))
                        await searchGender(context, info_local.gender);
                        else Console.WriteLine("Invalid gender!");
                        break;
                    case "6":
                        print_all_notes(context);
                        break;
                    case "7":
                        Console.WriteLine("Closing program...");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid num!");
                        break;
                }
            }
        }
    }
}
