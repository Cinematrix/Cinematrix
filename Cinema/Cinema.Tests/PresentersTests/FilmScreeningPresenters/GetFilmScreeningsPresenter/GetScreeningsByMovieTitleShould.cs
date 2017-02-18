using Cinema.Data.Models;
using Cinema.Data.Services.Contracts;
using Moq;
using NUnit.Framework;
using System.Linq;

namespace Cinema.Tests.PresentersTests.FilmScreeningPresenters.GetFilmScreeningsPresenter
{
    [TestFixture]
    public class GetScreeningsByMovieTitleShould
    {
        [TestCase("X-man")]
        [TestCase("Batman")]
        public void CallFilmScreeningServiceGetScreeningsByMovieTitleMethodWithTheSameParameter(string validTitle)
        {
            var mockedScreeningService = new Mock<IFilmScreeningService>();

            var actualGetFilmScreeningsPresenter =
                new Presenters.FilmScreeningPresenters.GetFilmScreeningsPresenter(mockedScreeningService.Object);

            actualGetFilmScreeningsPresenter.GetScreeningsByMovieTitle(validTitle);

            mockedScreeningService.Verify(service => service.GetScreeningsByMovieTitle(validTitle), Times.Once);
        }

        [TestCase(null)]
        [TestCase("")]
        public void AllowCallingFilmScreeningServiceGetScreeningsByMovieTitleMethodWithNullOrEmptyParameters(string nullParameter)
        {
            var mockedScreeningService = new Mock<IFilmScreeningService>();

            var actualGetFilmScreeningsPresenter =
                new Presenters.FilmScreeningPresenters.GetFilmScreeningsPresenter(mockedScreeningService.Object);

            actualGetFilmScreeningsPresenter.GetScreeningsByMovieTitle(nullParameter);

            mockedScreeningService.Verify(service => service.GetScreeningsByMovieTitle(nullParameter), Times.Once);
        }

        [Test]
        public void ReturnIQueryableFilmSCreeningsCollectionWhenIsCalled()
        {
            var mockedScreeningService = new Mock<IFilmScreeningService>();
            string validTitle = "Batman";

            var actualGetFilmScreeningsPresenter =
                new Presenters.FilmScreeningPresenters.GetFilmScreeningsPresenter(mockedScreeningService.Object);

            var result = actualGetFilmScreeningsPresenter.GetScreeningsByMovieTitle(validTitle);

            Assert.That(result, Is.Not.Null.And.InstanceOf<IQueryable<FilmScreening>>());
        }
    }
}
