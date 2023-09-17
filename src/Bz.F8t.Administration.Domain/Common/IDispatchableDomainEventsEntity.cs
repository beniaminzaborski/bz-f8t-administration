namespace Bz.F8t.Administration.Domain.Common;

public interface IDispatchableDomainEventsEntity
{
    IReadOnlyCollection<IDomainEvent> GetDomainEvents();

    public void ClearDomainEvents();
}
