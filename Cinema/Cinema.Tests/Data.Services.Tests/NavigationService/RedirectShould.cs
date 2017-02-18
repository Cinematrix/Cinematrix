using Moq;
using NUnit.Framework;
using System;
using System.Web.UI;

namespace Cinema.Tests.Data.Services.Tests.NavigationService
{
    [TestFixture]
    public class RedirectShould
    {
        [Test]
        public void ThrowWhenParameterPageHasNullValue()
        {
            Page nullPage = null;
            string validUrl = "/MoviesListView";

            var actualNavigationService = new Cinema.Data.Services.NavigationService();
            Assert.That(
                () => actualNavigationService.Redirect(nullPage, validUrl),
                Throws.InstanceOf<ArgumentNullException>());
        }

        [Test]
        public void ThrowWhenParameterUrlHasNullOrEmptyValue()
        {
            var mockedPage = new Mock<Page>();
            string nullUrl = null;

            var actualNavigationService = new Cinema.Data.Services.NavigationService();
            Assert.That(
                () => actualNavigationService.Redirect(mockedPage.Object, nullUrl),
                Throws.InstanceOf<ArgumentNullException>());
        }
    }
}
