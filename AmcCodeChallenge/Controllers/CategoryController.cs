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

        private static readonly int[] CategoryId = new[]
        {
            1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11
        };

        [HttpGet]
        public IEnumerable<CategoryDto> GetCategory()
        {
            var categoryDto = new List<CategoryDto>();

            for (int i = 0; i < CategoryId.Length; i++)
            {
                categoryDto.Add(new CategoryDto { 
                    CategoryId = CategoryId[i],
                    Name = Categories[i] });
            }
            return categoryDto;
        }
    }
}
