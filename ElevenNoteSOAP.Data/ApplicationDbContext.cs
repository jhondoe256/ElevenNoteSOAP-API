using ElevenNoteSOAP.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNoteSOAP.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options) { }

        public DbSet<NoteEntity> Notes { get; set; }
        public DbSet<CategoryEntity> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CategoryEntity>().HasData(
                new CategoryEntity 
                {
                    Id = 1,
                    Title = "Happly People"
                },
                new CategoryEntity
                {
                    Id = 2,
                    Title = "Sad People"
                },
                new CategoryEntity
                {
                    Id = 3,
                    Title = "Video Games"
                },
                new CategoryEntity
                {
                    Id = 4,
                    Title = "Science Fiction"
                }
                );

            modelBuilder.Entity<NoteEntity>().HasData(
                new NoteEntity 
                {
                    Id = 1,
                    Title = "This is the First Note!",
                    Content= "I'll Be VERY HAPPY if this WORKS!!!!",
                    CategoryEntityId= 1
                });
        }

    }
}
