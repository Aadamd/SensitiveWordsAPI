using MediatR;
using sensitive_words.core.Abstractions;
using sensitive_words.core.Services;
using sensitive_words.services.Commands;

namespace sensitive_words.services.Handlers
{
    public class UpdateSensitiveWordCommandHandler : IRequestHandler<UpdateSensitiveWordCommand, string>
    {
        private readonly ISensitiveWordsService _sensitiveWordsService;

        public UpdateSensitiveWordCommandHandler(ISensitiveWordsService sensitiveWordsService)
        {
            _sensitiveWordsService = sensitiveWordsService;
        }

        public Task<string> Handle(UpdateSensitiveWordCommand request, CancellationToken cancellationToken)
        {
            var sensitiveWord = _sensitiveWordsService.UpdateSensitiveWord(request.wordId, request.UpdatedWord);
            return Task.FromResult(sensitiveWord);
        }
    }
}
