﻿using Cinema.Data.Models;
using Cinema.Data.Services.Contracts;
using Moq;
using NUnit.Framework;
using System.Linq;

namespace Cinema.Tests.PresentersTests.FilmScreeningPresenters.GetFilmScreeningsPresenter
{
    [TestFixture]
    public class GetScreeningsByDateShould
    {
        [TestCase("3/08/2017")]
        [TestCase("2/27/2017")]
        public void CallFilmScreeningServiceGetAllScreeningsByDateMethodWithTheSameDate(string validDate)
        {
            var mockedScreeningService = new Mock<IFilmScreeningService>();

            var actualGetFilmScreeningsPresenter =
                new Presenters.FilmScreeningPresenters.GetFilmScreeningsPresenter(mockedScreeningService.Object);

            actualGetFilmScreeningsPresenter.GetScreeningsByDate(validDate);

            mockedScreeningService.Verify(service => service.GetAllScreeningsByDate(validDate), Times.Once);
        }

        [TestCase(null)]
        [TestCase("")]
        public void AllowCallingFilmScreeningServiceGetAllScreeningsByDateMethodWithNullOrEmptyParameters(string nullParameter)
        {
            var mockedScreeningService = new Mock<IFilmScreeningService>();

            var actualGetFilmScreeningsPresenter =
                new Presenters.FilmScreeningPresenters.GetFilmScreeningsPresenter(mockedScreeningService.Object);

            actualGetFilmScreeningsPresenter.GetScreeningsByDate(nullParameter);

            mockedScreeningService.Verify(service => service.GetAllScreeningsByDate(nullParameter), Times.Once);
        }

        [Test]
        public void ReturnIQueryableFilmSCreeningsCollectionWhenIsCalled()
        {
            var mockedScreeningService = new Mock<IFilmScreeningService>();
            string validDate = "3/08/2017";

            var actualGetFilmScreeningsPresenter =
                new Presenters.FilmScreeningPresenters.GetFilmScreeningsPresenter(mockedScreeningService.Object);

            var result = actualGetFilmScreeningsPresenter.GetScreeningsByDate(validDate);

            Assert.That(result, Is.Not.Null.And.InstanceOf<IQueryable<FilmScreening>>());
        }
    }
}
