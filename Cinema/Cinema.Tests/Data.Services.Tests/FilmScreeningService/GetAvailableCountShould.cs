using Cinema.Data.Models;
using Cinema.Data.Repositories;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Cinema.Tests.Data.Services.Tests.FilmScreeningService
{
    [TestFixture]
    public class GetAvailableCountShould
    {
        [TestCase("12jh")]
        [TestCase("abc")]
        public void ThrowArgumentExceptionWhenArgumentIdIsNotNumber(string incorrectId)
        {
            var mockedScreeningRepo = new Mock<IRepository<FilmScreening>>();
            var mockedFilmSCreening = new Mock<FilmScreening>();

            var actualFilmSCreeningService =
                new Cinema.Data.Services.FilmScreeningService(mockedScreeningRepo.Object, mockedFilmSCreening.Object);

            Assert.That(() => actualFilmSCreeningService.GetAvailableCount(incorrectId),
                Throws.InstanceOf<ArgumentException>());
        }

        [Test]
        public void ThrowArgumentNullExceptionWhenArgumentIdIsNotNumber()
        {
            var mockedScreeningRepo = new Mock<IRepository<FilmScreening>>();
            var mockedFilmSCreening = new Mock<FilmScreening>();
            string nullId = null;

            var actualFilmSCreeningService =
                new Cinema.Data.Services.FilmScreeningService(mockedScreeningRepo.Object, mockedFilmSCreening.Object);

            Assert.That(() => actualFilmSCreeningService.GetAvailableCount(nullId),
                Throws.InstanceOf<ArgumentNullException>());
        }

        [TestCase("2")]
        [TestCase("3")]
        public void CallFilmScreeningRepoGetByIdMethodWithSameId(string id)
        {
            var mockedScreeningRepo = new Mock<IRepository<FilmScreening>>();
            var mockedFilmSCreening = new Mock<FilmScreening>();

            var actualFilmSCreeningService =
                new Cinema.Data.Services.FilmScreeningService(mockedScreeningRepo.Object, mockedFilmSCreening.Object);

            actualFilmSCreeningService.GetById(id);

            mockedScreeningRepo.Verify(service => service.GetById(int.Parse(id)), Times.Once);
        }

        [Test]
        public void ReturnExpectedCount()
        {
            var mockedScreeningRepo = new Mock<IRepository<FilmScreening>>();
            var mockedFilmSCreening = new Mock<FilmScreening>();
            var mockedSeatsList = new List<Seat>(3);
            string id = "1";

            var freeSeat = new Seat() { IsFree = true };
            var freeSeat2 = new Seat() { IsFree = true };
            var takenSeat = new Seat() { IsFree = false };
            mockedSeatsList.Add(freeSeat);
            mockedSeatsList.Add(freeSeat2);
            mockedSeatsList.Add(takenSeat);

            //because two freeSeats(IsFree = true) are added to the SeatsList
            int expectedAvailableCount = 2; 

            mockedFilmSCreening.Setup(x => x.Seats).Returns(mockedSeatsList);

            mockedScreeningRepo.Setup(x => x.GetById(int.Parse(id))).Returns(mockedFilmSCreening.Object);



            var actualFilmSCreeningService =
                new Cinema.Data.Services.FilmScreeningService(mockedScreeningRepo.Object, mockedFilmSCreening.Object);

            int actualAvailableCount = actualFilmSCreeningService.GetAvailableCount(id);

            Assert.AreEqual(expectedAvailableCount, actualAvailableCount);
        }
    }
}
