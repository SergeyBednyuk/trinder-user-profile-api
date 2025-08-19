using AutoMapper;
using Trinder.UserProfile.Application.TrinderUserProfile.Dtos;
using Trinder.UserProfile.Domain.Entities;

namespace Trinder.UserProfile.Application.TrinderUserProfile.Utils;

public class FotoProfile : Profile
{
    public FotoProfile()
    {
        CreateMap<Foto, ResponseFotoDto>()
            .ReverseMap();
    }
}
