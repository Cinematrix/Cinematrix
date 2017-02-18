using Cinema.Data.Models;
using Cinema.Data.Models.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Cinema.Data.Services.Contracts
{
    public interface IFilmScreeningService
    {
        IQueryable<FilmScreening> GetAllScreenings();

        IQueryable<FilmScreening> GetAllScreeningsByDate(string date);

        IQueryable<FilmScreening> GetScreeningsByMovieTitle(string title);

        IQueryable<FilmScreening> GetAllFutureScreenings();

        IEnumerable<User> GetUniqueBookersFromScreeningById(string id);

        string GetMovieTitleByScreeningId(string id);

        IFilmScreening GetById(string id);

        int GetAvailableCount(string id);

        void UpdateById(string id, FilmScreening updatedFilmScreening);

        void DeleteById(int id);

        void Create(string date, string movieId, string price);
    }
}
