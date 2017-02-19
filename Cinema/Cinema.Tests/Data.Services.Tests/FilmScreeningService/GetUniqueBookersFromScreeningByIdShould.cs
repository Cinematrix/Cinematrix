using Cinema.Data.Models;
using Cinema.Data.Repositories;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Cinema.Tests.Data.Services.Tests.FilmScreeningService
{
    [TestFixture]
    public class GetUniqueBookersFromScreeningByIdShould
    {
        [TestCase("2")]
        [TestCase("4")]
        public void CallFilmScreeningRepoWithSameParameterId(string validId)
        {
            var mockedScreeningRepo = new Mock<IRepository<FilmScreening>>();
            var mockedFilmSCreening = new Mock<FilmScreening>();
            var mockedSeatsList = new List<Seat>();
            var targetUser = new User() { UserName = "John" };
            var freeSeat = new Seat() { IsFree = true };
            var freeSeat2 = new Seat() { IsFree = true };
            var takenSeat = new Seat() { IsFree = false };
            mockedSeatsList.Add(freeSeat);
            mockedSeatsList.Add(freeSeat2);
            mockedSeatsList.Add(takenSeat);
            var fakeFilmScreening = new FilmScreening()
            {
                Id = int.Parse(validId),
                TargetMovie = new Movie() { Name = "Batman" },
                Seats = mockedSeatsList
            };

            mockedScreeningRepo.Setup(x => x.GetById(int.Parse(validId))).Returns(fakeFilmScreening);

            var actualScreeningService =
                new Cinema.Data.Services.FilmScreeningService(mockedScreeningRepo.Object, mockedFilmSCreening.Object);

            actualScreeningService.GetUniqueBookersFromScreeningById(validId);

            mockedScreeningRepo.Verify(service => service.GetById(int.Parse(validId)), Times.Once);
        }

        [Test]
        public void ReturnCollectionWithUniqueUsersThatHaveBookedSeatsInTargetFilmScreening()
        {
            var mockedScreeningRepo = new Mock<IRepository<FilmScreening>>();
            var mockedFilmSCreening = new Mock<FilmScreening>();
            var mockedSeatsList = new List<Seat>();
            var targetUser = new User() { UserName = "John" };
            var targetUser2 = new User() { UserName = "Adam" };
            var freeSeat = new Seat() { IsFree = false, User = targetUser };
            var freeSeat2 = new Seat() { IsFree = false, User = targetUser };
            var takenSeat = new Seat() { IsFree = false, User = targetUser2 };
            mockedSeatsList.Add(freeSeat);
            mockedSeatsList.Add(freeSeat2);
            mockedSeatsList.Add(takenSeat);
            string validId = "3";

            // John and Adam even John has booked 2 seats
            int expectedUniqueBookersCount = 2;

            var fakeFilmScreening = new FilmScreening()
            {
                Id = int.Parse(validId),
                TargetMovie = new Movie() { Name = "Batman" },
                Seats = mockedSeatsList
            };

            mockedScreeningRepo.Setup(x => x.GetById(int.Parse(validId))).Returns(fakeFilmScreening);

            var actualScreeningService =
                new Cinema.Data.Services.FilmScreeningService(mockedScreeningRepo.Object, mockedFilmSCreening.Object);

            var result = actualScreeningService.GetUniqueBookersFromScreeningById(validId);

            Assert.That(result.Contains(targetUser));
            Assert.That(result.Contains(targetUser2));
            Assert.That(result.Count() == expectedUniqueBookersCount);
        }
    }
}
