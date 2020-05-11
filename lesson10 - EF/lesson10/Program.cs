using lesson10.DataAccess;
using lesson10.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace lesson10
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var userController = new UserDbController();

            List<User> users = (List<User>)await userController.GetUsersAsync();

            if (users.Count == 0)
            {
                users = new List<User>
            {
                new User{Name = "Name1", Surname = "Sur1", Age = 22 },
                new User{Name = "Name2", Surname = "Sur2", Age = 23 },
                new User{Name = "Name3", Surname = "Sur3", Age = 24 },
                new User{Name = "Name4", Surname = "Sur4", Age = 25 },
                new User{Name = "Name5", Surname = "Sur5", Age = 26 }
            };
                await userController.CreateRangeAsync(users);
            }

            foreach (var item in users)
            {
                Console.WriteLine(item.ToString());
            }

            User user4 = await userController.GetAsync(4);

            Console.WriteLine(user4.ToString());

            user4.Age = 99;

            await userController.UpdateAsync(user4);

            Console.WriteLine(user4.ToString());


            Console.ReadKey();
        }
    }
}
