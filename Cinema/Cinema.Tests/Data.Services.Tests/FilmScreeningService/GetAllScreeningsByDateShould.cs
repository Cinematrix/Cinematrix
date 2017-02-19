using Cinema.Data.Models;
using Cinema.Data.Repositories;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cinema.Tests.Data.Services.Tests.FilmScreeningService
{
    [TestFixture]
    class GetAllScreeningsByDateShould
    {
        [Test]
        public void CallFilmScreeningRepoAllMethod()
        {
            var mockedScreeningRepo = new Mock<IRepository<FilmScreening>>();
            var mockedFilmSCreening = new Mock<FilmScreening>();
            string date = "3/08/2017";

            var actualFilmSCreeningService =
                new Cinema.Data.Services.FilmScreeningService(mockedScreeningRepo.Object, mockedFilmSCreening.Object);

            actualFilmSCreeningService.GetAllScreeningsByDate(date);

            mockedScreeningRepo.Verify(service => service.All(), Times.Once);
        }

        [Test]
        public void ReturnAllFilmScreeningsWhenParameterDateHasNullOrEmptyValue()
        {
            var mockedScreeningRepo = new Mock<IRepository<FilmScreening>>();
            var mockedFilmSCreening = new Mock<FilmScreening>();
            var mockedSeatsList = new List<Seat>(3);
            var mockedFilmScreeningsList = new List<FilmScreening>(2);

            var freeSeat = new Seat() { IsFree = true };
            var freeSeat2 = new Seat() { IsFree = true };
            var takenSeat = new Seat() { IsFree = false };
            mockedSeatsList.Add(freeSeat);
            mockedSeatsList.Add(freeSeat2);
            mockedSeatsList.Add(takenSeat);

            mockedFilmScreeningsList.Add(new FilmScreening() {
                Start = DateTime.Parse("3/08/2017"),
                Seats= mockedSeatsList
            });

            mockedFilmScreeningsList.Add(new FilmScreening()
            {
                Start = DateTime.Parse("3/12/2017"),
                Seats = mockedSeatsList
            });

            string nullDate = null;
            int expectedReturnedCount = 2;

            mockedScreeningRepo.Setup(x => x.All()).Returns(mockedFilmScreeningsList.AsQueryable());

            var actualFilmSCreeningService =
                new Cinema.Data.Services.FilmScreeningService(mockedScreeningRepo.Object, mockedFilmSCreening.Object);

            var actualResultCount = actualFilmSCreeningService.GetAllScreeningsByDate(nullDate).Count();

            Assert.AreEqual(expectedReturnedCount, actualResultCount);
        }

        [Test]
        public void ReturnMatchedFilmScreeningsWhenParameterDateHasCorrectValueAndSuchScreeningExists()
        {
            var mockedScreeningRepo = new Mock<IRepository<FilmScreening>>();
            var mockedFilmSCreening = new Mock<FilmScreening>();
            var mockedSeatsList = new List<Seat>(3);
            var mockedFilmScreeningsList = new List<FilmScreening>(2);

            var freeSeat = new Seat() { IsFree = true };
            var freeSeat2 = new Seat() { IsFree = true };
            var takenSeat = new Seat() { IsFree = false };
            mockedSeatsList.Add(freeSeat);
            mockedSeatsList.Add(freeSeat2);
            mockedSeatsList.Add(takenSeat);

            mockedFilmScreeningsList.Add(new FilmScreening()
            {
                Start = DateTime.Parse("3/08/2017"),
                Seats = mockedSeatsList
            });

            mockedFilmScreeningsList.Add(new FilmScreening()
            {
                Start = DateTime.Parse("3/12/2017"),
                Seats = mockedSeatsList
            });

            string existingDate = "3/12/2017";
            int expectedReturnedCount = 1;

            mockedScreeningRepo.Setup(x => x.All()).Returns(mockedFilmScreeningsList.AsQueryable());

            var actualFilmSCreeningService =
                new Cinema.Data.Services.FilmScreeningService(mockedScreeningRepo.Object, mockedFilmSCreening.Object);

            var actualResultCount =
                actualFilmSCreeningService.GetAllScreeningsByDate(existingDate).Count();
            var actualReturnedFilmScreening = 
                actualFilmSCreeningService.GetAllScreeningsByDate(existingDate).First();

            Assert.AreEqual(expectedReturnedCount, actualResultCount);
            Assert.AreEqual(mockedFilmScreeningsList[1], actualReturnedFilmScreening);
        }
    }
}
