using Cinema.Data.Models;
using Cinema.Data.Repositories;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Tests.Data.Services.Tests.SeatService
{
    [TestFixture]
    public class GetPriceShould
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

            actualSeatService.GetPrice(userName, screeningId);

            mockedFilmScreeningRepo.Verify(
                repo => repo.GetById(int.Parse(screeningId)), Times.Once);
        }

        [Test]
        public void ReturnCorrectPriceForPassedParameters()
        {
            var mockedFilmScreeningRepo = new Mock<IRepository<FilmScreening>>();
            var mockedScreening = new FilmScreening();
            var mockedUser = new Mock<User>();
            var mockedUser2 = new Mock<User>();
            var mockedSeatsList = new List<Seat>();
            var mockedSeat1 = new Mock<Seat>();
            var mockedSeat2 = new Mock<Seat>();
            var mockedSeat3 = new Mock<Seat>();

            string screeningId = "3";
            string userName = "John";
            string userName2 = "Adam";
            decimal singlePrice = (decimal)8.50;

            // targeted UserName(John) has booked two seats, output should be Total Price: $40.00
            string expectedOutput = "Total Price: $17.00";

            mockedUser.Setup(x => x.UserName).Returns(userName);
            mockedUser2.Setup(x => x.UserName).Returns(userName2);
            mockedSeat1.Setup(x => x.User).Returns(mockedUser.Object);
            mockedSeatsList.Add(mockedSeat1.Object);
            mockedSeat2.Setup(x => x.User).Returns(mockedUser.Object);
            mockedSeatsList.Add(mockedSeat2.Object);
            mockedSeat3.Setup(x => x.User).Returns(mockedUser2.Object);
            mockedSeatsList.Add(mockedSeat3.Object);
            mockedScreening.Seats = mockedSeatsList;
            mockedScreening.Price = singlePrice;
            mockedFilmScreeningRepo.Setup(x => x.GetById(int.Parse(screeningId))).Returns(mockedScreening);

            var actualSeatService =
                new Cinema.Data.Services.SeatService(mockedFilmScreeningRepo.Object);

            var actualOutput = actualSeatService.GetPrice(userName, screeningId);

            Assert.AreEqual(expectedOutput, actualOutput);
        }
    }
}
