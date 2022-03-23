using fakeLook_models.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace fakeLook_starter.models
{
    public class Query
    {
        public DateTime MinDate { get; set; } = DateTime.MinValue;
        public DateTime MaxDate { get; set; } = DateTime.Now;
        public int[] PublisherId { get; set; }
        public string[] FilterTags { get; set; }
        public string[] FilterUserTags { get; set; }

        //Query(DateTime minDate, DateTime maxDate, string[] PostedBy, string[] Tagged, string[] Tags)
        //{
        //    this.MinDate = minDate;
        //    this.MaxDate = maxDate;
        //    this.PostedBy = PostedBy;
        //    this.Tagged = Tagged;
        //    this.Tags = Tags;
        //}
        public bool CheckDates(DateTime postDate, DateTime MaxDate, DateTime MinDate)
        {
            return (postDate > MinDate && postDate < MaxDate);
        }
        public bool PostBy(int userId, int[] publisherId)
        {
            if (publisherId!=null)
            {
                return (publisherId.Contains(userId));
            } return true;

        }
        public bool conatinTags(ICollection<Tag> postTags, string[] filterTags)
        {
            if (filterTags!=null)
            {

                foreach (Tag postTag in postTags)
                {

                    if (filterTags.Contains(postTag.Content))
                    {
                        return true;
                    }

                }
                return false;
            } return true;
        }
        //public bool conatinUsers(ICollection<UserTaggedPost> postUserTags, string[] filterUserTags)
        //{

        //    foreach (UserTaggedPost userTag in postUserTags)
        //    {

        //        if (filterUserTags.Contains(userTag.Content))
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}
    }
}
