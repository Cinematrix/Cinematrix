using Cinema.Data.Services.Contracts;
using Moq;
using NUnit.Framework;
using System;

namespace Cinema.Tests.PresentersTests.UpdateFilmSCreeningPresenters
{
    [TestFixture]
    public class ConstructorShould
    {
        [Test]
        public void InitiateNewUpdateFilmScreeningsPresenterInstanceWhenProperDependancyIsPassed()
        {
            var mockedScreeningService = new Mock<IFilmScreeningService>();

            var actualUpdateFilmScreeningPresenter =
               new Presenters.FilmScreeningPresenters.UpdateFilmScreeningPresenter(mockedScreeningService.Object);

            Assert.IsInstanceOf(
                typeof(Presenters.FilmScreeningPresenters.UpdateFilmScreeningPresenter), actualUpdateFilmScreeningPresenter);
        }

        [Test]
        public void ThrowWhenFilmSCreeningsServiceHasNullValue()
        {
            IFilmScreeningService nullScreeningService = null;

            Assert.That(
                () => new Presenters.FilmScreeningPresenters.UpdateFilmScreeningPresenter(nullScreeningService),
                Throws.InstanceOf<ArgumentNullException>());
        }
    }
}
