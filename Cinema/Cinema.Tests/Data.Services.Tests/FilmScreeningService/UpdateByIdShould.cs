using Cinema.Data.Models;
using Cinema.Data.Repositories;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Tests.Data.Services.Tests.FilmScreeningService
{
    [TestFixture]
    public class UpdateByIdShould
    {
        [Test]
        public void ThrowWhenParameterIdHasNullOrEmptyValue()
        {
            var mockedScreeningRepo = new Mock<IRepository<FilmScreening>>();
            var mockedFilmSCreening = new Mock<FilmScreening>();
            string nullId = null;

            var actualFilmSCreeningService =
                new Cinema.Data.Services.FilmScreeningService(mockedScreeningRepo.Object, mockedFilmSCreening.Object);

            Assert.That(() => actualFilmSCreeningService.UpdateById(nullId, mockedFilmSCreening.Object),
                Throws.InstanceOf<ArgumentNullException>());
        }

        [Test]
        public void ThrowWhenParameterFilmScreeningToUpdateHasNullOrEmptyValue()
        {
            var mockedScreeningRepo = new Mock<IRepository<FilmScreening>>();
            var mockedFilmSCreening = new Mock<FilmScreening>();
            FilmScreening nullFilmScreening = null;
            string id = "1";

            var actualFilmSCreeningService =
                new Cinema.Data.Services.FilmScreeningService(mockedScreeningRepo.Object, mockedFilmSCreening.Object);

            Assert.That(() => actualFilmSCreeningService.UpdateById(id, nullFilmScreening),
                Throws.InstanceOf<ArgumentNullException>());
        }

        [Test]
        public void CallFilmScreeningRepoGetByIdMethodWithPassedId()
        {
            var mockedScreeningRepo = new Mock<IRepository<FilmScreening>>();
            var mockedFilmSCreening = new Mock<FilmScreening>();
            string id = "1";

            var actualFilmSCreeningService =
                new Cinema.Data.Services.FilmScreeningService(mockedScreeningRepo.Object, mockedFilmSCreening.Object);

            actualFilmSCreeningService.UpdateById(id, mockedFilmSCreening.Object);

            mockedScreeningRepo.Verify(service => service.GetById(int.Parse(id)), Times.Once);
        }

        [Test]
        public void CallFilmScreeningRepoUpdateMethodPassingCorrectFilmScreening()
        {
            var mockedScreeningRepo = new Mock<IRepository<FilmScreening>>();
            var mockedFilmSCreening = new Mock<FilmScreening>();
            var targetScreening = new FilmScreening();
            string id = "1";

            mockedScreeningRepo.Setup(x => x.GetById(int.Parse(id))).Returns(targetScreening);

            var actualFilmSCreeningService =
                new Cinema.Data.Services.FilmScreeningService(mockedScreeningRepo.Object, mockedFilmSCreening.Object);

            actualFilmSCreeningService.UpdateById(id, targetScreening);

            mockedScreeningRepo.Verify(service => service.Update(targetScreening), Times.Once);
        }

        [Test]
        public void CallFilmScreeningRepoSaveChangesMethod()
        {
            var mockedScreeningRepo = new Mock<IRepository<FilmScreening>>();
            var mockedFilmSCreening = new Mock<FilmScreening>();
            string id = "1";

            var actualFilmSCreeningService =
                new Cinema.Data.Services.FilmScreeningService(mockedScreeningRepo.Object, mockedFilmSCreening.Object);

            actualFilmSCreeningService.UpdateById(id, mockedFilmSCreening.Object);

            mockedScreeningRepo.Verify(service => service.SaveChanges(), Times.Once);
        }
    }
}
