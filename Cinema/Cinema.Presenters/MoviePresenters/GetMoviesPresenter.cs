using Bytes2you.Validation;
using Cinema.Data.Models;
using Cinema.Data.Models.Contracts;
using Cinema.Data.Services.Contracts;
using Cinema.Presenters.Contracts;
using System.Linq;

namespace Cinema.Presenters.MoviePresenters
{
    public class GetMoviesPresenter : IGetMoviesPresenter
    {
        private readonly IMoviesService moviesService;

        public GetMoviesPresenter(IMoviesService moviesService)
        {
            Guard.WhenArgument(moviesService, "moviesService").IsNull().Throw();
            this.moviesService = moviesService;
        }

        public IQueryable<Movie> GetAllMovies()
        {
            return this.moviesService.GetAll();
        }

        public IMovie GetMovieById(string id)
        {
            Guard.WhenArgument(id, "id").IsNullOrEmpty().Throw();
            return this.moviesService.GetById(id);
        }
    }
}
