using Cinema.Data.Models;
using Cinema.Data.Repositories;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace Cinema.Tests.Data.Services.Tests.SeatService
{
    [TestFixture]
    public class GetBookedSeatsAsStringShould
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

            actualSeatService.GetBookedSeatsAsString(userName, screeningId);

            mockedFilmScreeningRepo.Verify(
                repo => repo.GetById(int.Parse(screeningId)), Times.Once);
        }

        [Test]
        public void ReturnStringWithSeatsNumbersBookedFromTargetedUserInTargetedFilmScreening()
        {
            var mockedFilmScreeningRepo = new Mock<IRepository<FilmScreening>>();
            var mockedScreening = new Mock<FilmScreening>();
            var mockedUser = new Mock<User>();
            var mockedUser2 = new Mock<User>();
            var mockedSeatsList = new List<Seat>();
            var mockedSeat1 = new Mock<Seat>();
            var mockedSeat2 = new Mock<Seat>();
            var mockedSeat3 = new Mock<Seat>();

            string screeningId = "3";
            string userName = "John";
            string userName2 = "Adam";

            // targeted UserName(John) has booked Seat1 and Seat2, UserName(Adam) has booked Seat3
            string expectedOutput = "Seat1, Seat2";

            mockedUser.Setup(x => x.UserName).Returns(userName);
            mockedUser2.Setup(x => x.UserName).Returns(userName2);
            mockedSeat1.Setup(x => x.User).Returns(mockedUser.Object);
            mockedSeat2.Setup(x => x.User).Returns(mockedUser.Object);
            mockedSeat3.Setup(x => x.User).Returns(mockedUser2.Object);
            mockedSeatsList.Add(mockedSeat1.Object);
            mockedSeatsList.Add(mockedSeat2.Object);
            mockedSeatsList.Add(mockedSeat3.Object);
            mockedScreening.Setup(x => x.Seats).Returns(mockedSeatsList);
            mockedFilmScreeningRepo.Setup(x => x.GetById(int.Parse(screeningId))).Returns(mockedScreening.Object);

            var actualSeatService =
                new Cinema.Data.Services.SeatService(mockedFilmScreeningRepo.Object);

            var actualOutput =
                actualSeatService.GetBookedSeatsAsString(userName, screeningId);

            Assert.AreEqual(expectedOutput, actualOutput);
        }
    }
}
