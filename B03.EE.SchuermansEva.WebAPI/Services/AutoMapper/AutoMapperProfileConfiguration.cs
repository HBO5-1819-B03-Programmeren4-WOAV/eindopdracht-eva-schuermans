using AutoMapper;
using B03.EE.SchuermansEva.Lib.DTO;
using B03.EE.SchuermansEva.Lib.Models;

namespace B03.EE.SchuermansEva.WebAPI.Services.AutoMapper
{
    public class AutoMapperProfileConfiguration : Profile
    {
        public AutoMapperProfileConfiguration() : this("MyProfile")
        {}
        protected AutoMapperProfileConfiguration(string profileName) : base(profileName)
        {
            CreateMap<ActivityBasic, Activity>();
            CreateMap<User, UserBasic>()
                .ForMember(dest => dest.Name,
                           opts => opts.MapFrom(src => $"{src.LastName} {src.FirstName}"));
        }
    }
}
