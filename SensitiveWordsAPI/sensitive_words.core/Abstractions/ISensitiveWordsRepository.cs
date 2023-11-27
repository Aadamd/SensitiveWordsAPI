namespace sensitive_words.core.Abstractions
{
    public interface ISensitiveWordsRepository
    {
        List<string> GetSensitiveWords();
        string AddSensitiveWord(string word);
        string AddSensitiveWords(List<string> word);
        string DeleteSensitiveWord(int id);
        string UpdateSensitiveWord(int wordId, string updatedWord);
    }
}
