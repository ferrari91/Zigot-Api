using FluentValidation;
using MediatR;
using Zigot.Core.Application.CommandStack.PersonCommand.CreateCommand;
using Zigot.Core.Application.CommandStack.PersonCommand.Document.CreateCommand;
using Zigot.Core.Domain.Abstractions;

namespace Zigot_Api.Controllers.Person
{
    public class PersonControllerExtension : ServiceCollectionAbstraction
    {
        public override void AddServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IValidator<PersonCreateRequest>, PersonCreateValidation>();
            services.AddTransient(typeof(IRequestHandler<PersonCreateRequest, PersonCreateResponse>), typeof(PersonCreateCommandHandler));

            services.AddTransient<IValidator<DocumentCreateRequest>, DocumentCreateValidation>();
            services.AddTransient(typeof(IRequestHandler<DocumentCreateRequest, DocumentCreateResponse>), typeof(DocumentCreateCommandHandler));
        }
    }
}
