using Cinema.Data.Models;
using Cinema.Data.Repositories;
using Moq;
using NUnit.Framework;
using System;

namespace Cinema.Tests.Data.Services.Tests.FilmScreeningService
{
    [TestFixture]
    public class GetMovieTitleByScreeningIdShould
    {
        [Test]
        public void ThrowWhenParameterIdHasNullValue()
        {
            var mockedScreeningRepo = new Mock<IRepository<FilmScreening>>();
            var mockedFilmSCreening = new Mock<FilmScreening>();
            string nullId = null;

            var actualFilmSCreeningService =
                new Cinema.Data.Services.FilmScreeningService(mockedScreeningRepo.Object, mockedFilmSCreening.Object);

            Assert.That(() => actualFilmSCreeningService.GetMovieTitleByScreeningId(nullId),
                Throws.InstanceOf<ArgumentNullException>());
        }

        [TestCase("12jh")]
        [TestCase("abc")]
        public void ThrowArgumentExceptionWhenArgumentIdIsNotNumber(string incorrectId)
        {
            var mockedScreeningRepo = new Mock<IRepository<FilmScreening>>();
            var mockedFilmSCreening = new Mock<FilmScreening>();

            var actualFilmSCreeningService =
                new Cinema.Data.Services.FilmScreeningService(mockedScreeningRepo.Object, mockedFilmSCreening.Object);

            Assert.That(() => actualFilmSCreeningService.GetMovieTitleByScreeningId(incorrectId),
                Throws.InstanceOf<ArgumentException>());
        }

        [TestCase("2")]
        [TestCase("4")]
        public void CallFilmScreeningRepoWithSameParameterId(string validId)
        {
            var mockedScreeningRepo = new Mock<IRepository<FilmScreening>>();
            var mockedFilmSCreening = new Mock<FilmScreening>();
            var fakeFilmScreening = new FilmScreening() { Id = int.Parse(validId), TargetMovie=new Movie() { Name = "Batman" } };

            mockedScreeningRepo.Setup(x => x.GetById(int.Parse(validId))).Returns(fakeFilmScreening);

            var actualScreeningService =
                new Cinema.Data.Services.FilmScreeningService(mockedScreeningRepo.Object, mockedFilmSCreening.Object);

            actualScreeningService.GetMovieTitleByScreeningId(validId);

            mockedScreeningRepo.Verify(service => service.GetById(int.Parse(validId)), Times.Once);
        }

        [TestCase("1")]
        [TestCase("5")]
        public void ReturnCorrectMovieName(string validId)
        {
            var mockedScreeningRepo = new Mock<IRepository<FilmScreening>>();
            var mockedFilmSCreening = new Mock<FilmScreening>();
            string expectedMovieName = "Batman";

            var fakeFilmScreening = new FilmScreening() { Id = int.Parse(validId), TargetMovie = new Movie() { Name = "Batman" } };

            mockedScreeningRepo.Setup(x => x.GetById(int.Parse(validId))).Returns(fakeFilmScreening);

            var actualScreeningService =
                new Cinema.Data.Services.FilmScreeningService(mockedScreeningRepo.Object, mockedFilmSCreening.Object);

            string actualMovieName = actualScreeningService.GetMovieTitleByScreeningId(validId);

            Assert.AreEqual(expectedMovieName, actualMovieName);
        }
    }
}
