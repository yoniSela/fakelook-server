using fakeLook_dal.Data;
using fakeLook_models.Models;
using fakeLook_starter.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
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
            //item.Password = item.Password.GetHashCode().ToString();
            item.Password = sha256_hash(item.Password);
            var res = _context.Users.Add(item);
            await _context.SaveChangesAsync();
            return res.Entity;
        }

        private string sha256_hash(string password)
        {
            StringBuilder Sb = new StringBuilder();

            using (SHA256 hash = SHA256Managed.Create())
            {
                Encoding enc = Encoding.UTF8;
                Byte[] result = hash.ComputeHash(enc.GetBytes(password));

                foreach (Byte b in result)
                    Sb.Append(b.ToString("x2"));
            }

            return Sb.ToString();
            
        }

        public User Post(User item)
        {
            //item.Id = int.Parse(Guid.NewGuid().ToString());
            item.Password = sha256_hash(item.Password);
            _context.Users.Add(item);
            return item;
        }

        public async Task<User> Edit(User item)
        {
            var res = GetByName(item.UserName);
            res.Password = sha256_hash(item.Password);
            await _context.SaveChangesAsync();
            return res;
        }

        public ICollection<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public User GetById(int id)
        {
            return _context.Users.SingleOrDefault(p => p.Id == id);
        }


        public User GetByName(string name)
        {
            return _context.Users.SingleOrDefault(p => p.UserName == name);
        }

        public ICollection<User> GetByPredicate(Func<User, bool> predicate)
        {
            return _context.Users.Where(predicate).ToList();
        }

        public User FindItem(User item)
        {
            item.Password = sha256_hash(item.Password);
            return _context.Users.Where(user => user.UserName == item.UserName && user.Password == item.Password).SingleOrDefault();
        }
        public Dictionary<int, string> GetUserNames()
        {
            Dictionary<int, string> usersDictionary = new Dictionary<int, string>();
            var users = GetAll();
            foreach (var user in users)
            {
                usersDictionary.Add(user.Id, user.UserName);
            }
            return usersDictionary;
        }


    }
}

