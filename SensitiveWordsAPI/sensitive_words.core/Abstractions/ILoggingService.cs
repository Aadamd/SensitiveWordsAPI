namespace sensitive_words.core.Abstractions
{
    public interface ILoggingService
    {
        string GenericErrorMessage { get; }
        bool LogError(string error, Exception e);
        bool LogInfo(string text);
        bool LogWarning(string text);
    }
}
