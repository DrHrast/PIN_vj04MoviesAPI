using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Data;
using MoviesAPI.Service;
using MoviesAPI.VModel;

namespace MoviesAPI.Controllers //AllsportsAPI.com
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        public MovieService MovieService { get; set; }

        public MoviesController(MovieService movieService) { 
            MovieService = movieService;
        }

        [HttpPost]
        public IActionResult AddMovie([FromBody] MovieVM movie)
        {
            MovieService.AddMovie(movie);
            return Ok();
        }

        [HttpPost("mult")]
        public IActionResult AddMultiple([FromBody] List<MovieVM> movies)
        {
            MovieService.AddMultiple(movies);
            return Ok();
        }


        [HttpGet]
        public IActionResult GetAllMovies()
        {
            var allMovies = MovieService.GetAllMovies();
            return Ok(allMovies);
        }
        [HttpGet("id")]
        public IActionResult GetMovieById([FromQuery] int id)
        {
            var movie = MovieService.GetMovieById(id);
            return Ok(movie);
        }

        [HttpPut("id")]
        public IActionResult UpdateMovieById([FromQuery] int id, [FromBody] MovieVM movieVM)
        {
            var updatedMovie = MovieService.UpdateMovieById(id, movieVM);
            return Ok(updatedMovie);
        }

        [HttpDelete("id")]
        public IActionResult DeleteMovie([FromQuery] int id)
        {
            MovieService.DeleteMovie(id);
            return Ok();
        }


    }
}
