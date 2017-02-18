using Cinema.Data.Models;
using Cinema.Data.Services.Contracts;
using Moq;
using NUnit.Framework;
using System;

namespace Cinema.Tests.PresentersTests.UpdateFilmSCreeningPresenters
{
    [TestFixture]
    public class GetScreeningByIdShould
    {
        [TestCase("1")]
        [TestCase("5")]
        public void CallFilmScreeningServiceGetByIdMethodWithTheSameId(string validId)
        {
            var mockedScreeningService = new Mock<IFilmScreeningService>();

            var actualUpdateFilmScreeningPresenter =
                new Presenters.FilmScreeningPresenters.UpdateFilmScreeningPresenter(mockedScreeningService.Object);

            actualUpdateFilmScreeningPresenter.GetScreeningById(validId);

            mockedScreeningService.Verify(service => service.GetById(validId), Times.Once);
        }

        [Test]
        public void ThrowWhenIsCalledWithNullOrEmptyParameterId()
        {
            var mockedScreeningService = new Mock<IFilmScreeningService>();
            string nullId = null;

            var actualUpdateFilmScreeningPresenter =
                new Presenters.FilmScreeningPresenters.UpdateFilmScreeningPresenter(mockedScreeningService.Object);

            Assert.That(
                () => actualUpdateFilmScreeningPresenter.GetScreeningById(nullId),
                Throws.InstanceOf<ArgumentNullException>());
        }

        [Test]
        public void ReturnFilmSCreeningWhenIsCalled()
        {
            var mockedScreeningService = new Mock<IFilmScreeningService>();
            string validId = "1";

            mockedScreeningService.Setup(s => s.GetById(It.IsAny<string>())).Returns(new FilmScreening());

            var actualUpdateFilmScreeningPresenter =
                new Presenters.FilmScreeningPresenters.UpdateFilmScreeningPresenter(mockedScreeningService.Object);

            var result = actualUpdateFilmScreeningPresenter.GetScreeningById(validId);

            Assert.That(result, Is.Not.Null.And.InstanceOf<FilmScreening>());
        }
    }
}
