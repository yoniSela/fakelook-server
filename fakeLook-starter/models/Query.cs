using System;

namespace fakeLook_starter.models
{
    public class Query
    {
        public DateTime MinDate { get; set; }
        public DateTime MaxDate { get; set; }
        public string[] PostedBy { get; set; }
        public string[] Tagged { get; set; }
        public string[] Tags { get; set; }

        Query(DateTime minDate, DateTime maxDate, string[] PostedBy, string[] Tagged, string[] Tags)
        {
            this.MinDate = minDate;
            this.MaxDate = maxDate;
            this.PostedBy = PostedBy;
            this.Tagged = Tagged;
            this.Tags = Tags;
        }



    }
}
