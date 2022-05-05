using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebEnacal2.Models
{
    public class dbContextCanino : DbContext
    {
        public dbContextCanino(DbContextOptions<dbContextCanino> options) : base(options)
        {
        }

        public DbSet<Canino> Caninos { get; set; }

        protected override void OnModelCreating(ModelBuilder mB)
        {
            mB.Entity<Canino>(c => {
                c.ToTable("Canino");
                c.HasKey(i => i.Id);

                c.Property(i => i.NombreCanino)
                .IsRequired()
                .HasMaxLength(30)
                .IsUnicode(false);

                c.Property(i => i.Raza)
                .IsRequired()
                .HasMaxLength(30)
                .IsUnicode(false);

                c.Property(i => i.EdadCanina)
                .IsRequired()
                .IsUnicode(false);
            });
        }

    }
}
