using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmcCodeChallenge.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : Controller
    {
        private static readonly string[] Categories = new[]
        {
            "Fantasy", "Romance", "Science Fiction", "Western", "Non-Fiction", "History", "Religion", "Mystery", "Action", "Thriller", "Audio Book"
        };

        [HttpGet]
        public IEnumerable<CategoryDto> GetCategory()
        {
            return Categories.Select(x => new CategoryDto
            {
                Name = x
            });
        }
    }
}
