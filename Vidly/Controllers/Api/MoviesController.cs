using System;
using System.Linq;
using System.Web.Http;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/movies
        public IHttpActionResult GetMovies()
        {
            return Ok(_context.Movies.ToList());
        }

        // GET /api/movies/1
        public IHttpActionResult GetMovies(int id)
        {
            var movie = _context.Movies.FirstOrDefault(m => m.Id == id);
            if (movie == null)
                return NotFound();

            return Ok(movie);
        }

        // POST /api/movies
        [HttpPost]
        public IHttpActionResult CreateMovie(Movie movie)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            movie.DateAdded = DateTime.UtcNow;
            
            _context.Movies.Add(movie);
            _context.SaveChanges();

            return Ok();
        }

        // PUT /api/movies/1
        [HttpPut]
        public IHttpActionResult UpdateMovie(int id, Movie movie)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movieInDb == null)
                return NotFound();

            movieInDb.Name = movie.Name;
            movieInDb.GenreId = movie.GenreId;
            movieInDb.NumberInStock = movie.NumberInStock;
            movieInDb.ReleaseDate = movie.ReleaseDate;

            _context.SaveChanges();

            return Ok();
        }

        // DELETE /api/movies/1
        [HttpDelete]
        public IHttpActionResult DeleteMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return NotFound();

            _context.Movies.Remove(movie);
            _context.SaveChanges();

            return Ok();
        }

    }
}
