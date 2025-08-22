using AutoMapper;
using Trinder.UserProfile.Application.TrinderUserProfile.Dtos;

namespace Trinder.UserProfile.Application.TrinderUserProfile.Utils;

internal class TrinderUserProfileProfile : Profile
{
    public TrinderUserProfileProfile()
    {
        CreateMap<Domain.Entities.TrinderUserProfile, ResponseTrinderUserProfileDto>()
            .ForMember(m => m.Email, opt => opt.MapFrom(src => src.UserEmail))
            .ReverseMap();
    }
}
