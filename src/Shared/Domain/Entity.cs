namespace Shared.Domain
{
    public abstract class Entity<T> : IEntity<T>
    {
        public required T Id { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }
        public string? CreatedBy { get; set; } = default!;
        public DateTimeOffset? LastModified { get; set; }
        public string? LastModifiedBy { get; set; } = default!;
    }
}
