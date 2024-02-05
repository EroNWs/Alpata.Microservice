using Meeting.Core.Enums;

namespace Meeting.Core.Entities.Interfaces;

public interface IEntity
{
	Guid Id { get; set; }

	Status Status { get; set; }

}
