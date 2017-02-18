using Cinema.Data.Models;
using Cinema.Data.Services.Contracts;
using Moq;
using NUnit.Framework;
using System.Linq;

namespace Cinema.Tests.PresentersTests.PaymentPresenters.PaymentPresenter
{
    [TestFixture]
    public class GetAllFutureScreeningsShould
    {
        [Test]
        public void CallScreeningServiceGetAllFutureScreeningsMethod()
        {
            var mockedScreeningService = new Mock<IFilmScreeningService>();
            var mockedSeatService = new Mock<ISeatService>();

            var actualPaymentPresenter =
                new Presenters.PaymentPresenters.PaymentPresenter(mockedScreeningService.Object, mockedSeatService.Object);

            actualPaymentPresenter.GetAllFutureScreenings();

            mockedScreeningService.Verify(service => service.GetAllFutureScreenings(), Times.Once);
        }

        [Test]
        public void ReturnIQueryableFilmScreeningCollection()
        {
            var mockedScreeningService = new Mock<IFilmScreeningService>();
            var mockedSeatService = new Mock<ISeatService>();

            var actualPaymentPresenter =
                new Presenters.PaymentPresenters.PaymentPresenter(mockedScreeningService.Object, mockedSeatService.Object);

            var result = actualPaymentPresenter.GetAllFutureScreenings();

            Assert.That(result, Is.Not.Null.And.InstanceOf<IQueryable<FilmScreening>>());
        }
    }
}