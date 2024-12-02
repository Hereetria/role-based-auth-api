using AutoMapper;
using IdentityWithJwtTestProject.DtoLayer.Dtos.ProductDtos;
using IdentityWithJwtTestProject.DtoLayer.Dtos.RoleDtos;
using IdentityWithJwtTestProject.DtoLayer.Dtos.UserDtos;
using IdentityWithJwtTestProject.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityWithJwtTestProject.DtoLayer.GeneralMapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping() 
        {
            CreateMap<SignUpUserDto, AppUser>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid().ToString()))
            .ReverseMap();
            CreateMap<LoginUserDto, AppUser>().ReverseMap();

            CreateMap<ResultRolesDto, AppRole>().ReverseMap();
            CreateMap<ResultRoleByIdDto, AppRole>().ReverseMap();
            CreateMap<CreateRoleDto, AppRole>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid().ToString()))
            .ReverseMap();
            CreateMap<UpdateRoleDto, AppRole>().ReverseMap();

            CreateMap<ResultUsersDto, AppUser>().ReverseMap();

            CreateMap<Product, ResultProductDto>().ReverseMap();
            CreateMap<Product, ResultProductByIdDto>().ReverseMap();
            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();
        }
    }
}
