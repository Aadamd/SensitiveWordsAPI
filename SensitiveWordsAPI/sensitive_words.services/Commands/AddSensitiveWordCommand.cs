using MediatR;

namespace sensitive_words.services.Commands
{
    public class AddSensitiveWordCommand : IRequest<string>
    {
        public string Word { get; set; }
    }
}
