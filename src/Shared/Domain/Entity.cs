namespace Shared.Domain
{
    public abstract class Entity<T> : IEntity<T>
    {
        public required T Id { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public required string CreatedBy { get; set; }
        public DateTimeOffset ModifiedAt { get; set; }
        public required string ModifiedBy { get; set; }
    }
}
