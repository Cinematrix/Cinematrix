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
    class GetScreeningsByMovieTitleShould
    {
        [Test]
        public void CallFilmScreeningRepoAllMethod()
        {
            var mockedScreeningRepo = new Mock<IRepository<FilmScreening>>();
            var mockedFilmSCreening = new Mock<FilmScreening>();
            string title = "Batman";

            var actualFilmSCreeningService =
                new Cinema.Data.Services.FilmScreeningService(mockedScreeningRepo.Object, mockedFilmSCreening.Object);

            actualFilmSCreeningService.GetScreeningsByMovieTitle(title);

            mockedScreeningRepo.Verify(service => service.All(), Times.Once);
        }

        [Test]
        public void ReturnAllFilmScreeningsWhenParameterTitleHasNullOrEmptyValue()
        {
            var mockedScreeningRepo = new Mock<IRepository<FilmScreening>>();
            var mockedFilmSCreening = new Mock<FilmScreening>();
            var mockedFilmScreeningsList = new List<FilmScreening>(2);

            mockedFilmScreeningsList.Add(new FilmScreening()
            {
                Start = DateTime.Parse("3/08/2027"),
                TargetMovie = new Movie { Name = "Batman" }
            });

            mockedFilmScreeningsList.Add(new FilmScreening()
            {
                Start = DateTime.Parse("3/12/2027"),
                TargetMovie = new Movie { Name = "Godzila" }
            });

            string nullTitle = null;
            int expectedReturnedCount = 2;

            mockedScreeningRepo.Setup(x => x.All()).Returns(mockedFilmScreeningsList.AsQueryable());

            var actualFilmSCreeningService =
                new Cinema.Data.Services.FilmScreeningService(mockedScreeningRepo.Object, mockedFilmSCreening.Object);

            var actualResultCount = actualFilmSCreeningService.GetScreeningsByMovieTitle(nullTitle).Count();

            Assert.AreEqual(expectedReturnedCount, actualResultCount);
        }

        [Test]
        public void ReturnMatchedFilmScreeningsWhenParameterTitleHasCorrectValueAndSuchMovieTitleIsFound()
        {
            var mockedScreeningRepo = new Mock<IRepository<FilmScreening>>();
            var mockedFilmSCreening = new Mock<FilmScreening>();
            var mockedFilmScreeningsList = new List<FilmScreening>(2);

            mockedFilmScreeningsList.Add(new FilmScreening()
            {
                Start = DateTime.Parse("3/08/2027"),
                TargetMovie = new Movie { Name = "Batman" }
            });

            mockedFilmScreeningsList.Add(new FilmScreening()
            {
                Start = DateTime.Parse("3/12/2027"),
                TargetMovie = new Movie { Name = "Godzila" }
            });

            string title = "Godzila";
            int expectedReturnedCount = 1;

            mockedScreeningRepo.Setup(x => x.All()).Returns(mockedFilmScreeningsList.AsQueryable());

            var actualFilmSCreeningService =
                new Cinema.Data.Services.FilmScreeningService(mockedScreeningRepo.Object, mockedFilmSCreening.Object);

            var actualResultCount = actualFilmSCreeningService.GetScreeningsByMovieTitle(title).Count();
            var actualResultFilmScreening = actualFilmSCreeningService.GetScreeningsByMovieTitle(title);

            Assert.AreEqual(expectedReturnedCount, actualResultCount);
            Assert.IsTrue(actualResultFilmScreening.First().TargetMovie.Name.Contains(title));
        }
    }
}
