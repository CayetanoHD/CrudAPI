using CrudAPI.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudAPI.Infrastructure.Persistence.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options): base(options) { }


        public DbSet<UserToDo> userToDo{  get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //fluent API
            modelBuilder.Entity<UserToDo>().ToTable("UserToDo");
            //primaryKey
            modelBuilder.Entity<UserToDo>().HasKey(x => x.Id);

            modelBuilder.Entity<UserToDo>().Property(x => x.TaskDescription).HasMaxLength(100);
        }


    }
}
