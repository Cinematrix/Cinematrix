using Cinema.Data.Models;
using Cinema.Data.Models.Contracts;
using Cinema.Data.Repositories;
using Moq;
using NUnit.Framework;
using System;

namespace Cinema.Tests.Data.Services.Tests.FilmScreeningService
{
    [TestFixture]
    public class GetByIdShould
    {
        [TestCase("2")]
        [TestCase("4")]
        public void CallFilmScreeningRepoWithSameParameterId(string validId)
        {
            var mockedScreeningRepo = new Mock<IRepository<FilmScreening>>();
            var mockedFilmSCreening = new Mock<FilmScreening>();

            var actualScreeningService =
                new Cinema.Data.Services.FilmScreeningService(mockedScreeningRepo.Object, mockedFilmSCreening.Object);

            actualScreeningService.GetById(validId);

            mockedScreeningRepo.Verify(service => service.GetById(int.Parse(validId)), Times.Once);
        }

        [TestCase("12jh")]
        [TestCase("abc")]
        public void ThrowArgumentExceptionWhenArgumentIdIsNotNumber(string incorrectId)
        {
            var mockedScreeningRepo = new Mock<IRepository<FilmScreening>>();
            var mockedFilmSCreening = new Mock<FilmScreening>();

            var actualFilmSCreeningService =
                new Cinema.Data.Services.FilmScreeningService(mockedScreeningRepo.Object, mockedFilmSCreening.Object);

            Assert.That(() => actualFilmSCreeningService.GetById(incorrectId),
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

            Assert.That(() => actualFilmSCreeningService.GetById(nullId),
                Throws.InstanceOf<ArgumentNullException>());
        }

        [Test]
        public void ReturnIFilmScreeningObjectFromScreeningRepo()
        {
            var mockedScreeningRepo = new Mock<IRepository<FilmScreening>>();
            var mockedFilmSCreening = new Mock<FilmScreening>();
            string id = "3";

            mockedScreeningRepo.Setup(x => x.GetById(int.Parse(id))).Returns(mockedFilmSCreening.Object);

            var actualFilmSCreeningService =
                new Cinema.Data.Services.FilmScreeningService(mockedScreeningRepo.Object, mockedFilmSCreening.Object);

            var result = actualFilmSCreeningService.GetById(id);

            Assert.That(result, Is.Not.Null.And.InstanceOf<IFilmScreening>());
        }
    }
}
