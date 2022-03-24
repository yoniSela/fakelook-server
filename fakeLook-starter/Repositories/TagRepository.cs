using fakeLook_dal.Data;
using fakeLook_models.Models;
using fakeLook_starter.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fakeLook_starter.Repositories
{
    public class TagRepository : ITagRepository
    {
        readonly private DataContext _context;
        public TagRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<Tag> Add(Tag item)
        {
            var temp = _context.Tags.FirstOrDefault(u => u.Content.Equals(item.Content));
            if (temp != null)
            {
                return item;
            } else {
                item.Posts = null;
                item.Comments = null;
                var res = _context.Tags.Add(item);
                await _context.SaveChangesAsync();
                return res.Entity;
            }
        }

        public async Task<Tag> Edit(Tag item)
        {
            var temp = _context.Tags.FirstOrDefault(u => u.Id == item.Id);
            if (temp == null)
            {
                return null;//TODO
            }
            temp.Content = item.Content;
            _context.Tags.Update(temp);
            await _context.SaveChangesAsync();
            return item;
        }

        public ICollection<Tag> GetAll()
        {
            return _context.Tags.ToList();
        }

        public Tag GetById(int id)
        {
            return _context.Tags.SingleOrDefault(p => p.Id == id);
        }

        public ICollection<Tag> GetByPost(int id)
        {
            var post = _context.Posts.SingleOrDefault(p => p.Id == id);
            return _context.Tags.Where(tag => tag.Posts.Contains(post)).ToList();
        }

        public ICollection<Tag> GetByComment(int id)
        {
            var comment = _context.Comments.SingleOrDefault(p => p.Id == id);
            return _context.Tags.Where(tag => tag.Comments.Contains(comment)).ToList();
        }


        public ICollection<Tag> GetByPredicate(Func<Tag, bool> predicate)
        {
            return _context.Tags.Where(predicate).ToList();
        }



    }
}
