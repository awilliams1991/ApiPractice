using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmcCodeChallenge.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class AuthorsController : ControllerBase
    {
        private static readonly string[] FirstNames = new[]
        {
            "Scott", "Eoin", "Joseph", "Polly"
        };

        private static readonly string[] LastNames = new[]
        {
            "Adams", "Colfer", "Delaney", "Shulman"
        };

        [HttpGet]
        public IEnumerable<AuthorsDto> GetAllAuthors()
        {
            var authorsDto = new List<AuthorsDto>();

            for (int i = 0; i < LastNames.Length; i++)
            {
                authorsDto.Add(new AuthorsDto { FirstName = FirstNames[i], LastName = LastNames[i], HeadshotImageUrl = (FirstNames[i] + LastNames[i] + ".jpg") });
            }
            return authorsDto;
        }

        [HttpGet]
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
