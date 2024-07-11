namespace EMS.Domain.Common
{
    public abstract class EntityBase
    {
        public int Id { get; set; }
        public DateTime CreateTime { get; set; } = DateTime.Now;
    }
}
