using Cinema.Data.Services.Contracts;
using Moq;
using NUnit.Framework;
using System;

namespace Cinema.Tests.PresentersTests.FilmScreeningPresenters.GetFilmScreeningsPresenter
{
    [TestFixture]
    public class ConstructorShould
    {
        [Test]
        public void InitiateNewGetFilmScreeningsPresenterInstanceWhenProperDependancyIsPassed()
        {
            var mockedScreeningService = new Mock<IFilmScreeningService>();

            var actualGetFilmScreeningsPresenter =
               new Presenters.FilmScreeningPresenters.GetFilmScreeningsPresenter(mockedScreeningService.Object);

            Assert.IsInstanceOf(
                typeof(Presenters.FilmScreeningPresenters.GetFilmScreeningsPresenter), actualGetFilmScreeningsPresenter);
        }

        [Test]
        public void ThrowWhenFilmSCreeningsServiceHasNullValue()
        {
            IFilmScreeningService nullScreeningService = null;

            Assert.That(
                () => new Presenters.FilmScreeningPresenters.GetFilmScreeningsPresenter(nullScreeningService),
                Throws.InstanceOf<ArgumentNullException>());
        }
    }
}
