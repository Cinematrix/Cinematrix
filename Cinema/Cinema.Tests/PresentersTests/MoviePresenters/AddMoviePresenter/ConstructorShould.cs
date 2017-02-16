using System;
using NUnit.Framework;
using Moq;
using Cinema.Data.Services.Contracts;

namespace Cinema.Tests.PresentersTests.MoviePresenters.AddMoviePresenter
{
    [TestFixture]
    public class ConstructorShould
    {
        [Test]
        public void InitiateNewAddMoviePresenterInstanceWhenProperDependanciesArePassed()
        {
            var mockedMoviesService = new Mock<IMoviesService>();
            var mockedNavigationService = new Mock<INavigationService>();

            var actualAddMoviePresenter =
                new Presenters.MoviePresenters.AddMoviePresenter(mockedMoviesService.Object, mockedNavigationService.Object);

            Assert.IsInstanceOf(typeof(Presenters.MoviePresenters.AddMoviePresenter), actualAddMoviePresenter);
        }

        [Test]
        public void ThrowWhenMoviesServiceHasNullValue()
        {
            IMoviesService moviesService = null;
            var mockedNavigationService = new Mock<INavigationService>();

            Assert.That(
                () => new Presenters.MoviePresenters.AddMoviePresenter(moviesService, mockedNavigationService.Object),
                Throws.InstanceOf<ArgumentNullException>());
        }

        [Test]
        public void ThrowWhenNavigationServiceHasNullValue()
        {
            var mockedMoviesService = new Mock<IMoviesService>();
            INavigationService navigationService = null;

            Assert.That(
                () => new Presenters.MoviePresenters.AddMoviePresenter(mockedMoviesService.Object, navigationService),
                Throws.InstanceOf<ArgumentNullException>());
        }
    }
}
