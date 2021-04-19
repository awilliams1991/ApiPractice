using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmcCodeChallenge.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        private static readonly string[] Titles = new[]
        {
            "Hitch Hiker's Guide to the Galaxy", "Artemis Fowl", 
            "The Last Apprentice: Attack of the Fiend", "Skullduggary Pleasant", "Skullduggary Pleasant: Playing With Fire"
        };

        private static readonly string[] Descriptions = new[]
        {
            "Join Douglas Adams's hapless hero Arthur Dent as he travels the galaxy with his intrepid pal Ford Prefect, getting into horrible messes and generally wreaking hilarious havoc. Dent is grabbed from Earth moments before a cosmic construction team obliterates the planet to build a freeway. You'll never read funnier science fiction; Adams is a master of intelligent satire, barbed wit, and comedic dialogue. The Hitchhiker's Guide is rich in comedic detail and thought-provoking situations and stands up to multiple reads. Required reading for science fiction fans, this book (and its follow-ups) is also sure to please fans of Monty Python, Terry Pratchett's Discworld series, and British sitcoms.",
            "Colfer's (Benny and Omar) crime caper fantasy, the first in a series, starts off with a slam-bang premise: anti-hero Artemis Fowl is a boy-genius last in line of a legendary crime family teetering on the brink of destruction. With the assistance of his bodyguard, Butler, he masterminds his plan to regain the Fowls' former glory: capture a fairy and hold her ransom for the legendary fairy gold. However, his feisty mark, Holly, turns out to be a member of the 'LEPrecon, an elite branch of the Lower Elements Police,' so a wisecracking team of satyrs, trolls, dwarfs and fellow fairies set out to rescue her. Despite numerous clever gadgets and an innovative take on traditional fairy lore, the author falls short of the bar. The rapid-fire dialogue may work as a screenplay with the aid of visual effects (a film is due out from Talk/Miramax in 2002) but, on the page, it often falls flat. The narrative hops from character to character, so readers intrigued by Artemis's wily, autocratic personality have to kill a good deal of time with the relatively bland Holly and her cohorts [...]. Technology buffs may appreciate the imaginative fairy-world inventions and action-lovers will get some kicks, but the series is no classic in the making. Ages 12-up.",
            "Thomas Ward is the apprentice for the local Spook, who banishes boggarts and drives away ghosts. But now a new danger is threatening Tom's world: the witches are rising and the three most powerful clans are uniting in order to conjure an unimaginable evil.",
            "She’s twelve. He’s dead. But together they’re going to save the world. Hopefully. The iconic first book in the bestselling Skulduggery Pleasant series.Stephanie's uncle Gordon is a writer of horror fiction. But when he dies and leaves her his estate, Stephanie learns that while he may have written horror, it certainly wasn't fiction. Pursued by evil forces, Stephanie finds help from an unusual source – the wisecracking skeleton of a dead sorcerer…",
            "Skulduggery and Valkyrie are facing a new enemy: Baron Vengeous, who is determined to bring back the terrifying Faceless Ones and is crafting an army of evil to help him. Added to that, Vengeous is about to enlist a new ally (if he can raise it from the dead): the horrible Grotesquery, a very unlikable monster of legend. Once Vengeous is on the loose, dead bodies and vampires start showing up all over Ireland. Now pretty much everybody is out to kill Valkyrie, and the daring detective duo faces its biggest challenge yet."
        };

        private static readonly string[] PublishDates = new[]
        {
            "09271995", "08072009", "01012008", "05012018", "09252009"
        };

        private static readonly int[] AuthorIds = new[] { 1, 2, 3, 4, 4 };

        private static readonly int[] CategoryIds = new[] { 11, 1, 3, 1, 1 };

        [HttpGet]
        [Route("all")]
        public IEnumerable<BooksDto> GetAllBooks()
        {
            var booksDto = new List<BooksDto>();

            for (int i = 0; i < Titles.Length; i++)
            {
                booksDto.Add(new BooksDto { 
                    Title = Titles[i],
                    Descrption = Descriptions[i],
                    CoverImageUrl = (AuthorIds[i] + PublishDates[i] + ".jpg"),
                    AuthorId = AuthorIds[i],
                    CategoryId = CategoryIds[i]
                });
            }
            return booksDto;
        }

        [HttpGet]
        [Route("single/{imageUrl}")]
        public BooksDto GetSingleBook(string imageUrl)
        {
            var books = GetAllBooks();
            var singleBook = books.Where(x => x.CoverImageUrl == imageUrl).FirstOrDefault();
            if (singleBook == null)
            {
                return null;
            }
            else
            {
                return singleBook;
            }
        }

        [HttpGet]
        [Route("author/{authorId}")]
        public IEnumerable<BooksDto> GetAllBooksByAuthor(int authorId)
        {
            var books = GetAllBooks();
            var singleAuthor = books.Where(x => x.AuthorId == authorId);

            if (authorId == 0)
            {
                return null;
            }
            else
            {
                return singleAuthor;
            }
        }

        [HttpGet]
        [Route("category/{categoryId}")]
        public IEnumerable<BooksDto> GetAllBooksInCategory(int categoryId)
        {
            var books = GetAllBooks();
            var category = books.Where(x => x.CategoryId == categoryId);

            if (categoryId == 0)
            {
                return null;
            }
            else
            {
                return category;
            }
        }

        [HttpGet]
        [Route("category/{authorId}/{categoryId}")]
        public IEnumerable<BooksDto> GetBooksByAuthorAndCategory(int authorId, int categoryId)
        {
            var books = GetAllBooks();
            var booksByAuthorCategory = books.Where(x => x.AuthorId == authorId && x.CategoryId == categoryId);

            if (booksByAuthorCategory == null)
            {
                return null;
            }
            else
            {
                return booksByAuthorCategory;
            }
        }

        //This will display as many results as the user puts in the last section of the url
        [HttpGet]
        [Route("category/{authorId}/{categoryId}/{results}")]
        public IEnumerable<BooksDto> GetTopBooksByAuthorAndCategory(int authorId, int categoryId, int results)
        {
            var books = GetAllBooks();
            var topBooksByAuthorCategory = books.Where(x => x.AuthorId == authorId && x.CategoryId == categoryId);

            if (topBooksByAuthorCategory == null)
            {
                return null;
            }
            else
            {
                return topBooksByAuthorCategory.Take(results);
            }
        }
    }
}
