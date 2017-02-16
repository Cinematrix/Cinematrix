using Cinema.Data.Models;
using Cinema.Data.Services.Contracts;
using Moq;
using NUnit.Framework;
using System;
using System.Web.UI;

namespace Cinema.Tests.PresentersTests.MoviePresenters.AddMoviePresenter
{
    [TestFixture]
    public class CreateMovieShould
    {
        [Test]
        public void CallMoviesServiceCreateMethodWhenPropperDependanciesArePassed()
        {
            var mockedMoviesService = new Mock<IMoviesService>();
            var mockedNavigationService = new Mock<INavigationService>();
            var mockedMovie = new Mock<Movie>();
            var mockedPage = new Mock<Page>();

            var actualGetMoviesPresenter =
                new Presenters.MoviePresenters.AddMoviePresenter(mockedMoviesService.Object, mockedNavigationService.Object);

            actualGetMoviesPresenter.CreateMovie(mockedMovie.Object, mockedPage.Object);

            mockedMoviesService.Verify(service => service.Create(mockedMovie.Object), Times.Once);
        }

        [Test]
        public void CallNavigationServiceCreateMethodWhenPropperDependanciesArePassed()
        {
            var mockedMoviesService = new Mock<IMoviesService>();
            var mockedNavigationService = new Mock<INavigationService>();
            var mockedMovie = new Mock<Movie>();
            var mockedPage = new Mock<Page>();
            var mockedUrl = "/MoviesListView.aspx";

            mockedNavigationService.Setup(x => x.Redirect(It.IsAny<Page>(), It.IsAny<string>()));

            var actualGetMoviesPresenter =
                new Presenters.MoviePresenters.AddMoviePresenter(mockedMoviesService.Object, mockedNavigationService.Object);

            actualGetMoviesPresenter.CreateMovie(mockedMovie.Object, mockedPage.Object);

            mockedNavigationService.Verify(service => service.Redirect(mockedPage.Object, mockedUrl), Times.Once);
        }

        [Test]
        public void ThrowWhenMovieToAddIsNull()
        {
            var mockedMoviesService = new Mock<IMoviesService>();
            var mockedNavigationService = new Mock<INavigationService>();
            var mockedPage = new Mock<Page>();
            Movie nullMovieToAdd = null;

            var actualGetMoviesPresenter =
                new Presenters.MoviePresenters.AddMoviePresenter(mockedMoviesService.Object, mockedNavigationService.Object);

            Assert.That(
                () => actualGetMoviesPresenter.CreateMovie(nullMovieToAdd, mockedPage.Object),
                Throws.InstanceOf<ArgumentNullException>());
        }

        [Test]
        public void ThrowWhenPassedPageIsNull()
        {
            var mockedMoviesService = new Mock<IMoviesService>();
            var mockedNavigationService = new Mock<INavigationService>();
            var mockedMovie = new Mock<Movie>();
            Page nullPage = null;

            var actualGetMoviesPresenter =
                new Presenters.MoviePresenters.AddMoviePresenter(mockedMoviesService.Object, mockedNavigationService.Object);

            Assert.That(
                () => actualGetMoviesPresenter.CreateMovie(mockedMovie.Object, nullPage),
                Throws.InstanceOf<ArgumentNullException>());
        }
    }
}
