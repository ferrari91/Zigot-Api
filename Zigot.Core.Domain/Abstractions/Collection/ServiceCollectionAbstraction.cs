﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Zigot.Core.Domain.Abstractions.Collection
{
    public abstract class ServiceCollectionAbstraction
    {
        public abstract void AddServices(IServiceCollection services, IConfiguration configuration);
    }
}
