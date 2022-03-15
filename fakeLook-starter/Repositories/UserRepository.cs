using fakeLook_dal.Data;
using fakeLook_models.Models;
using fakeLook_starter.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fakeLook_starter.Repositories
{
    public class UserRepository : IUserRepository
    {
        readonly private DataContext _context;
        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<User> Add(User item)
        {
            var res = _context.Users.Add(item);
            await _context.SaveChangesAsync();
            return res.Entity;
        }

        public User Post(User item)
        {
            item.Id = int.Parse(Guid.NewGuid().ToString());
            item.Password = item.Password.GetHashCode().ToString();
            _context.Users.Add(item);
            return item;
        }

        public async Task<User> Edit(User item)
        {
            var res = _context.Users.Update(item);
            await _context.SaveChangesAsync();
            return res.Entity;
        }

        public ICollection<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public User GetById(int id)
        {
            return _context.Users.SingleOrDefault(p => p.Id == id);
        }

        public ICollection<User> GetByPredicate(Func<User, bool> predicate)
        {
            return _context.Users.Where(predicate).ToList();
        }

        public User FindItem(User item)
        {
            item.Password = item.Password.GetHashCode().ToString();
            return _context.Users.Where(user => user.UserName == item.UserName && user.Password == item.Password).SingleOrDefault();
        }

    }
}
