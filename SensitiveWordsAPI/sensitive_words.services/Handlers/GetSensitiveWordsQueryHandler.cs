using MediatR;
using sensitive_words.core.Abstractions;
using sensitive_words.services.Queries;

namespace sensitive_words.services.Handlers
{
    public class GetSensitiveWordsQueryHandler : IRequestHandler<GetSensitiveWordsQuery, List<string>>
    {
        private readonly ISensitiveWordsService _sensitiveWordsService;

        public GetSensitiveWordsQueryHandler(ISensitiveWordsService sensitiveWordsService)
        {
            _sensitiveWordsService = sensitiveWordsService;
        }

        public Task<List<string>> Handle(GetSensitiveWordsQuery request, CancellationToken cancellationToken)
        {
            var sensitiveWords = _sensitiveWordsService.GetSensitiveWords();
            return Task.FromResult(sensitiveWords);
        }
    }
}
