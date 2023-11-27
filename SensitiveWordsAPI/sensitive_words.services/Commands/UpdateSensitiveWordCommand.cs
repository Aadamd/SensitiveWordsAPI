using MediatR;

namespace sensitive_words.services.Commands
{
    public class UpdateSensitiveWordCommand : IRequest<string>
    {
        public int wordId { get; set; }
        public string UpdatedWord { get; set; }
    }
}
