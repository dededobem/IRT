using System;

namespace IRT.Domain.Entities
{
    public abstract class EntityBase
    {
        protected EntityBase() { }
        public EntityBase(Guid id) => Id = id;
        public Guid Id { get; private set; }
    }
}
