using Microsoft.EntityFrameworkCore;
using Sh0pDB.Models;
namespace Sh0pDB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ShopDBContext DB = new ShopDBContext();
            /*
            DB.users.Add(new User{Name = "Aleksandr", Age = 18, Email = "Aleksandr18@gmail.com"});

            DB.categories.Add(new Category { Type = "Овощи" });

            DB.products.Add(new Product
            { Name = "Морковь", Price = 50, Quantity = 1000, Category = DB.categories.First() });

            DB.orders.Add(new Orders { Status = "Доставка заказа", User = DB.users.First() });
            DB.SaveChanges();
            */

            foreach (var user in DB.users)
            {
                Console.WriteLine(user);   // dotnet-ef migrations add (Название)
            }                              // dotnet-ef database update (Название /не обязательно)
        }                                  // если у вас ошибка попробуйте писать
                                           // ~/.dotnet/tools/dotnet-ef вместо dotnet-ef
        //контекст
       /* public DbSet<User> users { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<Orders> orders { get; set; }*/
    }
}
