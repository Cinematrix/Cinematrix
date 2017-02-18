using Cinema.Data.Models;
using Cinema.Data.Services.Contracts;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Cinema.Tests.PresentersTests.PaymentPresenters.PaymentPresenter
{
    [TestFixture]
    public class GetUniqueBookersByScreeningIdShould
    {
        [Test]
        public void CallScreeningServiceGetUniqueBookersByScreeningIdMethodWithSameParameterId()
        {
            var mockedScreeningService = new Mock<IFilmScreeningService>();
            var mockedSeatService = new Mock<ISeatService>();
            string validId = "1";

            var actualPaymentPresenter =
                new Presenters.PaymentPresenters.PaymentPresenter(mockedScreeningService.Object, mockedSeatService.Object);

            actualPaymentPresenter.GetUniqueBookersByScreeningId(validId);

            mockedScreeningService.Verify(
                service => service.GetUniqueBookersFromScreeningById(validId), Times.Once);
        }

        [Test]
        public void ReturnIEnumerableUserCollection()
        {
            var mockedScreeningService = new Mock<IFilmScreeningService>();
            var mockedSeatService = new Mock<ISeatService>();
            string validId = "1";

            var actualPaymentPresenter =
                new Presenters.PaymentPresenters.PaymentPresenter(mockedScreeningService.Object, mockedSeatService.Object);

            var result = actualPaymentPresenter.GetUniqueBookersByScreeningId(validId);

            Assert.That(result, Is.Not.Null.And.InstanceOf<IEnumerable<User>>());
        }
    }
}
