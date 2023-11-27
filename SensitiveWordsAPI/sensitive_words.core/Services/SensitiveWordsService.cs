using sensitive_words.core.Abstractions;

namespace sensitive_words.core.Services
{
    public class SensitiveWordsService : ISensitiveWordsService
    {
        private readonly ISensitiveWordsRepository _repository;

        public SensitiveWordsService(ISensitiveWordsRepository repository)
        {
            _repository = repository;
        }

        public List<string> GetSensitiveWords()
        {
            return _repository.GetSensitiveWords();
        }

        public string AddSensitiveWord(string word)
        {
            return _repository.AddSensitiveWord(word);
        }

        public string AddSensitiveWords(List<string> words)
        {
            return _repository.AddSensitiveWords(words);
        }

        public string DeleteSensitiveWord(int id)
        {
            return _repository.DeleteSensitiveWord(id);
        }
        public string UpdateSensitiveWord(int wordId, string updatedWord)
        {
            return _repository.UpdateSensitiveWord(wordId, updatedWord);
        }
        public string SanitizeString(string input)
        {
            var sensitiveWords = _repository.GetSensitiveWords();

            foreach (var word in sensitiveWords)
            {
                input = input.Replace(word, new String('*', word.Length), StringComparison.OrdinalIgnoreCase);
            }

            return input;
        }
    }
}
