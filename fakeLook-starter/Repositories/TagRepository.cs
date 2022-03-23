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
                if (item.Posts != null)
                {
                    var newPost = _context.Posts.FirstOrDefault(p => p.Id == item.Posts.FirstOrDefault().Id);
                    var posts = temp.Posts;
                    if (posts == null)
                    {
                        posts = new List<Post>();
                    }
                    if((!posts.Contains(newPost)))
                    {
                        posts.Add(newPost);
                        temp.Posts = posts;
                    }
                }
                if (item.Comments != null)
                {
                    var newComment = _context.Comments.FirstOrDefault(p => p.Id == item.Comments.FirstOrDefault().Id);
                    var comments = temp.Comments;
                    if (comments == null)
                    {
                        comments = new List<Comment>();
                    }
                    if (!comments.Contains(newComment))
                    {
                        comments.Add(newComment);
                        temp.Comments = comments;
                    }
                }
                await _context.SaveChangesAsync();
                return item;
            } else {
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
