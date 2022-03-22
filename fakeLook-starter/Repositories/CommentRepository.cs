using fakeLook_dal.Data;
using fakeLook_models.Models;
using fakeLook_starter.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fakeLook_starter.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        readonly private DataContext _context;
        public CommentRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<Comment> Add(Comment item)
        {
            var res = _context.Comments.Add(item);
            await _context.SaveChangesAsync();
            return res.Entity;
        }

        public async Task<Comment> Edit(Comment item)
        {
            var temp = _context.Comments.FirstOrDefault(u => u.Id == item.Id);
            if (temp == null)
            {
                return null;//TODO
            }
            temp.Content = item.Content;
            _context.Comments.Update(temp);
            await _context.SaveChangesAsync();
            return item;
        }

        public ICollection<Comment> GetAll()
        {
            return _context.Comments.ToList();
        }

        public Comment GetById(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<Comment> GetByPostId(int id)
        {
            return _context.Comments.Where(p => p.PostId == id).ToList();
        }

        public ICollection<Comment> GetByPredicate(Func<Comment, bool> predicate)
        {
            throw new NotImplementedException();
        }

    }
}
