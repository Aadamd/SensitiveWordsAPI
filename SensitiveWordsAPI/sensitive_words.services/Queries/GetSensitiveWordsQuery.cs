using MediatR;
namespace sensitive_words.services.Queries
{
    public class GetSensitiveWordsQuery : IRequest<List<string>>
    {
    }
}
