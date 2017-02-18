using Cinema.Data.Services.Contracts;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Tests.PresentersTests.PaymentPresenters.PaymentPresenter
{
    [TestFixture]
    public class GetBookedSeatsAsStringShould
    {
        [Test]
        public void CallSeatServiceGetBookedSeatsAsStringWithSameParameters()
        {
            var mockedScreeningService = new Mock<IFilmScreeningService>();
            var mockedSeatService = new Mock<ISeatService>();
            string validId = "1";
            string validUsername = "JohnDoe";

            var actualPaymentPresenter =
                new Presenters.PaymentPresenters.PaymentPresenter(mockedScreeningService.Object, mockedSeatService.Object);

            actualPaymentPresenter.GetBookedSeatsAsString(validUsername, validId);

            mockedSeatService.Verify(
                service => service.GetBookedSeatsAsString(validUsername, validId), Times.Once);
        }

        [Test]
        public void ReturnSameValueFromSeatServiceGetBookedSeatsAsString()
        {
            var mockedScreeningService = new Mock<IFilmScreeningService>();
            var mockedSeatService = new Mock<ISeatService>();

            string validId = "1";
            string validUsername = "JohnDoe";
            string expectedString = "Seat1,Seat2";

            mockedSeatService.Setup(
                service => service.GetBookedSeatsAsString(validUsername, validId))
                .Returns(expectedString);

            var actualPaymentPresenter =
                new Presenters.PaymentPresenters.PaymentPresenter(mockedScreeningService.Object, mockedSeatService.Object);

            string actualString = actualPaymentPresenter.GetBookedSeatsAsString(validUsername, validId);

            Assert.AreEqual(expectedString, actualString);
        }
    }
}
