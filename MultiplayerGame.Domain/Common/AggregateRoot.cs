﻿using CSharpFunctionalExtensions;

namespace MultiplayerGame.Domain.Common
{
    public abstract class AggregateRoot : Entity<Guid>
    {
        private readonly List<DomainEvent> _domainEvents = new();

        public IReadOnlyList<DomainEvent> DomainEvents => _domainEvents.AsReadOnly();

        protected void AddDomainEvent(DomainEvent domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }

        public void ClearDomainEvents()
        {
            _domainEvents.Clear();
        }
    }
}
