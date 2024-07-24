namespace EMS.Domain.Common
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime CreatedTime { get; set; } = DateTime.UtcNow;
        public DateTime LastModifiedTime { get; set; }
        public bool IsDeleted { get; set; } = false;
        
    }
}
