using Cinema.Data.Models;
using Cinema.Data.Services.Contracts;
using Moq;
using NUnit.Framework;
using System;

namespace Cinema.Tests.PresentersTests.UpdateFilmSCreeningPresenters
{
    [TestFixture]
    public class UpdateScreeningShould
    {
        [Test]
        public void CallFilmScreeningServiceUpdateByIdMethodWithTheSameArguments()
        {
            var mockedScreeningService = new Mock<IFilmScreeningService>();
            string screeningId = "1";
            var mockedScreening = new Mock<FilmScreening>();

            var actualUpdateFilmScreeningPresenter =
               new Presenters.FilmScreeningPresenters.UpdateFilmScreeningPresenter(mockedScreeningService.Object);

            actualUpdateFilmScreeningPresenter.UpdateScreening(screeningId, mockedScreening.Object);

            mockedScreeningService.Verify(
                service => service.UpdateById(screeningId, mockedScreening.Object), Times.Once);
        }

        [Test]
        public void ThrowWhenParameterScreeningIdIsNullOrEmpty()
        {
            var mockedScreeningService = new Mock<IFilmScreeningService>();
            string nullScreeningId = null;
            var mockedScreening = new Mock<FilmScreening>();

            var actualUpdateFilmScreeningPresenter =
               new Presenters.FilmScreeningPresenters.UpdateFilmScreeningPresenter(mockedScreeningService.Object);

            Assert.That(
                () => actualUpdateFilmScreeningPresenter.UpdateScreening(nullScreeningId, mockedScreening.Object),
                Throws.InstanceOf<ArgumentNullException>());
        }

        [Test]
        public void ThrowWhenParameterUpdatedScreeningIsNull()
        {
            var mockedScreeningService = new Mock<IFilmScreeningService>();
            string screeningId = "1";
            FilmScreening nullScreening = null;

            var actualUpdateFilmScreeningPresenter =
               new Presenters.FilmScreeningPresenters.UpdateFilmScreeningPresenter(mockedScreeningService.Object);

            Assert.That(
                () => actualUpdateFilmScreeningPresenter.UpdateScreening(screeningId, nullScreening),
                Throws.InstanceOf<ArgumentNullException>());
        }
    }
}
