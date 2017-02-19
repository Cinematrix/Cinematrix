using Cinema.Data.Models;
using Cinema.Data.Repositories;
using Moq;
using NUnit.Framework;

namespace Cinema.Tests.Data.Services.Tests.MoviesService
{
    [TestFixture]
    public class GetByIdShould
    {
        [Test]
        public void CallMoviesRepoGetByIdMethodWithSameParamterId()
        {
            var mockedMovieRepo = new Mock<IRepository<Movie>>();
            string stringId = "1";
            int intId = 1;

            var actualMoviesService =
                new Cinema.Data.Services.MoviesService(mockedMovieRepo.Object);

            actualMoviesService.GetById(stringId);

            mockedMovieRepo.Verify(service => service.GetById(intId), Times.Once);
        }

        [Test]
        public void ThrowArgumentExceptionWhenParamterIdIsNotNumber()
        {
            var mockedMovieRepo = new Mock<IRepository<Movie>>();
            string stringId = "abc";

            var actualMoviesService =
                new Cinema.Data.Services.MoviesService(mockedMovieRepo.Object);

            Assert.That(
                () => actualMoviesService.GetById(stringId), Throws.ArgumentException);
        }
    }
}
