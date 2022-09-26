namespace FastDelivery.Domain.Entities;
internal abstract class Entity {
  protected Guid Id { get; private set; }

  protected Entity () {
    Id = Guid.NewGuid();
  }
}
