using Framework.Base.Events;

namespace Framework.Base.Entities;

public abstract class BaseAggregateRoot<TId> where TId : IEquatable<TId>
{
    private readonly List<IEvent> _events;

    protected BaseAggregateRoot() => _events = [];

    public TId Id { get; protected set; } = default!;
    public DateTime InsertOn { get; set; }
    public DateTime? UpdateOn { get; set; }
    public int InsertBy { get; set; }
    public int? UpdateBy { get; set; }
    public bool IsActive { get; set; } = true;
    public byte[] RowVersion { get; set; } = null!;

    protected void HandleEvent(IEvent @event)
    {
        SetStateByEvent(@event);
        ValidateInvariants();
        _events.Add(@event);
    }

    protected abstract void SetStateByEvent(IEvent @event);

    public IEnumerable<IEvent> GetEvents()
    {
        return _events.AsEnumerable();
    }

    public void ClearEvents()
    {
        _events.Clear();
    }

    protected abstract void ValidateInvariants();

    public override bool Equals(object? obj)
    {
        if (obj is not BaseAggregateRoot<TId> other)
            return false;

        if (ReferenceEquals(this, other))
            return true;

        if (GetType() != other.GetType())
            return false;

        return Id.Equals(other.Id);
    }

    public static bool operator ==(BaseAggregateRoot<TId> a, BaseAggregateRoot<TId> b)
    {
        if (a is null && b is null)
            return true;

        if (a is null || b is null)
            return false;

        return a.Equals(b);
    }

    public static bool operator !=(BaseAggregateRoot<TId> a, BaseAggregateRoot<TId> b)
    {
        return !(a == b);
    }

    public override int GetHashCode()
    {
        return (GetType().ToString() + Id).GetHashCode();
    }
}
