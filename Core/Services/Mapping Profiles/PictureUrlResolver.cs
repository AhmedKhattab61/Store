using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Models;
using Microsoft.Extensions.Configuration;
using Shared;

namespace Services.Mapping_Profiles
{
    public class PictureUrlResolver(IConfiguration configuration) : IValueResolver<Product, ProductDto, string>
    {
        public string Resolve(Product source, ProductDto destination, string destMember, ResolutionContext context)
        {
            if (string.IsNullOrEmpty(source.PictureUrl))
                return string.Empty;

            return $"{configuration["BaseUrl"]}/{source.PictureUrl}";
        }
    }
}
