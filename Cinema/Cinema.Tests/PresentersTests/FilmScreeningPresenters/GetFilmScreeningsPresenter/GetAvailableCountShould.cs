using Cinema.Data.Services.Contracts;
using Moq;
using NUnit.Framework;
using System;

namespace Cinema.Tests.PresentersTests.FilmScreeningPresenters.GetFilmScreeningsPresenter
{
    [TestFixture]
    public class GetAvailableCountShould
    {
        [Test]
        public void ThrowWhenIsCalledWithNullOrEmptyParameterId()
        {
            var mockedScreeningService = new Mock<IFilmScreeningService>();
            string nullId = null;

            var actualGetFilmScreeningsPresenter =
                new Presenters.FilmScreeningPresenters.GetFilmScreeningsPresenter(mockedScreeningService.Object);

            Assert.That(
                () => actualGetFilmScreeningsPresenter.GetAvailableCount(nullId),
                Throws.InstanceOf<ArgumentNullException>());
        }

        [TestCase("1")]
        [TestCase("5")]
        public void CallFilmScreeningServiceGetAvailableCountMethodWithTheSameId(string validId)
        {
            var mockedScreeningService = new Mock<IFilmScreeningService>();

            var actualGetFilmScreeningsPresenter =
                new Presenters.FilmScreeningPresenters.GetFilmScreeningsPresenter(mockedScreeningService.Object);

            actualGetFilmScreeningsPresenter.GetAvailableCount(validId);

            mockedScreeningService.Verify(service => service.GetAvailableCount(validId), Times.Once);
        }
    }
}
