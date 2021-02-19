using IRT.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace IRT.Infrastructure.Data
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            #region seed
            modelBuilder.Entity<User>().HasData(
                    new User()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Evaluator",
                        Login = "admin",
                        Email = "admin@instituto.com",
                        //password md5 hash
                        Password = "72ac31325b6faff1720a1f9d4d527c9c" //irt@123
                    }
                );
            #endregion

        }
    }
}
