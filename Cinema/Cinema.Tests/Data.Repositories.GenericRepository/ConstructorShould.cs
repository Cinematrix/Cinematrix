using Cinema.Data.Contracts;
using Cinema.Data.Models;
using NUnit.Framework;
using System;

namespace Cinema.Tests.Data.Repositories.GenericRepository
{
    [TestFixture]
    public class ConstructorShould
    {
        [Test]
        public void ThrowWhenParameterDbContextHasNullValue()
        {
            ICinemaDbContext nullContext = null;

            Assert.That(()=>
            new Cinema.Data.Repositories.GenericRepository<Movie>(nullContext),
            Throws.InstanceOf<ArgumentNullException>());
        }
    }
}
