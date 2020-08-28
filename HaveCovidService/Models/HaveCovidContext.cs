using Microsoft.EntityFrameworkCore;

namespace HaveCovidService.Models
{
    public class HaveCovidContext : DbContext
    {
        public HaveCovidContext(DbContextOptions<HaveCovidContext> options)
                : base(options)
        {
        }

        public DbSet<Users> UsersItems { get; set; }
        public DbSet<WithCovidReport> WithCovidReportItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>()
                .OwnsOne(x => x.UsersComplement)
                .ToTable("Users");

            modelBuilder.Entity<Users>(b =>
            {
                b.HasData(new Users
                {
                    ID = 1,
                    Email = "leandro@avisa.com.br",
                    Password = "123456"
                });
                b.OwnsOne(e => e.UsersComplement).HasData(new
                {
                    ID = 1L,
                    UsersID = 1L,
                    Name = "Leandro",
                    LastName = "Vasconcellos Gomes",
                    Street = "Rua Retiro",
                    Number = 145,
                    Phone = "55 11 97675-2310",
                    Complement = "182 B",
                    ZipCode = "03073-005"
                });

                //b.HasData(new Users
                //{
                //    ID = 2,
                //    Email = "fabio@avisa.com.br",
                //    Password = "123456",
                //});
                //b.OwnsOne(e => e.UsersComplement).HasData(new
                //{
                //    ID = 2,
                //    UsersID = 2,
                //    Name = "Fabio",
                //    LastName = "Massamitsu",
                //    Street = "Rua dois",
                //    Number = 15,
                //    Phone = "55 11 99999-9999",
                //    Complement = "",
                //    ZipCode = "03333-005"
                //});


                //b.HasData(new Users
                //{
                //    ID = 3,
                //    Email = "leandro@avisa.com.br",
                //    Password = "123456"
                //    // more properties of User
                //});
                //b.OwnsOne(e => e.UsersComplement).HasData(new
                //{
                //    ID = 3,
                //    UsersID = 3,
                //    Name = "Leandro",
                //    LastName = "Vasconcellos Gomes",
                //    Street = "Rua Retiro",
                //    Number = 145,
                //    Phone = "55 11 97675-2310",
                //    Complement = "182 B",
                //    ZipCode = "03073-005"
                //});
            });


    }

}
}
