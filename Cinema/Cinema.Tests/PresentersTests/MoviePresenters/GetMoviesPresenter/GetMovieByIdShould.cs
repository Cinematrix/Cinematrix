using Cinema.Data.Services.Contracts;
using Moq;
using NUnit.Framework;
using System;

namespace Cinema.Tests.PresentersTests.MoviePresenters.GetMoviesPresenter
{
    [TestFixture]
    public class GetMovieByIdShould
    {
        [Test]
        public void CallMoviesServiceGetByIdMethod()
        {
            var mockedMoviesService = new Mock<IMoviesService>();

            var actualGetMoviesPresenter =
                new Presenters.MoviePresenters.GetMoviesPresenter(mockedMoviesService.Object);

            actualGetMoviesPresenter.GetMovieById("1");

            mockedMoviesService.Verify(service => service.GetById(It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void ThrowWhenIsCalledWithNullOrEmptyParameter()
        {
            var mockedMoviesService = new Mock<IMoviesService>();
            string nullId = null;

            var actualGetMoviesPresenter =
                new Presenters.MoviePresenters.GetMoviesPresenter(mockedMoviesService.Object);

            Assert.That(
                () => actualGetMoviesPresenter.GetMovieById(nullId),
                Throws.InstanceOf<ArgumentNullException>());
        }

        [TestCase("1")]
        [TestCase("5")]
        public void CallMoviesServiceGetByIdMethodWithExactlySameId(string testId)
        {
            var mockedMoviesService = new Mock<IMoviesService>();

            var actualGetMoviesPresenter =
                new Presenters.MoviePresenters.GetMoviesPresenter(mockedMoviesService.Object);

            actualGetMoviesPresenter.GetMovieById(testId);

            mockedMoviesService.Verify(service => service.GetById(testId), Times.Once);
        }
    }
}
