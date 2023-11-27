using MediatR;
using sensitive_words.core.Abstractions;
using sensitive_words.services.Commands;

namespace sensitive_words.services.Handlers
{
    public class SanitizeStringCommandHandler : IRequestHandler<SanitizeStringCommand, string>
    {
        private readonly ISensitiveWordsService _sensitiveWordsService;

        public SanitizeStringCommandHandler(ISensitiveWordsService sensitiveWordsService)
        {
            _sensitiveWordsService = sensitiveWordsService;
        }

        public Task<string> Handle(SanitizeStringCommand request, CancellationToken cancellationToken)
        {
            var sanitizedString = _sensitiveWordsService.SanitizeString(request.InputString);
            return Task.FromResult(sanitizedString);
        }
    }
}
