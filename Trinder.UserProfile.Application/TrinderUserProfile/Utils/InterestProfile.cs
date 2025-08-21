using AutoMapper;
using Trinder.UserProfile.Application.TrinderUserProfile.Dtos;
using Trinder.UserProfile.Domain.Entities;

namespace Trinder.UserProfile.Application.TrinderUserProfile.Utils;

public class InterestProfile : Profile
{
    public InterestProfile()
    {
        CreateMap<Interest, ResponseInterestDto>();

        CreateMap<CreateInterestDto, Interest>();
    }
}
