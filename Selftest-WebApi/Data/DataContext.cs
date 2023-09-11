using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Selftest_WebApi.Models;

namespace Selftest_WebApi.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options) { }

        public DbSet<Character> Characters { get; set; }

        public DbSet<UserModel> Users { get; set; } 

        public DbSet<SchoolModel> Schools { get; set; } 

        public DbSet<CostumerModel> Costumers { get; set; }

        public DbSet<AnimalModel>Animals { get; set; }

        public  DbSet<BookModel> Books { get; set; }    

        public DbSet<ClientModel> Clients { get; set; } 

        public DbSet<EmployeeModel> Employees{ get; set; }

        public DbSet<PlantsModel> Plants { get; set; }

        public DbSet<StudentModel> Students { get; set; }

        public DbSet<TeacherModel> Teachers { get; set; }

        // User Register Table

        public DbSet<User> User { get; set; }

          
    }
}
