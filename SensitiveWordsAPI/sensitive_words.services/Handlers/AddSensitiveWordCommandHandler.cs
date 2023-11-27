using MediatR;
using sensitive_words.core.Abstractions;
using sensitive_words.services.Commands;

namespace sensitive_words.services.Handlers
{
    public class AddSensitiveWordCommandHandler : IRequestHandler<AddSensitiveWordCommand, string>
    {
        private readonly ISensitiveWordsService _sensitiveWordsService;

        public AddSensitiveWordCommandHandler(ISensitiveWordsService sensitiveWordsService)
        {
            _sensitiveWordsService = sensitiveWordsService;
        }

        public Task<string> Handle(AddSensitiveWordCommand request, CancellationToken cancellationToken)
        {
            var sensitiveWord = _sensitiveWordsService.AddSensitiveWord(request.Word);
            return Task.FromResult(sensitiveWord);
        }
    }
}
