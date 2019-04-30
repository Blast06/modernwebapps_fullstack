using FluentValidator;
using System;

namespace ModernStore.Shared.Entities
{
    public abstract class Entity : Notifiable
    {
        protected Entity()
        {
            Id = new Guid();
            CreatedBy = Id;
            CreatedIn = DateTime.Now;
            UpdatedBy = Id;
            UpdatedIn = DateTime.Now;
        }

        public Guid Id { get; private set; }
        public DateTime CreatedIn { get; private set; }
        public Guid CreatedBy { get; private set; }
        public DateTime UpdatedIn { get; private set; }
        public Guid UpdatedBy { get; private set; }
    }
}