using Cinema.Data.Models;
using Cinema.Data.Repositories;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Tests.Data.Services.Tests.MoviesService
{
    [TestFixture]
    public class GetAllShould
    {
        [Test]
        public void CallMovieRepositoryAllMethod()
        {
            var mockedMovieRepo = new Mock<IRepository<Movie>>();

            var actualMoviesService =
                new Cinema.Data.Services.MoviesService(mockedMovieRepo.Object);

            actualMoviesService.GetAll();

            mockedMovieRepo.Verify(service => service.All(), Times.Once);
        }

        [Test]
        public void ReturnIQueryableMoviesCollectionProvidedFromMovieRepositoryAllMethod()
        {
            var mockedMovieRepo = new Mock<IRepository<Movie>>();

            var actualMoviesService =
                new Cinema.Data.Services.MoviesService(mockedMovieRepo.Object);

            var result = actualMoviesService.GetAll();

            Assert.That(result, Is.Not.Null.And.InstanceOf<IQueryable<Movie>>());
        }
    }
}
