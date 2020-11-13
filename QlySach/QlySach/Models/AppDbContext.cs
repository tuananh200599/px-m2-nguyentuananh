using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QlySach.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Book> Books { set; get; }
        public DbSet<Category> Categories { set; get; }
        public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>().HasData(new Category { Id = 1, CategoryName = "Kinh tế" });
            modelBuilder.Entity<Category>().HasData(new Category { Id = 2, CategoryName = "Văn Học" });
            modelBuilder.Entity<Category>().HasData(new Category { Id = 3, CategoryName = "Chính trị" });


            modelBuilder.Entity<Book>().HasData(new Book

            {
                Id = 1,
                Name = "Truyện Kiều",
                Author = "Nguyễn Du",
                ShortContent = "Longtime no see",
                PublicYear = 1696,
                Amount = 20,
                CategoryId = 2,
            });
            modelBuilder.Entity<Book>().HasData(new Book

            {
                Id = 2,
                Name = "Thế Giới Phẳng",
                Author = "Thomas Friedman",
                ShortContent = "Longtime no see",
                PublicYear = 2006,
                Amount = 30,
                CategoryId = 1,
            });
            modelBuilder.Entity<Book>().HasData(new Book

            {
                Id = 3,
                Name = "Chính trị Luận",
                Author = "Aristotle",
                ShortContent = "Longtime no see",
                PublicYear = 1995,
                Amount = 10,
                CategoryId = 3,
            });
        }

    }
}
