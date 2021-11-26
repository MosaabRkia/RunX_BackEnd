using DataAccess.Context;
using DataAccess.models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace DataAccess.Services
{
    public class UserService
    {

        private readonly RunXContext _context;
        public UserService(RunXContext context)
        {
            this._context = context;
        }

        public IEnumerable<User> GetUsers()
        {
            return _context.User.AsNoTracking().AsQueryable();
        }

        public bool CreateUser(User user)
        {
            var userToCheck = _context.User.FirstOrDefault(e=>e.Email == user.Email);
            if (userToCheck != null) return false;

            _context.User.Add(user);
            return _context.SaveChanges() > 0;
        }
        public bool checkLogin(string email, string password)
        {
            var userToCheckLogin = _context.User.SingleOrDefault(e=> e.Email.Equals(email) && e.Password.Equals(password));
            return userToCheckLogin == null ? false : true;
        }

      
        public List<User> getData(string email) {
            //System.DateTime.Today() //.Where(x=>x.Date == System.DateTime.Today()))
            var temp = _context.User.Where(e=>e.Email == email)
                //.Include(e => e.Heights)
                //.Include(e => e.DailyProtein)
                //.Include(e=>e.ChoosenFood) get it every 24 hour to create new meals
                .Include(e => e.Weights)
                .Include(e => e.DailyWaterCups)
                .Include(e => e.DailySteps)
                .Include(e => e.Sleeps)
                .Include(e => e.KCalDaily)
                .Include(e => e.Meds).ThenInclude(e=>e.Times)
                     .Include(e => e.Meals).ThenInclude(e => e.ItemsList)
                .ToList();
            return temp;
        }

        public bool changepassword(string email, string password)
        {
            var userToCheckLogin = _context.User.SingleOrDefault(e => e.Email.Equals(email));
            
            if (userToCheckLogin == null) return false;
 
            userToCheckLogin.Password = password;
            return _context.SaveChanges() > 0;
        }



    }
}
