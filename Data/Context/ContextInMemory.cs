using Data.Mapping;
using Domain.Entities;
using Domain.Entities.DTOResults;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Context
{
    public class ContextInMemory : DbContext
    {
        public ContextInMemory(DbContextOptions<ContextInMemory> options) : base(options)
        {

        }
        public DbSet<Route> Routes { get; set; }
        public DbSet<RankedRouteDTO> RankedRouteDTOs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Route>(new RouteMap().Configure);
            modelBuilder.Entity<RankedRouteDTO>().HasNoKey();
        }
    }
}