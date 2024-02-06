namespace Meeting.Dal.Int.Repositories;

public interface IMeetingRepository : IAsyncRepository, 
    IAsyncInsertableRepository<MeetingPlanning>, 
    IAsyncFindableRepository<MeetingPlanning>, 
    IAsyncDeleteableRepository<MeetingPlanning>,
    IAsyncUpdateableRepository<MeetingPlanning>, 
    IAsyncTransactionRepository
{
}


