
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApi.Domain.Entities;
using WebApi.Infrastructure.Data.EntityDbMapping;

namespace WebApi.Infrastructure.Data.Context
{
    public class SqlServerContext :IdentityDbContext<ApplicationUser>
    {
        public DbSet<Department> Department { get; set; }
        public DbSet<Course> Course { get; set; }

        public SqlServerContext(DbContextOptions<SqlServerContext> options) : base(options)
        {
            
        }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
           
            modelBuilder.Entity<Department>(new DepartmentMap().Configure);

            

            ModelBuilderExtensions.Seed(modelBuilder);



        }



    }

    //Data for first time on table
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Department>().HasData(
                new Department
                {
                    Id=1,
                    DepartmentName="IS"
                },
                    new Department   {
                       Id = 2,
                    DepartmentName = "IT"
                }
                );


        }
    }
}
