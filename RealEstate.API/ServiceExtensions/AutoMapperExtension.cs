﻿namespace RealEstate.API.ServiceExtensions
{
    public static class AutoMapperExtension
    {
        public static IServiceCollection AddAutoMapper(this IServiceCollection services)
        {
            // Add AutoMapper.
            services.AddAutoMapper(typeof(Program));

            return services;
        }
    }
}
