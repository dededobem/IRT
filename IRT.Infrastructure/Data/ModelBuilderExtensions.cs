using IRT.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
namespace IRT.Infrastructure.Data
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            #region seed
            modelBuilder.Entity<User>().HasData(
                    new User(Guid.NewGuid(), "Evaluator", "admin", "admin@instituto.com", "irt@123")                    
                );
            #endregion

        }
    }
}
