using Cinema.Data.Services.Contracts;
using Moq;
using NUnit.Framework;

namespace Cinema.Tests.PresentersTests.PaymentPresenters.PaymentPresenter
{
    [TestFixture]
    public class GetPriceShould
    {
        [Test]
        public void CallSeatServiceGetPriceWithSameParameters()
        {
            var mockedScreeningService = new Mock<IFilmScreeningService>();
            var mockedSeatService = new Mock<ISeatService>();
            string validId = "1";
            string validUsername = "JohnDoe";

            var actualPaymentPresenter =
                new Presenters.PaymentPresenters.PaymentPresenter(mockedScreeningService.Object, mockedSeatService.Object);

            actualPaymentPresenter.GetPrice(validUsername, validId);

            mockedSeatService.Verify(
                service => service.GetPrice(validUsername, validId), Times.Once);
        }

        [Test]
        public void ReturnSameValueFromSeatServiceGetPrice()
        {
            var mockedScreeningService = new Mock<IFilmScreeningService>();
            var mockedSeatService = new Mock<ISeatService>();

            string validId = "1";
            string validUsername = "JohnDoe";
            string expectedString = "20";

            mockedSeatService.Setup(
                service => service.GetPrice(validUsername, validId))
                .Returns(expectedString);

            var actualPaymentPresenter =
                new Presenters.PaymentPresenters.PaymentPresenter(mockedScreeningService.Object, mockedSeatService.Object);

            string actualString = actualPaymentPresenter.GetPrice(validUsername, validId);

            Assert.AreEqual(expectedString, actualString);
        }
    }
}
