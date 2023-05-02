using AutoMapper;
using StacPointTask.BL.Models;
using StecPointTask.Data.DTO;

namespace StacPointTask.BL.Mapping
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<UserDto, UserModel>()
                .ForMember(r => r.FirstName, w=>w.MapFrom(r=>r.FirstName))
                .ForMember(r => r.MiddleName, w => w.MapFrom(r => r.MiddleName))
                .ForMember(r => r.LastName, w => w.MapFrom(r => r.LastName))
                .ForMember(r => r.Email, w => w.MapFrom(r => r.Email))
                .ForMember(r => r.PhoneNumber, w => w.MapFrom(r => r.PhoneNumber))
                .ForMember(r => r.Organization, w => w.MapFrom(r => r.Organization))
                .ReverseMap();

            CreateMap<OrganizationDto, OrganizationModel>()
                .ForMember(r => r.Name, w => w.MapFrom(r => r.Name))
                .ReverseMap();

        }
        
    }
}