﻿using Cinema.Data.Contracts;
using Cinema.Data.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Data
{
    public class CinemaDbContext : IdentityDbContext<User>, ICinemaDbContext
    {
        public CinemaDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public IDbSet<Movie> Movies { get; set; }

        public static CinemaDbContext Create()
        {
            return new CinemaDbContext();
        }
    }
}
