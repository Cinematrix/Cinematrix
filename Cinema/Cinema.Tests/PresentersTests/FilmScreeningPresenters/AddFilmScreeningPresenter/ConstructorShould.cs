using Cinema.Data.Services.Contracts;
using Moq;
using NUnit.Framework;
using System;

namespace Cinema.Tests.PresentersTests.FilmScreeningPresenters.AddFilmScreeningPresenter
{
    [TestFixture]
    public class ConstructorShould
    {
        [Test]
        public void InitiateNewAddFilmScreeningPresenterInstanceWhenProperDependancyIsPassed()
        {
            var mockedMoviesService = new Mock<IMoviesService>();
            var mockedScreeningService = new Mock<IFilmScreeningService>();
            var mockedNavigationService = new Mock<INavigationService>();

            var actualAddFilmScreeningPresenter =
                new Presenters.FilmScreeningPresenters.AddFilmScreeningPresenter(
                    mockedScreeningService.Object,
                    mockedMoviesService.Object,
                    mockedNavigationService.Object);

            Assert.IsInstanceOf(typeof(Presenters.FilmScreeningPresenters.AddFilmScreeningPresenter), actualAddFilmScreeningPresenter);
        }

        [Test]
        public void ThrowWhenMoviesServiceHasNullValue()
        {
            IMoviesService nullMoviesService = null;
            var mockedScreeningService = new Mock<IFilmScreeningService>();
            var mockedNavigationService = new Mock<INavigationService>();

            Assert.That(
                () => new Presenters.FilmScreeningPresenters.AddFilmScreeningPresenter(
                    mockedScreeningService.Object,
                    nullMoviesService,
                    mockedNavigationService.Object),
                Throws.InstanceOf<ArgumentNullException>());
        }

        [Test]
        public void ThrowWhenFilmScreeningServiceHasNullValue()
        {
            var mockedMoviesService = new Mock<IMoviesService>();
            IFilmScreeningService nullScreeningService = null;
            var mockedNavigationService = new Mock<INavigationService>();

            Assert.That(
                () => new Presenters.FilmScreeningPresenters.AddFilmScreeningPresenter(
                    nullScreeningService,
                    mockedMoviesService.Object,
                    mockedNavigationService.Object),
                Throws.InstanceOf<ArgumentNullException>());
        }

        [Test]
        public void ThrowWhenNavigationServiceHasNullValue()
        {
            var mockedMoviesService = new Mock<IMoviesService>();
            var mockedScreeningService = new Mock<IFilmScreeningService>();
            INavigationService nullNavigationService = null;

            Assert.That(
                () => new Presenters.FilmScreeningPresenters.AddFilmScreeningPresenter(
                    mockedScreeningService.Object,
                    mockedMoviesService.Object,
                    nullNavigationService),
                Throws.InstanceOf<ArgumentNullException>());
        }
    }
}
