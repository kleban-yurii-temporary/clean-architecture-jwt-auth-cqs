
using EduTrack.Domain.Common;

public class ToDo : BaseNamedEntity
{
    public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
}