using AutoMapper;
using Meeting.Dtos.MeetingCrudDtos;
using Meeting.Entities.DbSets;

namespace Meeting.Business.Profiles;

public class MeetingPlanningProfile:Profile
{

    public MeetingPlanningProfile()
    {

        CreateMap<MeetingPlanning, MeetingListDto>()
           .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
           .ForMember(dest => dest.MeetingName, opt => opt.MapFrom(src => src.MeetingName))
           .ForMember(dest => dest.StartDateTime, opt => opt.MapFrom(src => src.StartDateTime))
           .ForMember(dest => dest.FinishDateTime, opt => opt.MapFrom(src => src.FinishDateTime))
           .ForMember(dest => dest.MeetingDescription, opt => opt.MapFrom(src => src.MeetingDescription))
           .ForMember(dest => dest.DocumentPath, opt => opt.MapFrom(src => src.DocumentPath));
        
        CreateMap<MeetingCreateDto, MeetingPlanning>();

        CreateMap<MeetingUpdateDto, MeetingPlanning>();
          
    }



}



