namespace EMS.Domain.Common
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime CreateTime { get; set; } = DateTime.UtcNow;
        public DateTime LastModified { get; set; }
        public bool IsDeleted { get; set; } = false;
        
    }
}
