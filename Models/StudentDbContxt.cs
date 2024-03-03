using Microsoft.EntityFrameworkCore;

namespace ReactCrudApplication.Models
{
    public class StudentDbContxt : DbContext
    {
        public StudentDbContxt(DbContextOptions<StudentDbContxt> options) : base(options)
        {
        }

        public DbSet<Student> Students { get;set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.; Initial Catalog=lbs; User Id=pasindu; password=fer1999110814; TrustServerCertificate= True");

        }
    }
}
