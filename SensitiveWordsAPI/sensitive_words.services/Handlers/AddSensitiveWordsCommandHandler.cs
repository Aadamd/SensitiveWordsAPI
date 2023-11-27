using MediatR;
using sensitive_words.core.Abstractions;
using sensitive_words.services.Commands;

namespace sensitive_words.services.Handlers
{
    public class AddSensitiveWordsCommandHandler : IRequestHandler<AddSensitiveWordsCommand, string>
    {
        private readonly ISensitiveWordsService _sensitiveWordsService;

        public AddSensitiveWordsCommandHandler(ISensitiveWordsService sensitiveWordsService)
        {
            _sensitiveWordsService = sensitiveWordsService;
        }

        public Task<string> Handle(AddSensitiveWordsCommand request, CancellationToken cancellationToken)
        {
            var sensitiveWords = _sensitiveWordsService.AddSensitiveWords(request.Words);
            return Task.FromResult(sensitiveWords);
        }
    }
}
