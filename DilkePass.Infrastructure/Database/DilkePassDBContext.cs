using DilkePass.Application.Users.Interfaces;
using DilkePass.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace DilkePass.Infrastructure.Database
{
    public  class DilkePassDBContext:DbContext, IDilkePassDBContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<ApplicationSettings> ApplicationSettings { get; set; }
        public DbSet<TourAttractions> TourAttractions { get; set; }
        public DbSet<Tourist> Tourists { get; set; }
        //public DbSet<TouristAvailability> TouristAvailabilities { get; set; }
        public DbSet<Price> Prices { get; set; }
        public DbSet<TouristType> TouristTypes { get; set; }
        public DbSet<BookingHead> BookingHead { get; set; }
        public DbSet<BookingLine> BookingLine { get; set; }

        public DilkePassDBContext( DbContextOptions<DilkePassDBContext> options): base(options)
        {                
        }

        //For Transaction and DbContext access in Application layer.
        public async Task<IDbContextTransaction> BeginTransactionAsync(IsolationLevel isolation)
        {
            return await Database.BeginTransactionAsync(isolation);
        }

        // SaveChanges(Cancellation Token  token) . This is default in DbContext. 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TouristType>()
                .HasIndex(t => t.TouristTypeCode)
                .IsUnique();
        }

        
    }
}
    