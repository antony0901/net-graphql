using System;

namespace src.Models
{
    public class EntityBase
    {
        public EntityBase()
        {
            Id = Guid.NewGuid();
        }
        
        public Guid Id { get; set; }
    }
}