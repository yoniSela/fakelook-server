﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fakeLook_models.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set;}
        public string UserName { get; set; }
        public string WorkPlace { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }

        /* EF Relations */
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<Like> Likes { get; set; }
        public virtual ICollection<UserTaggedPost> UserTaggedPost { get; set; }
        public virtual ICollection<UserTaggedComment> UserTaggedComment { get; set; }
    }
}
