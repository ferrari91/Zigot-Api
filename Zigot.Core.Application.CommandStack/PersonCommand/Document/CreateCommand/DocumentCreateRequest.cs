using MediatR;

namespace Zigot.Core.Application.CommandStack.PersonCommand.Document.CreateCommand
{
    public class DocumentCreateRequest : IRequest<DocumentCreateResponse>
    {
        public long PersonId { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public string IssuingBody { get; set; }
        public string State { get; set; }
        public DateTime IssueDate { get; set; }
        public string ElectoralTitle { get; set; }
    }
}
