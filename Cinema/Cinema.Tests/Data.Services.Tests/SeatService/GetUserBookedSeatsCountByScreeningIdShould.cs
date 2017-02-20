using Cinema.Data.Models;
using Cinema.Data.Repositories;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace Cinema.Tests.Data.Services.Tests.SeatService
{
    [TestFixture]
    public class GetUserBookedSeatsCountByScreeningIdShould
    {
        [Test]
        public void CallFilmScreeningRepoGetByIdWithSameId()
        {
            var mockedFilmScreeningRepo = new Mock<IRepository<FilmScreening>>();
            var mockedScreening = new Mock<FilmScreening>();
            var mockedUser = new Mock<User>();
            var mockedSeatsList = new List<Seat>();
            var mockedSeat = new Mock<Seat>();

            string screeningId = "3";
            string userName = "John";

            mockedSeat.Setup(x => x.User).Returns(mockedUser.Object);
            mockedSeatsList.Add(mockedSeat.Object);
            mockedScreening.Setup(x => x.Seats).Returns(mockedSeatsList);
            mockedFilmScreeningRepo.Setup(x => x.GetById(int.Parse(screeningId))).Returns(mockedScreening.Object);

            var actualSeatService =
                new Cinema.Data.Services.SeatService(mockedFilmScreeningRepo.Object);

            actualSeatService.GetUserBookedSeatsCountByScreeningId(userName, screeningId);

            mockedFilmScreeningRepo.Verify(
                repo => repo.GetById(int.Parse(screeningId)), Times.Once);
        }

        [Test]
        public void ReturnCorrectSeatsCountMatchingPassedUserNameAndFilmScreeningId()
        {
            var mockedFilmScreeningRepo = new Mock<IRepository<FilmScreening>>();
            var mockedScreening = new Mock<FilmScreening>();
            var mockedUser = new Mock<User>();
            var mockedUser2 = new Mock<User>();
            var mockedSeatsList = new List<Seat>();
            var mockedSeat = new Mock<Seat>();
            var mockedSeat2 = new Mock<Seat>();
            var mockedSeat3 = new Mock<Seat>();

            string screeningId = "3";
            string userName = "John";
            string userName2 = "Adam";

            //mockedUser(John) has two seats, mockedUser2(Adam) has one seat
            int expectedSeatsCount = 2;

            mockedUser.Setup(x => x.UserName).Returns(userName);
            mockedUser2.Setup(x => x.UserName).Returns(userName2);
            mockedSeat.Setup(x => x.User).Returns(mockedUser.Object);
            mockedSeat2.Setup(x => x.User).Returns(mockedUser.Object);
            mockedSeat3.Setup(x => x.User).Returns(mockedUser2.Object);
            mockedSeatsList.Add(mockedSeat.Object);
            mockedSeatsList.Add(mockedSeat2.Object);
            mockedSeatsList.Add(mockedSeat3.Object);
            mockedScreening.Setup(x => x.Seats).Returns(mockedSeatsList);
            mockedFilmScreeningRepo.Setup(x => x.GetById(int.Parse(screeningId))).Returns(mockedScreening.Object);

            var actualSeatService =
                new Cinema.Data.Services.SeatService(mockedFilmScreeningRepo.Object);

            var actualSeatsCount =
                actualSeatService.GetUserBookedSeatsCountByScreeningId(userName, screeningId);

            Assert.AreEqual(expectedSeatsCount, actualSeatsCount);
        }

        [Test]
        public void ReturnZeroMatchesIfPassedUserNameDoesNotHaveAnyBookingsForThisScreening()
        {
            var mockedFilmScreeningRepo = new Mock<IRepository<FilmScreening>>();
            var mockedScreening = new Mock<FilmScreening>();
            var mockedUser = new Mock<User>();
            var mockedUser2 = new Mock<User>();
            var mockedSeatsList = new List<Seat>();
            var mockedSeat = new Mock<Seat>();
            var mockedSeat2 = new Mock<Seat>();
            var mockedSeat3 = new Mock<Seat>();

            string screeningId = "3";
            string userName = "John";
            string userName2 = "Adam";
            string passiveUserName = "George";

            // passiveUserName(George) doe not have any bookings
            int expectedSeatsCount = 0;

            mockedUser.Setup(x => x.UserName).Returns(userName);
            mockedUser2.Setup(x => x.UserName).Returns(userName2);
            mockedSeat.Setup(x => x.User).Returns(mockedUser.Object);
            mockedSeat2.Setup(x => x.User).Returns(mockedUser.Object);
            mockedSeat3.Setup(x => x.User).Returns(mockedUser2.Object);
            mockedSeatsList.Add(mockedSeat.Object);
            mockedSeatsList.Add(mockedSeat2.Object);
            mockedSeatsList.Add(mockedSeat3.Object);
            mockedScreening.Setup(x => x.Seats).Returns(mockedSeatsList);
            mockedFilmScreeningRepo.Setup(x => x.GetById(int.Parse(screeningId))).Returns(mockedScreening.Object);

            var actualSeatService =
                new Cinema.Data.Services.SeatService(mockedFilmScreeningRepo.Object);

            var actualSeatsCount =
                actualSeatService.GetUserBookedSeatsCountByScreeningId(passiveUserName, screeningId);

            Assert.AreEqual(expectedSeatsCount, actualSeatsCount);
        }
    }
}
