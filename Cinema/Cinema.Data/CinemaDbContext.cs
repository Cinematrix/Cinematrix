using Cinema.Data.Contracts;
using Cinema.Data.Models;
using Cinema.Data.Models.Contracts;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Data
{
    public class CinemaDbContext : IdentityDbContext<User>, ICinemaDbContext
    {
        public CinemaDbContext()
            : base("DefaultConnection")
        {
        }

        public IDbSet<Movie> Movies { get; set; }

        public IDbSet<FilmScreening> Screenings { get; set; }

        public IDbSet<Seat> Seats { get; set; }

        public static CinemaDbContext Create()
        {
            return new CinemaDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
