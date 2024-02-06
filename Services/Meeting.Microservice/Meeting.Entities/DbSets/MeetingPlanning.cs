using Meeting.Core.Entities.Base;

namespace Meeting.Entities.DbSets;

public class MeetingPlanning:AuditableEntity
{
    public string MeetingName { get; set; }

    public DateTime StartDateTime { get; set; }

    public DateTime FinishDateTime { get; set; }

    public string MeetingDescription { get; set; }

    public string DocumentPath { get; set; }

}

