using Cinema.Data.Services.Contracts;
using Moq;
using NUnit.Framework;
using System;

namespace Cinema.Tests.PresentersTests.PaymentPresenters.PaymentPresenter
{
    [TestFixture]
    public class GetMovieTitleByScreeningIdShould
    {
        [TestCase(null)]
        [TestCase("")]
        public void ThrowWhenParameterIdIsNullOrEmpty(string invalidId)
        {
            var mockedScreeningService = new Mock<IFilmScreeningService>();
            var mockedSeatService = new Mock<ISeatService>();

            var actualPaymentPresenter =
                new Presenters.PaymentPresenters.PaymentPresenter(mockedScreeningService.Object, mockedSeatService.Object);

            Assert.That(
                () => actualPaymentPresenter.GetMovieTitleByScreeningId(invalidId),
                Throws.InstanceOf<Exception>());
        }

        [Test]
        public void CallScreeningServiceGetMovieTitleByScreeningIdMethodWithSameParameterId()
        {
            var mockedScreeningService = new Mock<IFilmScreeningService>();
            var mockedSeatService = new Mock<ISeatService>();
            string validId = "1";

            var actualPaymentPresenter =
                new Presenters.PaymentPresenters.PaymentPresenter(mockedScreeningService.Object, mockedSeatService.Object);

            actualPaymentPresenter.GetMovieTitleByScreeningId(validId);

            mockedScreeningService.Verify(
                service => service.GetMovieTitleByScreeningId(validId), Times.Once);
        }
    }
}
