using AutoMapper;
using Meeting.Business.Constants;
using Meeting.Business.Interfaces.Services;
using Meeting.Core.Utilities.Results.Concrete;
using Meeting.Core.Utilities.Results.Interfaces;
using Meeting.Dal.Int.Repositories;
using Meeting.Dtos.MeetingCrudDtos;
using Meeting.Entities.DbSets;

namespace Meeting.Business.Services;

public class MeetingService: IMeetingService
{
    private readonly IMeetingRepository _meetingRepository;
    private readonly IMapper _mapper;

    public MeetingService(IMeetingRepository meetingRepository, IMapper mapper)
    {
        _meetingRepository = meetingRepository;
        _mapper = mapper;
    }

    public async Task<IDataResult<MeetingListDto>> GetByIdAsync(Guid id)
    {
        var meeting = await _meetingRepository.GetByIdAsync(id);
        if (meeting == null)
        {
            return new ErrorDataResult<MeetingListDto>(Messages.MeetingNotFound);
        }
        var meetingDto = _mapper.Map<MeetingListDto>(meeting);
        return new SuccessDataResult<MeetingListDto>(meetingDto, Messages.MeetingFoundSuccess);
    }

    public async Task<IDataResult<List<MeetingListDto>>> GetAllAsync()
    {
        var meetings = await _meetingRepository.GetAllAsync();
        var meetingDtos = _mapper.Map<List<MeetingListDto>>(meetings);
        return new SuccessDataResult<List<MeetingListDto>>(meetingDtos, Messages.MeetingFoundSuccess);
    }

    public async Task<IDataResult<MeetingCreateDto>> AddAsync(MeetingCreateDto meetingCreateDto)
    {
        var hasMeeting = await _meetingRepository.AnyAsync(m => m.MeetingName == meetingCreateDto.MeetingName && m.StartDateTime == meetingCreateDto.StartDateTime);
        if (hasMeeting)
        {
            return new ErrorDataResult<MeetingCreateDto>(Messages.MeetingAlreadyExist);
        }

        var meeting = _mapper.Map<MeetingPlanning>(meetingCreateDto);
        await _meetingRepository.AddAsync(meeting);
        await _meetingRepository.SaveChangesAsync();
        return new SuccessDataResult<MeetingCreateDto>(meetingCreateDto, Messages.MeetingSuccess);
    }

    public async Task<IDataResult<MeetingUpdateDto>> UpdateAsync(MeetingUpdateDto meetingUpdateDto)
    {
        var meeting = await _meetingRepository.GetByIdAsync(meetingUpdateDto.Id);
        if (meeting == null)
        {
            return new ErrorDataResult<MeetingUpdateDto>(Messages.MeetingNotFound);
        }

        _mapper.Map(meetingUpdateDto, meeting);
        await _meetingRepository.UpdateAsync(meeting);
        await _meetingRepository.SaveChangesAsync();
        return new SuccessDataResult<MeetingUpdateDto>(meetingUpdateDto, Messages.MeetingUpdated);
    }

    public async Task<IResult> DeleteAsync(Guid id)
    {
        var meeting = await _meetingRepository.GetByIdAsync(id);
        if (meeting == null)
        {
            return new ErrorResult(Messages.MeetingNotFound);
        }

        await _meetingRepository.DeleteAsync(meeting);
        await _meetingRepository.SaveChangesAsync();
        return new SuccessResult(Messages.MeetingDeleted);
    }
}
