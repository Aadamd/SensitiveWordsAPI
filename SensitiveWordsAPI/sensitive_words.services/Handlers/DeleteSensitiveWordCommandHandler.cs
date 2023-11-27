using MediatR;
using sensitive_words.core.Abstractions;
using sensitive_words.services.Commands;

namespace sensitive_words.services.Handlers
{
    public class DeleteSensitiveWordCommandHandler : IRequestHandler<DeleteSensitiveWordCommand, string>
    {
        private readonly ISensitiveWordsService _sensitiveWordsService;

        public DeleteSensitiveWordCommandHandler(ISensitiveWordsService sensitiveWordsService)
        {
            _sensitiveWordsService = sensitiveWordsService;
        }

        public Task<string> Handle(DeleteSensitiveWordCommand request, CancellationToken cancellationToken)
        {
            var sensitiveWord = _sensitiveWordsService.DeleteSensitiveWord(request.Id);
            return Task.FromResult(sensitiveWord);
        }
    }
}
