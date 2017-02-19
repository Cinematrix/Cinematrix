using Cinema.Data.Models;
using Cinema.Data.Repositories;
using Moq;
using NUnit.Framework;
using System.Linq;

namespace Cinema.Tests.Data.Services.Tests.FilmScreeningService
{
    [TestFixture]
    public class GetAllScreeningsShould
    {
        [Test]
        public void CallFilmScreeningRepositoryAllMethod()
        {
            var mockedScreeningRepo = new Mock<IRepository<FilmScreening>>();
            var mockedFilmSCreening = new Mock<FilmScreening>();

            var actualFilmSCreeningService =
                new Cinema.Data.Services.FilmScreeningService(mockedScreeningRepo.Object, mockedFilmSCreening.Object);

            actualFilmSCreeningService.GetAllScreenings();

            mockedScreeningRepo.Verify(service => service.All(), Times.Once);
        }

        [Test]
        public void ReturnIQueryableFilmScreeningsCollectionFromRepositoryAllMethod()
        {
            var mockedScreeningRepo = new Mock<IRepository<FilmScreening>>();
            var mockedFilmSCreening = new Mock<FilmScreening>();

            var actualFilmSCreeningService =
                new Cinema.Data.Services.FilmScreeningService(mockedScreeningRepo.Object, mockedFilmSCreening.Object);

            var result = actualFilmSCreeningService.GetAllScreenings();

            Assert.That(result, Is.Not.Null.And.InstanceOf<IQueryable<FilmScreening>>());
        }
    }
}
