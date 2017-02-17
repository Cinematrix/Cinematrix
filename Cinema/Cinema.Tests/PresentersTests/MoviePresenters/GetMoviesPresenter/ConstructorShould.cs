using Cinema.Data.Services.Contracts;
using Moq;
using NUnit.Framework;
using System;

namespace Cinema.Tests.PresentersTests.MoviePresenters.GetMoviesPresenter
{
    [TestFixture]
    public class ConstructorShould
    {
        [Test]
        public void InitiateNewGetMoviePresenterInstanceWhenProperDependancyIsPassed()
        {
            var mockedMoviesService = new Mock<IMoviesService>();

            var actualGetMoviesPresenter = 
                new Presenters.MoviePresenters.GetMoviesPresenter(mockedMoviesService.Object);

            Assert.IsInstanceOf(typeof(Presenters.MoviePresenters.GetMoviesPresenter), actualGetMoviesPresenter);
        }

        [Test]
        public void ThrowWhenMoviesServiceHasNullValue()
        {
            IMoviesService moviesService = null;

            Assert.That(
                () => new Presenters.MoviePresenters.GetMoviesPresenter(moviesService),
                Throws.InstanceOf<ArgumentNullException>());
        }
    }
}
