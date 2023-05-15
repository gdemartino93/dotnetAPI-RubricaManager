using AutoMapper;
using dotnetAPI_Rubrica.Models;
using dotnetAPI_Rubrica.Models.DTO;

namespace dotnetAPI_Rubrica
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<ApplicationUser,UserDTO>().ReverseMap();
            CreateMap<Contact, ContactCreateDTO>().ReverseMap();
            CreateMap<Contact, ContactEditDTO>().ReverseMap();
            CreateMap<ContactDTO, Contact>().ReverseMap();
        }
    }
}
