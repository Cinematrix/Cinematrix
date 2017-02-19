using Cinema.Data.Models;
using Cinema.Data.Repositories;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Cinema.Tests.Data.Services.Tests.FilmScreeningService
{
    [TestFixture]
    public class CreateShould
    {
        [Test]
        public void CallFilmScreeningRepoAddMethodWithPassedParameters()
        {
            var mockedScreeningRepo = new Mock<IRepository<FilmScreening>>();
            var fakeFilmScreening = new FilmScreening();

            string date = "3/08/2017";
            string movieId = "1";
            string price = "12";

            fakeFilmScreening.Start = DateTime.Parse(date);
            fakeFilmScreening.TargetMovieId = int.Parse(movieId);
            fakeFilmScreening.Price = int.Parse(price);
            fakeFilmScreening.Seats = new List<Seat>(20);

            for (int i = 0; i < 20; i++)
            {
                var seat = new Seat() { IsFree = true };
                fakeFilmScreening.Seats.Add(seat);
            }


            var actualFilmSCreeningService =
                new Cinema.Data.Services.FilmScreeningService(mockedScreeningRepo.Object, fakeFilmScreening);

            actualFilmSCreeningService.Create(date, movieId, price);

            mockedScreeningRepo.Verify(
                service => service.Add(fakeFilmScreening), Times.Once);
        }

        [Test]
        public void CallFilmScreeningRepositorySaveChangesMethod()
        {
            var mockedScreeningRepo = new Mock<IRepository<FilmScreening>>();
            var fakeFilmScreening = new FilmScreening();

            string date = "3/08/2017";
            string movieId = "1";
            string price = "12";

            fakeFilmScreening.Start = DateTime.Parse(date);
            fakeFilmScreening.TargetMovieId = int.Parse(movieId);
            fakeFilmScreening.Price = int.Parse(price);
            fakeFilmScreening.Seats = new List<Seat>(20);

            for (int i = 0; i < 20; i++)
            {
                var seat = new Seat() { IsFree = true };
                fakeFilmScreening.Seats.Add(seat);
            }


            var actualFilmSCreeningService =
                new Cinema.Data.Services.FilmScreeningService(mockedScreeningRepo.Object, fakeFilmScreening);

            actualFilmSCreeningService.Create(date, movieId, price);

            mockedScreeningRepo.Verify(
                service => service.SaveChanges(), Times.Once);
        }
    }
}
