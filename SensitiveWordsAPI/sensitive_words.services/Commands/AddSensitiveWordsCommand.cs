using MediatR;

namespace sensitive_words.services.Commands
{
    public class AddSensitiveWordsCommand : IRequest<string>
    {
        public List<string> Words { get; set; }
    }
}
