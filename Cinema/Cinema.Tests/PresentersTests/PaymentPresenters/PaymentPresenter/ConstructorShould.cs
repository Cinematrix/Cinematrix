using Cinema.Data.Services.Contracts;
using Moq;
using NUnit.Framework;
using System;

namespace Cinema.Tests.PresentersTests.PaymentPresenters.PaymentPresenter
{
    [TestFixture]
    public class ConstructorShould
    {
        [Test]
        public void InitiateNewInstanceOfPaymentPresenterWhenPropperDependanciesArePassed()
        {
            var mockedScreeningService = new Mock<IFilmScreeningService>();
            var mockedSeatService = new Mock<ISeatService>();

            var actualPaymentPresenter =
                new Presenters.PaymentPresenters.PaymentPresenter(mockedScreeningService.Object, mockedSeatService.Object);

            Assert.IsInstanceOf(
                typeof(Presenters.PaymentPresenters.PaymentPresenter), actualPaymentPresenter);
        }

        [Test]
        public void ThrowWnehFilmScreeningServiceHasNullValue()
        {
            IFilmScreeningService nullScreeningService = null;
            var mockedSeatService = new Mock<ISeatService>();

            Assert.That(
               () => new Presenters.PaymentPresenters.PaymentPresenter(
                   nullScreeningService,
                   mockedSeatService.Object),
               Throws.InstanceOf<ArgumentNullException>());
        }

        [Test]
        public void ThrowWnehSeatServiceHasNullValue()
        {
            var mockedScreeningService = new Mock<IFilmScreeningService>();
            ISeatService nullSeatService = null;

            Assert.That(
               () => new Presenters.PaymentPresenters.PaymentPresenter(
                   mockedScreeningService.Object,
                   nullSeatService),
               Throws.InstanceOf<ArgumentNullException>());
        }
    }
}
