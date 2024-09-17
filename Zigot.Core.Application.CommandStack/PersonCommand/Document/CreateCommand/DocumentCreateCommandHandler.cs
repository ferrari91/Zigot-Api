using MediatR;

namespace Zigot.Core.Application.CommandStack.PersonCommand.Document.CreateCommand
{
    public class DocumentCreateCommandHandler : IRequestHandler<DocumentCreateRequest, DocumentCreateResponse>
    {
        public async Task<DocumentCreateResponse> Handle(DocumentCreateRequest request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            return new DocumentCreateResponse();
        }
    }
}
