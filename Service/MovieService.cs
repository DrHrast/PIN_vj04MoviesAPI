using MoviesAPI.Data;
using MoviesAPI.VModel;

namespace MoviesAPI.Service
{
    public class MovieService
    {
        private AppDbContext _context;
        public MovieService(AppDbContext context)
        {
            _context = context;
        }

        public List<Movie> GetAllMovies()
        {
            return _context.Movie.ToList();
        }

        public Movie GetMovieById(int id)
        {
            return _context.Movie.FirstOrDefault(x => x.Id == id);
        }

        public Movie UpdateMovieById(int id, MovieVM movieVM)
        {
            var movie = _context.Movie.FirstOrDefault(x => x.Id == id);
            if (movie != null)
            {
                movie.Name = movieVM.Name;
                movie.Genre = movieVM.Genre;
                movie.Year = movieVM.Year;
                _context.SaveChanges();
            }
            return movie;
        }

        public void DeleteMovie(int id)
        {
            var movie = _context.Movie.FirstOrDefault(x => x.Id == id);
            _context.Movie.Remove(movie);
            _context.SaveChanges();
        }

        public void AddMovie(MovieVM movie)
        {
            var newMovie = new Movie()
            {
                Name = movie.Name,
                Genre = movie.Genre,
                Year = movie.Year,
            };
            _context.Movie.Add(newMovie);
            _context.SaveChanges();
        }

        public void AddMultiple(List<MovieVM> movies)
        {
            foreach (var movie in movies)
            {
                var newMovie = new Movie()
                {
                    Name = movie.Name,
                    Genre = movie.Genre,
                    Year = movie.Year,
                };
                _context.Movie.Add(newMovie);
                _context.SaveChanges();
            }
        }

    }
}
