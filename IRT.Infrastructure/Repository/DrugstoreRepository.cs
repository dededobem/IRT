using IRT.Domain.Entities;
using IRT.Domain.Interfaces;
using IRT.Infrastructure.Data;
using IRT.Infrastructure.Repository.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace IRT.Infrastructure.Repository
{
    public class DrugstoreRepository : Repository<Drugstore>, IDrugstoreRepository
    {
        private readonly IRTDbContext _dbContext;

        public DrugstoreRepository(IRTDbContext context) : base(context)
        {
            _dbContext = context;
        }
    }
}
