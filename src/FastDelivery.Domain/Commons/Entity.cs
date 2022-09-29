﻿namespace FastDelivery.Domain.Commons;
public abstract class Entity
{
  public Guid Id { get; private set; }

  protected Entity()
  {
    Id = Guid.NewGuid();
  }

  protected abstract void Validate();
}
