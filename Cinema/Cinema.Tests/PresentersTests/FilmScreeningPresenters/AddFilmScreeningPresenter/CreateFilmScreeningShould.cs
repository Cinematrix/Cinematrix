using Cinema.Data.Services.Contracts;
using Moq;
using NUnit.Framework;
using System;
using System.Web.UI;

namespace Cinema.Tests.PresentersTests.FilmScreeningPresenters.AddFilmScreeningPresenter
{
    [TestFixture]
    public class CreateFilmScreeningShould
    {
        [Test]
        public void CallFilmScreeningServiceCreateMethodWithTheSameArguments()
        {
            var mockedMoviesService = new Mock<IMoviesService>();
            var mockedScreeningService = new Mock<IFilmScreeningService>();
            var mockedNavigationService = new Mock<INavigationService>();

            string date = "3/22/2017";
            string id = "1";
            string price = "10";
            var mockedPage = new Mock<Page>();

            var actualAddFilmScreeningPresenter =
                new Presenters.FilmScreeningPresenters.AddFilmScreeningPresenter(
                    mockedScreeningService.Object,
                    mockedMoviesService.Object,
                    mockedNavigationService.Object);

            actualAddFilmScreeningPresenter.CreateFilmScreening(date, id, price, mockedPage.Object);

            mockedScreeningService.Verify(service => service.Create(date, id, price), Times.Once);
        }

        [Test]
        public void CallNavigationServiceRedirectMethod()
        {
            var mockedMoviesService = new Mock<IMoviesService>();
            var mockedScreeningService = new Mock<IFilmScreeningService>();
            var mockedNavigationService = new Mock<INavigationService>();

            string date = "3/22/2017";
            string id = "1";
            string price = "10";
            var mockedPage = new Mock<Page>();

            mockedNavigationService.Setup(x => x.Redirect(It.IsAny<Page>(), It.IsAny<string>()));

            var actualAddFilmScreeningPresenter =
                new Presenters.FilmScreeningPresenters.AddFilmScreeningPresenter(
                    mockedScreeningService.Object,
                    mockedMoviesService.Object,
                    mockedNavigationService.Object);

            actualAddFilmScreeningPresenter.CreateFilmScreening(date, id, price, mockedPage.Object);

            mockedNavigationService.Verify(service => service.Redirect(mockedPage.Object, It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void ThrowWhenArgumentDateIsNullOrEmpty()
        {
            var mockedMoviesService = new Mock<IMoviesService>();
            var mockedScreeningService = new Mock<IFilmScreeningService>();
            var mockedNavigationService = new Mock<INavigationService>();

            string nullDate = null;
            string id = "1";
            string price = "10";
            var mockedPage = new Mock<Page>();

            var actualAddFilmScreeningPresenter =
                new Presenters.FilmScreeningPresenters.AddFilmScreeningPresenter(
                    mockedScreeningService.Object,
                    mockedMoviesService.Object,
                    mockedNavigationService.Object);

            Assert.That(
                () => actualAddFilmScreeningPresenter.CreateFilmScreening(nullDate, id, price, mockedPage.Object),
                Throws.InstanceOf<ArgumentNullException>());
        }

        [Test]
        public void ThrowWhenArgumentIdIsNullOrEmpty()
        {
            var mockedMoviesService = new Mock<IMoviesService>();
            var mockedScreeningService = new Mock<IFilmScreeningService>();
            var mockedNavigationService = new Mock<INavigationService>();

            string date = "3/22/2017";
            string nullId = null;
            string price = "10";
            var mockedPage = new Mock<Page>();

            var actualAddFilmScreeningPresenter =
                new Presenters.FilmScreeningPresenters.AddFilmScreeningPresenter(
                    mockedScreeningService.Object,
                    mockedMoviesService.Object,
                    mockedNavigationService.Object);

            Assert.That(
                () => actualAddFilmScreeningPresenter.CreateFilmScreening(date, nullId, price, mockedPage.Object),
                Throws.InstanceOf<ArgumentNullException>());
        }

        [Test]
        public void ThrowWhenArgumentPriceIsNullOrEmpty()
        {
            var mockedMoviesService = new Mock<IMoviesService>();
            var mockedScreeningService = new Mock<IFilmScreeningService>();
            var mockedNavigationService = new Mock<INavigationService>();

            string date = "3/22/2017";
            string id = "1";
            string nullPrice = null;
            var mockedPage = new Mock<Page>();

            var actualAddFilmScreeningPresenter =
                new Presenters.FilmScreeningPresenters.AddFilmScreeningPresenter(
                    mockedScreeningService.Object,
                    mockedMoviesService.Object,
                    mockedNavigationService.Object);

            Assert.That(
                () => actualAddFilmScreeningPresenter.CreateFilmScreening(date, id, nullPrice, mockedPage.Object),
                Throws.InstanceOf<ArgumentNullException>());
        }
    }
}
