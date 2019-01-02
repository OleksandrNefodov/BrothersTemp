using System;
using System.Data.Entity;

namespace Brothers.Common.Models.Context
{
    public class BrothersContext : DbContext, IDisposable
    {
        public BrothersContext() 
        : base("BrothersContext")
        {
        }

        public DbSet<Photo> Photos { get; set; }

        public DbSet<Video> Videos { get; set; }

        public DbSet<Album> Albums { get; set; }
    }
}