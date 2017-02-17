using Cinema.Data.Models;
using Cinema.Data.Services.Contracts;
using Moq;
using NUnit.Framework;
using System.Linq;

namespace Cinema.Tests.PresentersTests.FilmScreeningPresenters.GetFilmScreeningsPresenter
{
    [TestFixture]
    public class GetAllFutureScreeningsShould
    {
        [Test]
        public void CallScreeningServiceGetAllFutureScreeningsMethod()
        {
            var mockedScreeningService = new Mock<IFilmScreeningService>();

            var actualGetFilmScreeningsPresenter =
               new Presenters.FilmScreeningPresenters.GetFilmScreeningsPresenter(mockedScreeningService.Object);

            actualGetFilmScreeningsPresenter.GetAllFutureScreenings();

            mockedScreeningService.Verify(service => service.GetAllFutureScreenings(), Times.Once);
        }

        [Test]
        public void ReturnIQueryableFilmScreeningCollectionWhenIsCalled()
        {
            var mockedScreeningService = new Mock<IFilmScreeningService>();

            var actualGetFilmScreeningsPresenter =
               new Presenters.FilmScreeningPresenters.GetFilmScreeningsPresenter(mockedScreeningService.Object);

            var result = actualGetFilmScreeningsPresenter.GetAllFutureScreenings();

            Assert.That(result, Is.Not.Null.And.InstanceOf<IQueryable<FilmScreening>>());
        }
    }
}