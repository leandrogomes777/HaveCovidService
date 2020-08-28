using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
                .ToTable("Users");

            modelBuilder.Entity<Users>()
                .HasData(
                    new Users
                    {
                        ID = 1,
                        Email = "leandro@avisa.com.br",
                        Password = "123456",
                        UsersComplement = new UsersComplement()
                        {
                            Name = "Leandro",
                            LastName = "Vasconcellos Gomes",
                            Street = "Rua Retiro",
                            Number = 145,
                            Phone = "55 11 97675-2310",
                            Complement = "182 B",
                            ZipCode = "03073-005"
                        }

                    },
                    new Users
                    {
                        ID = 1,
                        Email = "fabio@avisa.com.br",
                        Password = "123456",
                        UsersComplement = new UsersComplement()
                        {
                            Name = "Fabio",
                            LastName = "Massamitsu",
                            Street = "Rua dois",
                            Number = 15,
                            Phone = "55 11 99999-9999",
                            Complement = "",
                            ZipCode = "03333-005"
                        }
                    },
                    new Users

                    {
                        ID = 1,
                        Email = "deryk@avisa.com.br",
                        Password = "123456",
                        UsersComplement = new UsersComplement()
                        {
                            Name = "Deryk",
                            LastName = "Rossin",
                            Street = "Rua Vinte",
                            Number = 5647,
                            Phone = "55 11 99999-5555",
                            Complement = "B",
                            ZipCode = "14523-555"
                        }
                    }
                );
        }

    }
}
