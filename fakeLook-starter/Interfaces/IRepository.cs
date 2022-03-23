using fakeLook_models.Models;
using fakeLook_starter.models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fakeLook_starter.Interfaces
{
    public interface IRepository<T>
    {
        public Task<T> Add(T item);
        public ICollection<T> GetAll();
        public Task<T> Edit(T item);
        public T GetById(int id);
        public ICollection<T> GetByPredicate(Func<T, bool> predicate);
    }
    public interface IUserRepository : IRepository<User>
    {
        public User Post(User item);
        public User FindItem(User item);



    }
    public interface IPostRepository : IRepository<Post>
    {
    }
    public interface ILikeRepository : IRepository<Like>
    {
        public ICollection<Like> GetByPostId(int id);

    }
    public interface ICommentRepository : IRepository<Comment>
    {
        public ICollection<Comment> GetByPostId(int id);

    }

    public interface ITagRepository : IRepository<Tag>
    {
        public ICollection<Tag> GetByPost(int id);

        public ICollection<Tag> GetByComment(int id);


    }
}
