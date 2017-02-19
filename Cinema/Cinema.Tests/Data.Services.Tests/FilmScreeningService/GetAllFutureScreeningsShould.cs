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
    public class GetAllFutureScreeningsShould
    {
        [Test]
        public void ReturnOnlyFilmSCreeningsWithFutureStartDateTime()
        {
            var mockedScreeningRepo = new Mock<IRepository<FilmScreening>>();
            var mockedFilmSCreening = new Mock<FilmScreening>();
            var mockedFilmScreeningsList = new List<FilmScreening>(2);

            //FilmScreening with passed Start dateTime
            mockedFilmScreeningsList.Add(new FilmScreening()
            {
                Start = DateTime.Parse("2017-01-26 01:40:00.000")
            });

            //FilmScreening with future Start dateTime
            mockedFilmScreeningsList.Add(new FilmScreening()
            {
                Start = DateTime.Parse("2025-02-26 01:40:00.000")
            });
            
            int expectedReturnedCount = 1;

            mockedScreeningRepo.Setup(x => x.All()).Returns(mockedFilmScreeningsList.AsQueryable());

            var actualFilmSCreeningService =
                new Cinema.Data.Services.FilmScreeningService(mockedScreeningRepo.Object, mockedFilmSCreening.Object);

            var actualResultCount =
                actualFilmSCreeningService.GetAllFutureScreenings().Count();
            var actualReturnedFilmScreening =
                actualFilmSCreeningService.GetAllFutureScreenings().First();

            Assert.AreEqual(expectedReturnedCount, actualResultCount);
            Assert.AreEqual(mockedFilmScreeningsList[1], actualReturnedFilmScreening);
        }
    }
}
