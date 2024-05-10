using AutoMapper;
using CrudAPI.Core.Application.DTOS.UserTodo;
using CrudAPI.Core.Application.Feature.Commands;
using CrudAPI.Core.Domain.Entities;


namespace CrudAPI.Core.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile() {
            //UserToDo mapping
            CreateMap<UserToDo, UserToDoRequest>()
                .ReverseMap();
          CreateMap<UserToDo, UserToDoResponse>()
                .ReverseMap();

            CreateMap<CreateUserToDoCommand, UserToDo>()
           .ForMember(dest => dest.CreateAt, opt => opt.MapFrom(src => DateTime.Now))
           .ForMember(dest => dest.Status, opt => opt.MapFrom(src => "Pendiente"))
           .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<UpdateUserToDoCommand, UserToDo>()
             .ForMember(dest => dest.CreateAt, opt => opt.MapFrom(src => DateTime.Now))
           .ForMember(dest => dest.Status, opt => opt.MapFrom(src => "Pendiente"));
        }
    }
}
