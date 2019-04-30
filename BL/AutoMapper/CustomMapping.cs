using AutoMapper;
using AutoMapper.QueryableExtensions;
using BL.Dtos;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static DAL.ConstantsAndGlobals.Enums;

namespace BL.AutoMapper
{
    public static class CustomMapping
    {

        public static void MapObjects<TSource, TDestination>()
        {

            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<TSource, TDestination>().ReverseMap();

            });

        }

        public static IMappingExpression<TSource, TDestination> Ignore<TSource, TDestination>(
                    this IMappingExpression<TSource, TDestination> map,
                    params Expression<Func<TDestination, object>>[] selector)
        {

            foreach (var s in selector)
            {
                map.ForMember(s, config => config.Ignore());
            }
            return map;
        }

        public static IQueryable<CustomerDto> MapCustomerObjects(IQueryable<Customer> customers )
        {

            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<DateTime, string>().ConvertUsing(dt => dt.ToLocalTime()
                .ToString("dd-MMM-yyyy"));

                cfg.CreateMap<Customer, CustomerDto>().ForMember(
                                    dest => dest.CustomerTypeName,
                                    opt => opt.MapFrom(src => src.CustomerType.Name) )
                        .ForMember(
                                    dest => dest.GenderName,
                                    opt => opt.MapFrom(src => src.Gender == DepartmentNames.Female? "Female" : "Male"))

                        .ForMember(c => c.CustomerType, opt => opt.Ignore());

            });

            var resDto = customers.ProjectTo<CustomerDto>();

            return resDto;

        }


    }
}
