using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmcCodeChallenge
{
    public class AuthorsDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string HeadshotImageUrl { get; set; }
        public int AuthorId { get; set; }

        
        public string FullName { get { return FirstName + " " + LastName; }}
    }
}
