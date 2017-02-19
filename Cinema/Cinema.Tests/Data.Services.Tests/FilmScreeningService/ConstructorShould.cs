using Cinema.Data.Models;
using Cinema.Data.Repositories;
using Moq;
using NUnit.Framework;
using System;

namespace Cinema.Tests.Data.Services.Tests.FilmScreeningService
{
    [TestFixture]
    public class ConstructorShould
    {
        [Test]
        public void InitializeNewInstanceOfFilmScreeningServiceWhenPropperDependanciesArePassed()
        {
            var mockedScreeningRepo = new Mock<IRepository<FilmScreening>>();
            var mockedFilmSCreening = new Mock<FilmScreening>();

            var actualFilmSCreeningService =
                new Cinema.Data.Services.FilmScreeningService(mockedScreeningRepo.Object, mockedFilmSCreening.Object);

            Assert.IsInstanceOf(typeof(Cinema.Data.Services.FilmScreeningService), actualFilmSCreeningService);
        }

        [Test]
        public void ThrowWhenPassedRepositoryHasNullValue()
        {
            IRepository<FilmScreening> nullScreeningRepo = null;
            var mockedFilmSCreening = new Mock<FilmScreening>();

            Assert.That(() =>
                 new Cinema.Data.Services.FilmScreeningService(nullScreeningRepo, mockedFilmSCreening.Object),
                 Throws.InstanceOf<ArgumentNullException>());
        }

        [Test]
        public void ThrowWhenPassedFilmScreeningInstanceHasNullValue()
        {
            var mockedScreeningRepo = new Mock<IRepository<FilmScreening>>();
            FilmScreening nullFilmSCreening = null;

            Assert.That(() =>
                 new Cinema.Data.Services.FilmScreeningService(mockedScreeningRepo.Object, nullFilmSCreening),
                 Throws.InstanceOf<ArgumentNullException>());
        }
    }
}
