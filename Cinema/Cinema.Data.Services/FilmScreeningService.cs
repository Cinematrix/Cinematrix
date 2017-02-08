using Cinema.Data.Models;
using Cinema.Data.Models.Contracts;
using Cinema.Data.Repositories;
using Cinema.Data.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Data.Services
{
    public class FilmScreeningService : IFilmScreeningService
    {
        private const int InitialSeatsCount = 20;

        private IRepository<FilmScreening> screenings;
        private IFilmScreening filmScreeningToCreate;
        private ISeat seat;

        public FilmScreeningService(IRepository<FilmScreening> screenings, ISeat seat, IFilmScreening filmScreening)
        {
            this.screenings = screenings;
            this.seat = seat;
            this.filmScreeningToCreate = filmScreening;
        }

        public void Create(string date, string movieId)
        {
            this.filmScreeningToCreate.Start = DateTime.Parse(date);
            this.filmScreeningToCreate.TargetMovieId = int.Parse(movieId);
            this.filmScreeningToCreate.Seats = new List<Seat>(20);

            for (int i = 0; i < InitialSeatsCount; i++)
            {
                filmScreeningToCreate.Seats.Add((new Seat() { IsFree = true }));
            }

            this.screenings.Add((FilmScreening)filmScreeningToCreate);
            this.screenings.SaveChanges();
        }

        public void DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public int GetAvailableCount(int id)
        {
            return this.screenings.GetById(id).Seats.Where(x => x.IsFree == true).Count();
        }

        public IQueryable<FilmScreening> GetAll()
        {
            return this.screenings.All();
        }

        public IFilmScreening GetById(int id)
        {
            return this.screenings.GetById(id);
        }

        public void UpdateById(int id, FilmScreening updatedFilmScreening)
        {
            var targetScreening = this.screenings.GetById(id);
            targetScreening = updatedFilmScreening;
            this.screenings.Update(targetScreening);
            this.screenings.SaveChanges();
        }
    }
}
