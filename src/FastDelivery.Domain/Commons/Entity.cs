namespace FastDelivery.Domain.Commons;
internal abstract class Entity
{
  protected Guid Id { get; private set; }

  protected Entity()
  {
    Id = Guid.NewGuid();
  }

  protected abstract void Validate();
}
