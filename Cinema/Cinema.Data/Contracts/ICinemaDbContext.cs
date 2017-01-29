using Cinema.Data.Models;
using Cinema.Data.Models.Contracts;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Cinema.Data.Contracts
{
    public interface ICinemaDbContext : IDisposable
    {
        int SaveChanges();

        IDbSet<User> Users { get; set; }

        IDbSet<Movie> Movies { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}
