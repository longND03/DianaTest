using Microsoft.EntityFrameworkCore;
using PremaritalCounseling.Repository.Base;
using PremaritalCounseling.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremaritalCounseling.Repository.Repositories
{
    public class UserRepository : GenericRepository<User>
    {
        public async Task<User> GetUser(string username, string password)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.UserName == username && u.Password == password);

            //return await _context.Users.FirstOrDefaultAsync(u => u.Email == username && u.Password == password && u.IsActive == true);

            //return await _context.SystemUserAccounts.FirstOrDefaultAsync(u => u.Phone == userName && u.Password == password && u.IsActive == true);

            //return await _context.SystemUserAccounts.FirstOrDefaultAsync(u => u.EmployeeCode == userName && u.Password == password && u.IsActive == true);
        }


    }
}
