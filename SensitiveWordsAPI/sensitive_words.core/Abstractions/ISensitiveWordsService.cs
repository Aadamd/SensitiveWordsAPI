using System.Globalization;

namespace sensitive_words.core.Abstractions
{
    public interface ISensitiveWordsService
    {
        List<string> GetSensitiveWords();
        string AddSensitiveWord(string word);
        string AddSensitiveWords(List<string> word);
        string DeleteSensitiveWord(int id);
        string UpdateSensitiveWord(int wordId, string updatedWord);
        string SanitizeString(string input);
    }
}
