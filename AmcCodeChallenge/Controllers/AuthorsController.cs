using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmcCodeChallenge.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorsController : ControllerBase
    {
        private static readonly string[] FirstNames = new[]
        {
            "Scott", "Eoin", "Joseph", "Derek"
        };

        private static readonly string[] LastNames = new[]
        {
            "Adams", "Colfer", "Delaney", "Landy"
        };
        private static readonly int[] AuthorId = new[] { 1, 2, 3, 4 };

        [HttpGet]
        [Route("all")]
        public IEnumerable<AuthorsDto> GetAllAuthors()
        {
            var authorsDto = new List<AuthorsDto>();

            for (int i = 0; i < LastNames.Length; i++)
            {
                authorsDto.Add(new AuthorsDto { FirstName = FirstNames[i], LastName = LastNames[i], HeadshotImageUrl = (FirstNames[i] + LastNames[i] + ".jpg"), AuthorId = AuthorId[i] });
            }
            return authorsDto;
        }

        [HttpGet]
        [Route("single/{imageUrl}")]
        public AuthorsDto GetAuthor(string imageUrl)
        {
            var authors = GetAllAuthors();
            var singleAuthor = authors.Where(x => x.HeadshotImageUrl == imageUrl).FirstOrDefault();

            if (singleAuthor == null)
            {
                return null;
            }
            else
            {
            return singleAuthor;
            }
        }
    }
}
