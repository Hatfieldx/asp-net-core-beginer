using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using lesson10.Models;
using lesson10.Models.ApplicationContext;
using Microsoft.EntityFrameworkCore;

namespace lesson10.DataAccess
{
    class UserDbController
    {
        ApplicationContext dbcontext;

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await dbcontext.Users.ToListAsync();
        }
        public async Task CreateRangeAsync(IEnumerable<User> users)
        {
            await dbcontext.Users.AddRangeAsync(users);
            await dbcontext.SaveChangesAsync();
        }
        public async Task<User> GetAsync(int id)
        {
            return await dbcontext.Users.FirstOrDefaultAsync(user => user.Id == id);
        }
        public async Task CreateAsync(User user)
        {
            if (user != null)
            {
               await dbcontext.AddAsync(user);
                await dbcontext.SaveChangesAsync();
            }
        }
        public async Task UpdateAsync(User user)
        {
            if (user != null)
            {
                dbcontext.Entry(user).State = EntityState.Modified;

                await dbcontext.SaveChangesAsync();
            }
        }
        public async Task DeleteAsync(int id)
        {
            User user = await dbcontext.Users.FirstOrDefaultAsync(user => user.Id == id);

            if (user != null)
            {
                dbcontext.Entry(user).State = EntityState.Deleted;
                await dbcontext.SaveChangesAsync();
            }
        }
        public UserDbController()
        {
            dbcontext = new ApplicationContext();
        }
    }
}
