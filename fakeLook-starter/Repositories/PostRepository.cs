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
            foreach(Tag tag in item.Tags)
            {
                TagRepository tagRepository = new(_context);
                await tagRepository.Add(tag);
            }
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
            foreach (Tag tag in item.Tags)
            {
                TagRepository tagRepository = new(_context);
                await tagRepository.Add(tag);
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
            return _context.Posts.Include(p=>p.Tags).Where(predicate).ToList();
        }


    }
}
