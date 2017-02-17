using Cinema.Data.Models;
using Cinema.Data.Services.Contracts;
using Moq;
using NUnit.Framework;
using System.Linq;

namespace Cinema.Tests.PresentersTests.MoviePresenters.GetMoviesPresenter
{
    [TestFixture]
    public class GetAllMoviesShould
    {
        [Test]
        public void CallMoviesServiceGetAllMethod()
        {
            var mockedMoviesService = new Mock<IMoviesService>();

            var actualGetMoviesPresenter =
                new Presenters.MoviePresenters.GetMoviesPresenter(mockedMoviesService.Object);

            actualGetMoviesPresenter.GetAllMovies();

            mockedMoviesService.Verify(service => service.GetAll(), Times.Once);
        }

        [Test]
        public void ReturnIQueryableMovieCollectionWhenIsCalled()
        {
            var mockedMoviesService = new Mock<IMoviesService>();

            var actualGetMoviesPresenter =
                new Presenters.MoviePresenters.GetMoviesPresenter(mockedMoviesService.Object);

            var result = actualGetMoviesPresenter.GetAllMovies();

            Assert.That(result, Is.Not.Null.And.InstanceOf<IQueryable<Movie>>());
        }
    }
}
