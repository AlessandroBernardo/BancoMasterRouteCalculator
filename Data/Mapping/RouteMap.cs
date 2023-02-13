using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Data.Mapping
{
    public class RouteMap : IEntityTypeConfiguration<Route>
    {
        public void Configure(EntityTypeBuilder<Route> builder)
        {
            builder.ToTable("Route");
            builder.HasKey(x => x.Id);                

            builder.Property(x => x.Origin)
                   .IsRequired()
                   .HasColumnName("Origin")
                   .HasColumnType("varchar(3)");


            builder.Property(x => x.Destination)
                   .IsRequired()
                   .HasColumnName("Destination")
                   .HasColumnType("varchar(3)");


            builder.Property(x => x.Price)
                   .IsRequired()
                   .HasColumnName("Price")
                   .HasColumnType("decimal(18,2)");

            builder.HasData(
                new Route
                {
                    Id = Guid.NewGuid(),
                    Origin = "GRU",
                    Destination = "BRC",
                    Price = 10
                },
                new Route
                {
                    Id = Guid.NewGuid(),
                    Origin = "BRC",
                    Destination = "SCL",
                    Price = 5
                },
                new Route
                {
                    Id = Guid.NewGuid(),
                    Origin = "GRU",
                    Destination = "CDG",
                    Price = 75
                },
                new Route
                {
                    Id = Guid.NewGuid(),
                    Origin = "GRU",
                    Destination = "SCL",
                    Price = 20
                },
                new Route
                {
                    Id = Guid.NewGuid(),
                    Origin = "GRU",
                    Destination = "ORL",
                    Price = 56
                },
                new Route
                {
                    Id = Guid.NewGuid(),
                    Origin = "ORL",
                    Destination = "CDG",
                    Price = 5
                },
                new Route
                {
                    Id = Guid.NewGuid(),
                    Origin = "SCL",
                    Destination = "ORL",
                    Price = 20
                }
           ); ;
        }
    }
}
