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
        private IRepository<FilmScreening> screenings;

        public FilmScreeningService(IRepository<FilmScreening> screenings)
        {
            this.screenings = screenings;
        }

        public void Create(FilmScreening filmScreeningToCreate)
        {
            this.screenings.Add(filmScreeningToCreate);
            this.screenings.SaveChanges();
        }

        public void DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<FilmScreening> GetAll()
        {
            throw new NotImplementedException();
        }

        public IFilmScreening GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateById(int id, FilmScreening updatedFilmScreening)
        {
            throw new NotImplementedException();
        }
    }
}
