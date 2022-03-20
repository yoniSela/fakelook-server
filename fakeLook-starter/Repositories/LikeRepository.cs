using fakeLook_dal.Data;
using fakeLook_models.Models;
using fakeLook_starter.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fakeLook_starter.Repositories
{
    public class LikeRepository : ILikeRepository
    {
        readonly private DataContext _context;
        public LikeRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<Like> Add(Like item)
        {
            var res = _context.Likes.Add(item);
            await _context.SaveChangesAsync();
            return res.Entity;
        }

        public async Task<Like> Edit(Like item)
        {
            var temp = _context.Likes.FirstOrDefault(u => u.Id == item.Id);
            if (temp == null)
            {
                return null;//TODO
            }
            temp.IsActive = item.IsActive;
            _context.Likes.Update(temp);
            await _context.SaveChangesAsync();
            return item;
        }

        public ICollection<Like> GetAll()
        {
            return _context.Likes.ToList();
        }
        public ICollection<Like> GetByPostId(int id)
        {
            return _context.Likes.Where(p => p.PostId == id).ToList();
        }

        public Like GetById(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<Like> GetByPredicate(Func<Like, bool> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
