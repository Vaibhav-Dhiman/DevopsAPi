using System;
using System.Collections.Generic;
using System.Text;
using BooksApi.BusinessEntity.Entity;
using Microsoft.EntityFrameworkCore;

namespace BusinessEntity.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Book> Books { get; set; }
    }
}
