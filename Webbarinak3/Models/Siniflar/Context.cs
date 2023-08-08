using Microsoft.EntityFrameworkCore;

namespace Webbarinak3.Models.Siniflar
{
    public class Context : DbContext //DbContext i context sınıfından miras aldım
    {
        private readonly IConfiguration _config;

        public Context()
        {
        }

        public Context(IConfiguration config)
        {
            _config = config;
        }

        public DbSet<Admin> Admins { get; set; } //Hangi sınıfımı kullanmak istediğimi dbset icine yazıyorum.
        public DbSet<User> Users { get; set; }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<AnimalType> AnimalTypes { get; set; }
        public DbSet<AnimalHealth> AnimalHealths { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Request2> Requests2 { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb; Database=webdb;Trusted_Connection=True;");
        }
    }
}




