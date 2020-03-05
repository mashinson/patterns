using ApiBookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

using System.Web.Http.Results;

namespace ApiBookStore.Controllers
{
    public class ValueController : ApiController
    {
        BookStoreContext db = new BookStoreContext();

        public IHttpActionResult GetBooks()
        {
            List<BookModel> listOfBooks = db.Books.Select(b => new BookModel
            {
                ID = b.Id,
                Name = b.Name,
                AuthorName = b.Author.Name + " " + b.Author.Surname,
                GenreName = b.Genre.Name,
                PublishingHomeName = b.PublishingHome.Name,
                Year = b.Year
            }).ToList();



            return Ok(listOfBooks);
        }

        public IHttpActionResult GetAuthors()
        {
            List<AuthorModel> listOfauthors = db.Authors.Select(b => new AuthorModel
            {
                ID = b.ID.ToString(),
                Name = b.Name + " " + b.Surname
            }).ToList();
            if (listOfauthors.Count == 0)
            {
                return NotFound();
            }
            return Ok(listOfauthors);
        }

        public IHttpActionResult GetGenres()
        {
            List<GenreModel> listOfGenre = db.Authors.Select(b => new GenreModel
            {
                ID = b.ID.ToString(),
                Name = b.Name
            }).ToList();

            if (listOfGenre.Count == 0)
            {
                return NotFound();
            }
            return Ok(listOfGenre);
        }

        public IHttpActionResult GetPublishingHomes()
        {
            List<PublishingHomeModel> listOfHome = db.PublishingHomes.Select(b => new PublishingHomeModel
            {
                ID = b.ID.ToString(),
                Name = b.Name
            }).ToList();

            if (listOfHome.Count == 0)
            {
                return NotFound();
            }
            return Ok(listOfHome);
        }

        public IHttpActionResult GetFilters()
        {
            FiltersModel model = new FiltersModel()
            {
                Authors = db.Authors.Select(b => new AuthorModel
                {
                    ID = b.ID.ToString(),
                    Name = b.Name + " " + b.Surname
                }),
                Genges = db.Genres.Select(b => new GenreModel
                {
                    ID = b.ID.ToString(),
                    Name = b.Name
                }),
                PublishingHouses = db.PublishingHomes.Select(b => new PublishingHomeModel
                {
                    ID = b.ID.ToString(),
                    Name = b.Name
                })
            };

            if (model == null)
            {
                return NotFound();
            }
            return Ok(model);
        }

        public IHttpActionResult GetBook(int id)
        {
            Book book = db.Books.FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                return NotFound();
            }
            BookModel model = new BookModel()
            {
                ID = book.Id,
                Name = book.Name,
                AuthorName = book.Author.Name,
                GenreName = book.Genre.Name,
                PublishingHomeName = book.PublishingHome.Name,
                Year = book.Year
            };
            return Ok(model);
        }

        [HttpPost]
        public IHttpActionResult GetFilterBooks([FromBody]FilterData data)
        {
            IEnumerable<BookModel> listOfBooks = null;
            List<IFilterPredicate> list = new List<IFilterPredicate>
            {
                new AuthorIDFilterPredicate(),
                new GenreIDFilterPredicate(),
                new CreationDateFilterPredicate(),
                new PublishingHouseFilterPredicate()
                };
            BookFilterPredicate predicate = new BookFilterPredicate(data, list);
            //var books = db.Books.Where(b => b.Id == 1).ToList();
            var books = Get(book => predicate.CheckBook(book)).ToList();

            listOfBooks = books.Select(b => new BookModel
            {
                ID = b.Id,
                Name = b.Name,
                AuthorName = b.Author.Name + " " + b.Author.Surname,
                GenreName = b.Genre.Name,
                PublishingHomeName = b.PublishingHome.Name,
                Year = b.Year
            }).ToList();

            return Ok(listOfBooks);
        }


        [HttpPost]
        public void CreateBook([FromBody]BookModel bookModel)
        {
            Book book = new Book();
            book.Name = bookModel.Name;
            book.PublishingHome_ID = bookModel.PublishingHomeID;
            book.Year = bookModel.Year;
            book.Genre_ID = bookModel.GenreID;
            book.Author_ID = bookModel.AuthorID;
            db.Books.Add(book);
            db.SaveChanges();
        }

        [HttpPut]
        public void EditBook([FromBody]BookModel book)
        {
            var result = db.Books.SingleOrDefault(b => b.Id == book.ID);
            if (result != null)
            {
                result.Name = book.Name;
                result.PublishingHome_ID = book.PublishingHomeID;
                result.Year = book.Year;
                result.Genre_ID = book.GenreID;
                result.Author_ID = book.AuthorID;
                db.SaveChanges();
            }
        }


        [HttpDelete]
        public void DeleteBook(int id)
        {
            Book book = db.Books.Find(id);
            if (book != null)
            {
                db.Books.Remove(book);
                db.SaveChanges();
            }
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private IEnumerable<Book> Get(Func<Book, bool> predicate)
        {
            return db.Books.AsNoTracking().Where(predicate).ToList();
        }


    }
}

