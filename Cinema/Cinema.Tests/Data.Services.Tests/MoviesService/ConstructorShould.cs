using Cinema.Data.Models;
using Cinema.Data.Repositories;
using Cinema.Data.Services.Contracts;
using Moq;
using NUnit.Framework;
using System;

namespace Cinema.Tests.Data.Services.Tests.MoviesService
{
    [TestFixture]
    public class ConstructorShould
    {
        [Test]
        public void InitiateNewMoviesServiceWhenPropperDependancyIsPassed()
        {
            var mockedMovieRepo = new Mock<IRepository<Movie>>();

            Assert.That(
                () => new Cinema.Data.Services.MoviesService(mockedMovieRepo.Object),
                Is.InstanceOf<IMoviesService>());
        }

        [Test]
        public void ThrowWhenArgumentMoviesRepositoryIsNull()
        {
            IRepository<Movie> nullMovieRepo = null;

            Assert.That(
                () => new Cinema.Data.Services.MoviesService(nullMovieRepo),
                Throws.InstanceOf<ArgumentNullException>());
        }
    }
}
