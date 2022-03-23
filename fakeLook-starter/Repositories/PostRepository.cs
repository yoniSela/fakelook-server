using fakeLook_dal.Data;
using fakeLook_models.Models;
using fakeLook_starter.Interfaces;
using fakeLook_starter.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fakeLook_starter.Repositories
{
    public class PostRepository : IPostRepository
    {
        readonly private DataContext _context;
        public PostRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Post> Add(Post item)
        {
            var res = _context.Posts.Add(item);
            await _context.SaveChangesAsync();
            return res.Entity;
        }

        public async Task<Post> Edit(Post item)
        {
            var temp = _context.Posts.FirstOrDefault(u => u.Id == item.Id);
            if (temp == null)
            {
                return null;//TODO
            }
            temp.Description = item.Description;
            temp.ImageSorce = item.ImageSorce;
            _context.Posts.Update(temp);
            //_context.Entry<Post>(temp).CurrentValues.SetValues(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public ICollection<Post> GetAll()
        {
            //return _context.Posts.Include(p=> p.Likes).ToList();
            return _context.Posts.OrderByDescending(u => u.Date).ToList();
            //return _context.Posts.ToList();

        }
        public ICollection<Post> GetByQuery(Query query)
        {
            //get after min date
            //get after max date
            //get posted by
                //get user by username
                //get id from user
                //get posts by userId
            // get tagged in 
                //get user by username
                //get id from user
                //get posts by tagged list
            //get tags
            return _context.Posts.OrderByDescending(u => u.Date).ToList();
        }

        private ICollection<Post> FilterByDate(DateTime min, DateTime max)
        {
            return _context.Posts.Where(p => p.Date > min && p.Date < max).ToList();
        }



        public Post GetById(int id)
        {
            return _context.Posts.SingleOrDefault(p => p.Id == id);
        }

        public ICollection<Post> GetByPredicate(Func<Post,bool> predicate)
        {
            return _context.Posts.Where(predicate).ToList();
        }


    }
}
