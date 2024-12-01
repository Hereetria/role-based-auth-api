using AutoMapper;
using IdentityWithJwtTestProject.DtoLayer.Dtos.ProductDtos;
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


            CreateMap<Product, ResultProductDto>().ReverseMap();
            CreateMap<Product, ResultProductByIdDto>().ReverseMap();
            CreateMap<CreateProductDto, Product>().ReverseMap();
            CreateMap<UpdateProductDto, Product>().ReverseMap();
        }
    }
}
