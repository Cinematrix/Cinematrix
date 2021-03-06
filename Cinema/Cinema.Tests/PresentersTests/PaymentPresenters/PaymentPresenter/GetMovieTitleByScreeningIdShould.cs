﻿using Cinema.Data.Services.Contracts;
using Moq;
using NUnit.Framework;

namespace Cinema.Tests.PresentersTests.PaymentPresenters.PaymentPresenter
{
    [TestFixture]
    public class GetMovieTitleByScreeningIdShould
    {
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

        [Test]
        public void ReturnSameValueFromScreeningServiceGetMovieTitleByScreeningId()
        {
            var mockedScreeningService = new Mock<IFilmScreeningService>();
            var mockedSeatService = new Mock<ISeatService>();

            string validId = "1";
            string expectedTitle = "Batman";

            mockedScreeningService.Setup(
                service => service.GetMovieTitleByScreeningId(validId))
                .Returns(expectedTitle);

            var actualPaymentPresenter =
                new Presenters.PaymentPresenters.PaymentPresenter(mockedScreeningService.Object, mockedSeatService.Object);

            string actualCount = actualPaymentPresenter.GetMovieTitleByScreeningId(validId);

            Assert.AreEqual(expectedTitle, actualCount);
        }
    }
}
