using AutoMapper;
using Application.Features.SQL;
using Domain.Auth;
using Domain.Entities;

namespace Application.MappingProfiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<SQLObject, GetSQLResponse>().ReverseMap();
    }  
}