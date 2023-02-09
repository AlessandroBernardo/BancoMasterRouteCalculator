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

            builder.HasData(
                new Route
                {
                    Origin = "GRU",
                    Destination = "BRC",
                    Value = 10
                },
                new Route
                {
                    Origin = "BRC",
                    Destination = "SCL",
                    Value = 5
                },
                new Route
                {
                    Origin = "GRU",
                    Destination = "CDG",
                    Value = 75
                },
                new Route
                {
                    Origin = "GRU",
                    Destination = "SCL",
                    Value = 20
                },
                new Route
                {
                    Origin = "GRU",
                    Destination = "ORL",
                    Value = 56
                },
                new Route
                {
                    Origin = "ORL",
                    Destination = "CDG",
                    Value = 5
                },
                new Route
                {
                    Origin = "SCL",
                    Destination = "ORL",
                    Value = 20
                }
           );
        }
    }
}
