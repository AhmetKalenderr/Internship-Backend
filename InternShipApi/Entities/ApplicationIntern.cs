using System;

namespace InternShipApi.Entities
{
    public class ApplicationIntern
    {
        public int Id { get; set; }

        public DateTime AppTime { get; set; }

        public User user { get; set; }

        public int UserId { get; set; }

        // public InternshipPosting post { get; set; }

        public int PostId { get; set; }

    }
}
