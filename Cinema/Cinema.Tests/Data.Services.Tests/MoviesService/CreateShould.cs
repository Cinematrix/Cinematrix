using Cinema.Data.Models;
using Cinema.Data.Repositories;
using Moq;
using NUnit.Framework;
using System;

namespace Cinema.Tests.Data.Services.Tests.MoviesService
{
    [TestFixture]
    public class CreateShould
    {
        [Test]
        public void CallMoviesRepoAddMethodWithSameRecievedMovie()
        {
            var mockedMovieRepo = new Mock<IRepository<Movie>>();
            var mockedMovie = new Mock<Movie>();

            var actualMoviesService =
                new Cinema.Data.Services.MoviesService(mockedMovieRepo.Object);

            actualMoviesService.Create(mockedMovie.Object);

            mockedMovieRepo.Verify(
                service => service.Add(mockedMovie.Object),
                Times.Once);
        }

        [Test]
        public void CallMoviesRepoSaveChangesMethod()
        {
            var mockedMovieRepo = new Mock<IRepository<Movie>>();
            var mockedMovie = new Mock<Movie>();

            var actualMoviesService =
                new Cinema.Data.Services.MoviesService(mockedMovieRepo.Object);

            actualMoviesService.Create(mockedMovie.Object);

            mockedMovieRepo.Verify(
                service => service.SaveChanges(),
                Times.Once);
        }

        [Test]
        public void ThrowWhenArgumentMovieHasNullValue()
        {
            var mockedMovieRepo = new Mock<IRepository<Movie>>();
            Movie nullMovie = null;

            var actualMoviesService =
                new Cinema.Data.Services.MoviesService(mockedMovieRepo.Object);

            Assert.That(
                () => actualMoviesService.Create(nullMovie),
                Throws.InstanceOf<ArgumentNullException>());
        }
    }
}
