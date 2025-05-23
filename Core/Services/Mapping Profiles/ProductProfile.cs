﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Models;
using Shared;

namespace Services.Mapping_Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.ProductBrand.Name))
                .ForMember(dest => dest.TypeName, opt => opt.MapFrom(src => src.ProductType.Name))
                //.ForMember(dest => dest.PictureUrl, opt => opt.MapFrom(src => $"https://localhost:7260/{src.PictureUrl}"));
                  .ForMember(dest => dest.PictureUrl, opt => opt.MapFrom<PictureUrlResolver>());
                  ;

            CreateMap<ProductBrand, BrandDto>();
            CreateMap<ProductType, TypeDto>();

        }
    }
}
