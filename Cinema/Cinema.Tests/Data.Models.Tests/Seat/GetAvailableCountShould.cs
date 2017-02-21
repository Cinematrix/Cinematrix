using Cinema.Data.Models;
using NUnit.Framework;
using System.Collections.Generic;
using Moq;

namespace Cinema.Tests.Data.Models.Tests.Seat
{
    [TestFixture]
    public class GetAvailableCountShould
    {
        [Test]
        public void ReturnExpectedCount()
        {
            var actualFilmScreening = new FilmScreening();
            var mockedSeatsList = new List<Cinema.Data.Models.Seat>();
            var mockedSeat1 = new Cinema.Data.Models.Seat();
            var mockedSeat2 = new Cinema.Data.Models.Seat();
            var mockedSeat3 = new Cinema.Data.Models.Seat();
            var mockedUser = new Mock<User>();

            mockedSeat1.User = mockedUser.Object;
            mockedSeat1.IsFree=false;

            mockedSeat2.User = mockedUser.Object;
            mockedSeat2.IsFree = false;

            mockedSeat3.User = mockedUser.Object;
            mockedSeat3.IsFree = true;

            mockedSeatsList.Add(mockedSeat1);
            mockedSeatsList.Add(mockedSeat2);
            mockedSeatsList.Add(mockedSeat3);

            actualFilmScreening.Seats = mockedSeatsList;

            // mockedUser booked Seat1 and Seat2 so available seat is 1 out of 3
            int expectedAvailableSeatsCount = 1;

            var actualAvailableSeatsCount = actualFilmScreening.AvailableSeatsCount;

            Assert.AreEqual(expectedAvailableSeatsCount, actualAvailableSeatsCount);
        }
    }
}
