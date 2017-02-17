using Cinema.Data.Models;
using Cinema.Data.Services.Contracts;
using Moq;
using NUnit.Framework;
using System.Linq;

namespace Cinema.Tests.PresentersTests.FilmScreeningPresenters.AddFilmScreeningPresenter
{
    [TestFixture]
    public class GetAllMoviesShould
    {
        [Test]
        public void CallMoviesServiceGetAllMethod()
        {
            var mockedMoviesService = new Mock<IMoviesService>();
            var mockedScreeningService = new Mock<IFilmScreeningService>();
            var mockedNavigationService = new Mock<INavigationService>();

            var actualAddFilmScreeningPresenter =
                new Presenters.FilmScreeningPresenters.AddFilmScreeningPresenter(
                    mockedScreeningService.Object,
                    mockedMoviesService.Object,
                    mockedNavigationService.Object);

            actualAddFilmScreeningPresenter.GetAllMovies();

            mockedMoviesService.Verify(service => service.GetAll(), Times.Once);
        }

        [Test]
        public void ReturnIQueryableMovieCollectionWhenIsCalled()
        {
            var mockedMoviesService = new Mock<IMoviesService>();
            var mockedScreeningService = new Mock<IFilmScreeningService>();
            var mockedNavigationService = new Mock<INavigationService>();

            var actualAddFilmScreeningPresenter =
                 new Presenters.FilmScreeningPresenters.AddFilmScreeningPresenter(
                     mockedScreeningService.Object,
                     mockedMoviesService.Object,
                     mockedNavigationService.Object);

            var result = actualAddFilmScreeningPresenter.GetAllMovies();

            Assert.That(result, Is.Not.Null.And.InstanceOf<IQueryable<Movie>>());
        }
    }
}
