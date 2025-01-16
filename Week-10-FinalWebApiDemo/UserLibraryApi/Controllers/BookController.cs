using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UserLibraryApi.Models;
using UserLibraryApi.Helpers;
using System.Diagnostics;
using System.Web.Http.Cors;
using System.Web;

namespace UserLibraryApi.Controllers
{
    public class BookController : ApiController
    {
        // SortedList to hold books, sorted by the book title (key).
        private static SortedList<string, Book> Books = new SortedList<string, Book>();
        private static readonly string secretKey = "RohanshuBanodhaDemoWebApi290903";

        // Static constructor to add dummy books on server startup
        static BookController()
        {
            // Adding dummy books to the SortedList
            Books.Add("The Great Gatsby", new Book { BookId = 1, Title = "The Great Gatsby", Price = 10.99f });
            Books.Add("1984", new Book { BookId = 2, Title = "1984", Price = 15.99f });
            Books.Add("To Kill a Mockingbird", new Book { BookId = 3, Title = "To Kill a Mockingbird", Price = 12.49f });
            Books.Add("The Catcher in the Rye", new Book { BookId = 4, Title = "The Catcher in the Rye", Price = 14.99f });
            Books.Add("Moby Kick", new Book { BookId = 5, Title = "Moby Kick", Price = 18.99f });
        }

        // POST: Add a new book to the list.
        [HttpPost]
        [Route("books/add")]
        public IHttpActionResult AddBook([FromBody] Book book)
        {
            try
            {
                // Check if the book already exists
                if (Books.ContainsKey(book.Title))
                {
                    return BadRequest("Book with this title already exists.");
                }

                // Add the new book to the SortedList
                Books.Add(book.Title, book);

                return Ok(new { message = "Book added successfully", book });
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // GET: Get a list of books present in the library (sorted by title).
        [HttpGet]
        [Route("books")]
        [EnableCors(origins: "www.google.com", headers: "*", methods: "GET")]
        public IHttpActionResult GetAllBooks()
        {
            try
            {
                // Return all books sorted by title
                var sortedBooks = Books.Values.ToList();
                return Ok(sortedBooks);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // GET: Get books for a user by their JWT token.
        [HttpGet]
        [Route("user/getuserbooks")]
        public HttpResponseMessage GetBooksByUser()
        {
            try
            {
                // Retrieve the JWT token from the headers (for example, "Bearer <JWT_TOKEN>")
                var token = Request.Headers.Authorization?.Parameter;

                if (token == null)
                {
                    //return Unauthorized();
                    return Request.CreateResponse(HttpStatusCode.Unauthorized);
                }

                string usrname = JWTHelper.ExtractUsernameFromToken(token);
                User usr = UserV1Controller.Users.FirstOrDefault(e => e.Username == usrname);
                if (usr != null)
                {
                    string eTag = "hello";

                    //return Ok(new {Message= $"Found for {usr.Username}", Books = usr.purchasedBooks});
                    Debug.WriteLine(Request.Headers);
                    if (Request.Headers.Contains("If-None-Match") && Request.Headers.GetValues("If-None-Match").FirstOrDefault() == eTag)
                    {
                        Debug.WriteLine("\n\nuser exists" + usr.purchasedBooks);
                        // Return 304 Not Modified if the ETag matches
                        return Request.CreateResponse(HttpStatusCode.NotModified);
                    }

                    var response = Request.CreateResponse(HttpStatusCode.OK, new
                    {
                        Message = $"Found books for {usr.Username}",
                        Books = usr.purchasedBooks
                    });

                    response.Headers.CacheControl = new System.Net.Http.Headers.CacheControlHeaderValue
                    {
                        Public = true,
                        MaxAge = TimeSpan.FromSeconds(25),
                        MustRevalidate = true
                    };

                    return response;
                }
                Debug.WriteLine("out");

                // If the user is not authorized, return an empty response or error.
                return Request.CreateResponse(HttpStatusCode.Unauthorized);
                //return Unauthorized();
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
                //return InternalServerError();
            }
        }

        [HttpPost]
        [Route("user/purchasebook")]
        public IHttpActionResult PurchaseBook([FromBody] string title)
        {
            try
            {
                if (Books.TryGetValue(title, out Book book))
                {
                    // Retrieve the JWT token from the headers (for example, "Bearer <JWT_TOKEN>")
                    var token = Request.Headers.Authorization?.Parameter;
                    if (token == null)
                    {
                        return Unauthorized();
                    }

                    string usrname = JWTHelper.ExtractUsernameFromToken(token);
                    User usr = UserV1Controller.Users.FirstOrDefault(e => e.Username == usrname);
                    if(usr != null)
                    {
                        usr.purchasedBooks.Add(book);
                        return Ok(new { Message = $"Book purchased successfully by {usrname}", PurchasedBook = book });
                    }
                    return NotFound();
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        private string GenerateETag(List<Book> purchasedBooks)
        {
            // Generate a hash of the purchased books list. You can use a different method for generating ETags.
            var booksString = string.Join(",", purchasedBooks.Select(b => b.BookId + b.Title));  // Simplified; customize as needed
            var hash = System.Security.Cryptography.SHA256.Create().ComputeHash(System.Text.Encoding.UTF8.GetBytes(booksString));
            return Convert.ToBase64String(hash);  // Use the hash as the ETag
        }

    }
}
