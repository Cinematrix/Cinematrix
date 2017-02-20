using Cinema.Data.Models;
using Cinema.Data.Repositories;
using Cinema.Data.Services.Contracts;
using Moq;
using NUnit.Framework;
using System;

namespace Cinema.Tests.Data.Services.Tests.SeatService
{
    [TestFixture]
    public class ConstructorShould
    {
        [Test]
        public void InitiateNewSeatServiceInstanceWhenProperDependncyIsPassed()
        {
            var mockedFilmScreeningRepo = new Mock<IRepository<FilmScreening>>();

            var actualSeatService =
                new Cinema.Data.Services.SeatService(mockedFilmScreeningRepo.Object);

            Assert.IsInstanceOf(typeof(ISeatService), actualSeatService);
            Assert.IsInstanceOf(typeof(Cinema.Data.Services.SeatService), actualSeatService);
        }

        [Test]
        public void ThrowWhenParameterFilmScreeningRepositoryHasNullValue()
        {
            IRepository<FilmScreening> nullFilmScreeningRepo = null;

            Assert.That(() =>
                new Cinema.Data.Services.SeatService(nullFilmScreeningRepo),
                Throws.InstanceOf<ArgumentNullException>());
        }
    }
}
