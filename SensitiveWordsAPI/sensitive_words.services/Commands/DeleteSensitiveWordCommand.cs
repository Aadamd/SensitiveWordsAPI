using MediatR;

namespace sensitive_words.services.Commands
{
    public class DeleteSensitiveWordCommand : IRequest<string>
    {
        public int Id { get; set; }
    }
}
