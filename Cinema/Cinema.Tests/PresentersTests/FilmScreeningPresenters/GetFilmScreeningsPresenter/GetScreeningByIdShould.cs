using Cinema.Data.Services.Contracts;
using Moq;
using NUnit.Framework;
using System;

namespace Cinema.Tests.PresentersTests.FilmScreeningPresenters.GetFilmScreeningsPresenter
{
    [TestFixture]
    public class GetScreeningByIdShould
    {
        [TestCase("1")]
        [TestCase("5")]
        public void CallFilmScreeningServiceGetByIdMethodWithTheSameId(string validId)
        {
            var mockedScreeningService = new Mock<IFilmScreeningService>();

            var actualGetFilmScreeningsPresenter =
                new Presenters.FilmScreeningPresenters.GetFilmScreeningsPresenter(mockedScreeningService.Object);

            actualGetFilmScreeningsPresenter.GetScreeningById(validId);

            mockedScreeningService.Verify(service => service.GetById(validId), Times.Once);
        }

        [Test]
        public void ThrowWhenIsCalledWithNullOrEmptyParameterId()
        {
            var mockedScreeningService = new Mock<IFilmScreeningService>();
            string nullId = null;

            var actualGetFilmScreeningsPresenter =
                new Presenters.FilmScreeningPresenters.GetFilmScreeningsPresenter(mockedScreeningService.Object);

            Assert.That(
                () => actualGetFilmScreeningsPresenter.GetScreeningById(nullId),
                Throws.InstanceOf<ArgumentNullException>());
        }
    }
}