namespace Palyio.Domain;

public abstract record Entity
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; init; }
    public bool Active { get; init; } = true;

    protected Entity(Guid? id = null,
                     DateTime? createdAt = null,
                     DateTime? updatedAt = null)
    {
        Id = id ?? Guid.NewGuid();
        CreatedAt = createdAt ?? DateTime.UtcNow;
        UpdatedAt = updatedAt;
    }
}