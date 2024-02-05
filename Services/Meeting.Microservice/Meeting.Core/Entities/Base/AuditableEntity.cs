using Meeting.Core.Entities.Interfaces;

namespace Meeting.Core.Entities.Base;

public abstract class AuditableEntity:BaseEntity, ISoftDeletableEntity
{
	public string? DeletedBy { get; set; }

	public DateTime? DeletedDate { get; set; }
	public DateTime? DateCreated { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
}
