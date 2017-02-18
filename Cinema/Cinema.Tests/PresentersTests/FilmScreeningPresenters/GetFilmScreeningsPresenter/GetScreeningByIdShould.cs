using Cinema.Data.Models;
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

        [Test]
        public void ReturnFilmSCreeningWhenIsCalled()
        {
            var mockedScreeningService = new Mock<IFilmScreeningService>();
            string validId = "1";

            mockedScreeningService.Setup(s => s.GetById(It.IsAny<string>())).Returns(new FilmScreening());

            var actualGetFilmScreeningsPresenter =
                new Presenters.FilmScreeningPresenters.GetFilmScreeningsPresenter(mockedScreeningService.Object);

            var result = actualGetFilmScreeningsPresenter.GetScreeningById(validId);

            Assert.That(result, Is.Not.Null.And.InstanceOf<FilmScreening>());
        }
    }
}