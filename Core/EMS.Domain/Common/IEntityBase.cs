namespace EMS.Domain.Common
{
    public interface IEntityBase
    {
        int Id { get; set; }
        DateTime CreateTime { get; set; }
    }
}