using AutoMapper;
using Trinder.UserProfile.Application.TrinderUserProfile.Dtos;

namespace Trinder.UserProfile.Application.TrinderUserProfile.Utils;

internal class TrinderFullUserProfileProfile : Profile
{
    public TrinderFullUserProfileProfile()
    {
        CreateMap<Domain.Entities.TrinderUserProfile, ResponseTrinderFullUserProfileDto>()
            .ForMember(m => m.Email, opt => opt.MapFrom(src => src.UserEmail))
            .ReverseMap();
    }
}
