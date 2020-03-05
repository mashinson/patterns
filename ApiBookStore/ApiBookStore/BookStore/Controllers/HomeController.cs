
using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Controllers
{
    public class HomeController : Controller
    {
        private Uri BaseUrl = new Uri("http://www.dev.apibookstore.com");
        public ActionResult Books()
        {
            return View();
        }

        public ActionResult _BookList()
        {
            IEnumerable<BookModel> model = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = BaseUrl;
                //HTTP GET
                var responseTask = client.GetAsync("/api/value/getbooks");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<BookModel>>();
                    readTask.Wait();

                    model = readTask.Result;
                }
            }
            return PartialView("_BookList", model);
        }

        [HttpPost]
        public ActionResult _BookList(BookFilterModel model)
        {
            IEnumerable<BookModel> bookModel = null;

            FilterData filterData = new FilterData()
            {
                AuthorID = Convert.ToInt32(model.Author),
                GenreID = Convert.ToInt32(model.Genre),
                HouseID = Convert.ToInt32(model.PublishingHouse),
                CreationDate = model.CreationDate != null ? Convert.ToInt32(model.CreationDate) : (int?)null
            };
            using (var client = new HttpClient())
            {
                client.BaseAddress = BaseUrl;
                //HTTP GET
                var responseTask = client.PostAsJsonAsync("/api/value/getfilterbooks", filterData);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<BookModel>>();
                    readTask.Wait();

                    bookModel = readTask.Result;
                }
            }
            return PartialView("_BookList", bookModel);
        }

        public ActionResult _BookFilters()
        {
            BookFilterModel filters = new BookFilterModel();
            FiltersModel jsonModel = new FiltersModel();

            using (var client = new HttpClient())
            {
                client.BaseAddress = BaseUrl;
                //HTTP GET
                var responseTask = client.GetAsync("/api/value/getfilters");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<FiltersModel>();
                    readTask.Wait();

                    jsonModel = readTask.Result;

                }
            }
            if (jsonModel != null)
            {

                filters = new BookFilterModel
                {
                    Authors = jsonModel.Authors.ToList().Select(
               t => new SelectListItem()
               {
                   Value = t.ID,
                   Text = t.Name
               }
               ).ToList(),

                    Genres = jsonModel.Genges.ToList().Select(
               t => new SelectListItem()
               {
                   Value = t.ID,
                   Text = t.Name
               }
               ).ToList(),

                    PublishingHouses = jsonModel.PublishingHouses.ToList().Select(
               t => new SelectListItem()
               {
                   Value = t.ID,
                   Text = t.Name
               }
               ).ToList()
                };
            }
            filters.Authors.Add(new SelectListItem { Text = "All Authors", Value = "-1", Selected = true });
            filters.PublishingHouses.Add(new SelectListItem { Text = "All Publishing Houses", Value = "-1", Selected = true });
            filters.Genres.Add(new SelectListItem { Text = "All Genres", Value = "-1", Selected = true });
            return PartialView("_BookFilters", filters);
        }

        public ActionResult EditBook(int id)
        {
            BookFilterModel filters = new BookFilterModel();
            FiltersModel jsonModel = new FiltersModel();
            BookModel book = new BookModel();
            using (var client = new HttpClient())
            {
                client.BaseAddress = BaseUrl;

                string url = "/api/value/getbook?id=" + id.ToString();
                var responseTask = client.GetAsync(url);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<BookModel>();
                    readTask.Wait();

                    book = readTask.Result;
                }
            }
            using (var client = new HttpClient())
            {
                client.BaseAddress = BaseUrl;
                //HTTP GET
                var responseTask = client.GetAsync("/api/value/getfilters");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<FiltersModel>();
                    readTask.Wait();

                    jsonModel = readTask.Result;

                }
            }
            if (jsonModel != null)
            {
                filters = new BookFilterModel
                {
                    Authors = jsonModel.Authors.ToList().Select(
               t => new SelectListItem()
               {
                   Value = t.ID,
                   Text = t.Name,
                   Selected = t.Name == book.AuthorName
               }
               ).ToList(),

                    Genres = jsonModel.Genges.ToList().Select(
               t => new SelectListItem()
               {
                   Value = t.ID,
                   Text = t.Name,
                    Selected = t.Name == book.GenreName
               }
               ).ToList(),

                    PublishingHouses = jsonModel.PublishingHouses.ToList().Select(
               t => new SelectListItem()
               {
                   Value = t.ID,
                   Text = t.Name,
                   Selected = t.Name == book.PublishingHomeName
               }
               ).ToList()
                };
            }
            filters.ID = book.ID.ToString();
            filters.CreationDate = book.Year.ToString();
            filters.Name = book.Name;
            return View("EditBook", filters);
        }

        [HttpPost]
        public ActionResult EditBook(BookFilterModel model)
        {
            BookModel book = new BookModel()
            {
                ID = Convert.ToInt32(model.ID),
                AuthorID = Convert.ToInt32(model.Author),
                PublishingHomeID = Convert.ToInt32(model.PublishingHouse),
                Name = model.Name,
                Year = Convert.ToInt32(model.CreationDate),
                GenreID = Convert.ToInt32(model.Genre)
            };

            using (var client = new HttpClient())
            {
                client.BaseAddress = BaseUrl;
                string url = "/api/value/editbook";

                var responseTask = client.PutAsJsonAsync(url, book);
                responseTask.Wait();
            }

            return View("Books");
        }

        public ActionResult CreateBook()
        {
            BookFilterModel filters = new BookFilterModel();
            FiltersModel jsonModel = new FiltersModel();

            using (var client = new HttpClient())
            {
                client.BaseAddress = BaseUrl;
                //HTTP GET
                var responseTask = client.GetAsync("/api/value/getfilters");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<FiltersModel>();
                    readTask.Wait();

                    jsonModel = readTask.Result;

                }
            }
            if (jsonModel != null)
            {
                filters = new BookFilterModel
                {
                    Authors = jsonModel.Authors.ToList().Select(
               t => new SelectListItem()
               {
                   Value = t.ID,
                   Text = t.Name
               }
               ).ToList(),

                    Genres = jsonModel.Genges.ToList().Select(
               t => new SelectListItem()
               {
                   Value = t.ID,
                   Text = t.Name
               }
               ).ToList(),

                    PublishingHouses = jsonModel.PublishingHouses.ToList().Select(
               t => new SelectListItem()
               {
                   Value = t.ID,
                   Text = t.Name
               }
               ).ToList()
                };
            }

            return View("CreateBook", filters);
        }

        [HttpPost]
        public ActionResult CreateBook(BookFilterModel model)
        {
            BookModel book = new BookModel()
            {
                AuthorID = Convert.ToInt32(model.Author),
                PublishingHomeID = Convert.ToInt32(model.PublishingHouse),
                Name = model.Name,
                Year = Convert.ToInt32(model.CreationDate),
                GenreID = Convert.ToInt32(model.Genre)
            };

            using (var client = new HttpClient())
            {
                client.BaseAddress = BaseUrl;
                string url = "/api/value/createbook";

                var responseTask = client.PostAsJsonAsync(url, book);
                responseTask.Wait();
            }

            return View("Books");
        }

        public void DeleteBook(int id)
        {

                using (var client = new HttpClient())
                {
                    client.BaseAddress = BaseUrl;
                string url = "/api/value/deletebook?id=" + id;
                    var responseTask = client.DeleteAsync(url);
                    responseTask.Wait();
                }
        }
    }
}