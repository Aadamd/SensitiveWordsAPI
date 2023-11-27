using MediatR;

namespace sensitive_words.services.Commands
{
    public class SanitizeStringCommand : IRequest<string>
    {
        public string InputString { get; set; }
    }
}
