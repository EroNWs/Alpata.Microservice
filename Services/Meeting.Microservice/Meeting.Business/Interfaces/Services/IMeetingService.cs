using Meeting.Core.Utilities.Results.Interfaces;
using Meeting.Dtos.MeetingCrudDtos;

namespace Meeting.Business.Interfaces.Services;

public interface IMeetingService
{
    Task<IDataResult<MeetingListDto>> GetByIdAsync(Guid id);
    Task<IDataResult<List<MeetingListDto>>> GetAllAsync();
    Task<IDataResult<MeetingCreateDto>> AddAsync(MeetingCreateDto meetingCreateDto);
    Task<IDataResult<MeetingUpdateDto>> UpdateAsync(MeetingUpdateDto meetingUpdateDto);
    Task<IResult> DeleteAsync(Guid id);


}
