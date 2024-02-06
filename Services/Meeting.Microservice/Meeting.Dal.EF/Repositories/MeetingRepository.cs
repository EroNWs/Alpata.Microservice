namespace Meeting.Dal.EF.Repositories;

public class MeetingRepository: EFBaseRepository<MeetingPlanning>, IMeetingRepository
{
    public MeetingRepository(AlpataDbContext context) :base(context) { }

}
