using Cinema.Data.Services.Contracts;
using Moq;
using NUnit.Framework;

namespace Cinema.Tests.PresentersTests.PaymentPresenters.PaymentPresenter
{
    [TestFixture]
    public class GetUserBookedSeatsCountByScreeningIdShould
    {
        [Test]
        public void CallSeatServiceGetUserBookedSeatsCountByScreeningIdWithSameId()
        {
            var mockedScreeningService = new Mock<IFilmScreeningService>();
            var mockedSeatService = new Mock<ISeatService>();
            string validId = "1";
            string validUsername = "JohnDoe";

            var actualPaymentPresenter =
                new Presenters.PaymentPresenters.PaymentPresenter(mockedScreeningService.Object, mockedSeatService.Object);

            actualPaymentPresenter.GetUserBookedSeatsCountByScreeningId(validUsername, validId);

            mockedSeatService.Verify(service => service.GetUserBookedSeatsCountByScreeningId(validUsername, validId), Times.Once);
        }

        [Test]
        public void ReturnSameValueFromSeatServiceGetUserBookedSeatsCountByScreening()
        {
            var mockedScreeningService = new Mock<IFilmScreeningService>();
            var mockedSeatService = new Mock<ISeatService>();

            string validId = "1";
            string validUsername = "JohnDoe";
            int expectedCount = 5;

            mockedSeatService.Setup(
                service => service.GetUserBookedSeatsCountByScreeningId(validUsername, validId))
                .Returns(expectedCount);

            var actualPaymentPresenter =
                new Presenters.PaymentPresenters.PaymentPresenter(mockedScreeningService.Object, mockedSeatService.Object);

            int actualCount = actualPaymentPresenter.GetUserBookedSeatsCountByScreeningId(validUsername, validId);

            Assert.AreEqual(expectedCount, actualCount);
        }
    }
}
