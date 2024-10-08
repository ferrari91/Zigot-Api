﻿using FluentValidation;
using MediatR;
using Zigot.Core.Application.CommandStack.PersonCommand.CreateCommand;
using Zigot.Core.Domain.Abstractions.Collection;

namespace Zigot_Api.Controllers.Person
{
    public class PersonControllerExtension : ServiceCollectionAbstraction
    {
        public override void AddServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IValidator<PersonCreateRequest>, PersonCreateValidation>();
            services.AddTransient(typeof(IRequestHandler<PersonCreateRequest, PersonCreateResponse>), typeof(PersonCreateCommandHandler));
        }
    }
}
