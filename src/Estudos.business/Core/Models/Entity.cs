using System;

namespace Estudos.business.Core.Models
{
    public abstract class Entity
    {
        protected Entity()
        {
            Id = new Guid();
        }
        public Guid Id { get; set; }
    }
}
