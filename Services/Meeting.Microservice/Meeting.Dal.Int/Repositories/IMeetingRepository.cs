using Meeting.Core.DataAccess.Interfaces;
using Meeting.Entities.DbSets;

namespace Meeting.Dal.Int.Repositories;

internal interface IMeetingRepository : IAsyncRepository, 
    IAsyncInsertableRepository<MeetingPlanning>, 
    IAsyncFindableRepository<MeetingPlanning>, 
    IAsyncDeleteableRepository<MeetingPlanning>,
    IAsyncUpdateableRepository<MeetingPlanning>, 
    IAsyncTransactionRepository
{
}


