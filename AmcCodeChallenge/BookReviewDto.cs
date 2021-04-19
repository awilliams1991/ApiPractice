using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmcCodeChallenge
{
    public class BookReviewDto
    {
        public string ReviewerName { get; set; }
        public string ReviewText { get; set; }
        public int Rating { get; set; }
        public DateTime PublishDate { get; set; }

    }
}
