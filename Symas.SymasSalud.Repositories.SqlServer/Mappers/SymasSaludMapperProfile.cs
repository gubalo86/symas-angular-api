using AutoMapper;
using Symas.SymasSalud.Models;
using Symas.SymasSalud.Repositories.SqlServer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Symas.SymasSalud.Repositories.SqlServer.Mappers
{
    public class SymasSaludMapperProfile : Profile
    {
        /*Vieja Version*/
        public SymasSaludMapperProfile()
        {
            //CreateMap<UserModel, UserEntity>()
            //        .ForMember(dest => dest.CredentialsId, opt => opt.Ignore())
            //        .ForMember(dest => dest.AuthenticationHistory, opt => opt.Ignore())
            //        .ForMember(dest => dest.IsRoot, opt => opt.Ignore())
            //        .ForMember(dest => dest.ResetTokens, opt => opt.MapFrom(src => src.ResetTokens))
            //        .ReverseMap();

            //CreateMap<UserRoleModel, UserRoleEntity>()
            //    .ReverseMap();

            CreateMap<ProductModel, ProductEntity>()
                .ReverseMap();
            CreateMap<CatalogModel, CategoryEntity>()
                .ForMember(M => M.Id, x => x.MapFrom(E => E.Id))
                .ForMember(M => M.Category, x => x.MapFrom(E => E.Value))
                .ReverseMap();
        }

        /*Nueva Version*/
        //public SymasSaludMapperProfile()
        //{
        //    new AddressModelMapper().Configure(CreateMap<AddressModel, AccountAddressEntity>());
        //    new DistrictModelMapper().Configure(CreateMap<DistrictModel, SchoolDistrictEntity>());
        //}
    }
}
