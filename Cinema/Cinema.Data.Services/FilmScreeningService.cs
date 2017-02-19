using Bytes2you.Validation;
using Cinema.Data.Models;
using Cinema.Data.Models.Contracts;
using Cinema.Data.Repositories;
using Cinema.Data.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cinema.Data.Services
{
    public class FilmScreeningService : IFilmScreeningService
    {
        private const int InitialSeatsCount = 20;

        private IRepository<FilmScreening> screenings;
        private IFilmScreening filmScreeningToCreate;

        public FilmScreeningService(IRepository<FilmScreening> screenings, IFilmScreening filmScreening)
        {
            Guard.WhenArgument(screenings, "screenings").IsNull().Throw();
            Guard.WhenArgument(filmScreening, "filmScreening").IsNull().Throw();

            this.screenings = screenings;
            this.filmScreeningToCreate = filmScreening;
        }

        public void Create(string date, string movieId, string price)
        {
            this.filmScreeningToCreate.Start = DateTime.Parse(date);
            this.filmScreeningToCreate.TargetMovieId = int.Parse(movieId);
            this.filmScreeningToCreate.Price = decimal.Parse(price);
            this.filmScreeningToCreate.Seats = new List<Seat>(InitialSeatsCount);

            for (int i = 0; i < InitialSeatsCount; i++)
            {
                filmScreeningToCreate.Seats.Add((new Seat() { IsFree = true }));
            }

            this.screenings.Add((FilmScreening)filmScreeningToCreate);
            this.screenings.SaveChanges();
        }

        public int GetAvailableCount(string id)
        {
            Guard.WhenArgument(id, "id").IsNullOrEmpty().Throw();
            int parsedId;
            bool isNumber = int.TryParse(id, out parsedId);
            if (!isNumber)
            {
                throw new ArgumentException();
            }

            return this.screenings.GetById(parsedId).Seats.Where(x => x.IsFree == true).Count();
        }

        public IQueryable<FilmScreening> GetAllScreenings()
        {
            return this.screenings.All();
        }

        public IQueryable<FilmScreening> GetAllScreeningsByDate(string date)
        {
            if (!string.IsNullOrEmpty(date))
            {
                DateTime targetDate = DateTime.Parse(date);
                return this.screenings.All().Where(x =>
                                                  (x.Start.Day == targetDate.Day) &&
                                                  (x.Start.Month == targetDate.Month) &&
                                                  (x.Start.Year == targetDate.Year));
            }
            else
            {
                return this.screenings.All();
            }
        }

        public IQueryable<FilmScreening> GetAllFutureScreenings()
        {
            return this.screenings.All().Where(x => x.Start > DateTime.Now);
        }

        public IFilmScreening GetById(string id)
        {
            Guard.WhenArgument(id, "id").IsNullOrEmpty().Throw();
            int parsedId;
            bool isNumber = int.TryParse(id, out parsedId);
            if (!isNumber)
            {
                throw new ArgumentException();
            }

            return this.screenings.GetById(parsedId);
        }

        public void UpdateById(string id, FilmScreening updatedFilmScreening)
        {
            int parsedId;
            int.TryParse(id, out parsedId);
            var targetScreening = this.screenings.GetById(parsedId);
            targetScreening = updatedFilmScreening;
            this.screenings.Update(targetScreening);
            this.screenings.SaveChanges();
        }

        public IQueryable<FilmScreening> GetScreeningsByMovieTitle(string title)
        {
            if (!string.IsNullOrEmpty(title))
            {
                return this.screenings.All().Where(s => s.TargetMovie.Name.Contains(title));
            }
            else
            {
                return this.screenings.All();
            }
        }

        public IEnumerable<User> GetUniqueBookersFromScreeningById(string id)
        {
            int parsedId;
            int.TryParse(id, out parsedId);
            var targetScreening = this.screenings.GetById(parsedId);

            return targetScreening.Seats.Select(s => s.User).Where(u => u != null).Distinct();
        }

        public string GetMovieTitleByScreeningId(string id)
        {
            int parsedId;
            int.TryParse(id, out parsedId);

            return this.screenings.GetById(parsedId).TargetMovie.Name;
        }
    }
}
