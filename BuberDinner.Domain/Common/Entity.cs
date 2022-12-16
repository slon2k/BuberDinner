﻿using BuberDinner.Domain.Menu;

namespace BuberDinner.Domain.Common
{
    public abstract class Entity<TId> : IEquatable<Entity<TId>> where TId : notnull 
    {
        public TId Id { get; protected set; }

        protected Entity(TId id)
        {
            Id = id;
        }

        public override bool Equals(object? obj) => obj is Entity<TId> other && Equals(other);

        public static bool operator ==(Entity<TId> left, Entity<TId> right) => Equals(left, right);

        public static bool operator !=(Entity<TId> left, Entity<TId> right) => !Equals(left, right);

        public bool Equals(Entity<TId>? other) => other is not null && other.Id.Equals(Id);

        public override int GetHashCode() => Id.GetHashCode();
    }
}
