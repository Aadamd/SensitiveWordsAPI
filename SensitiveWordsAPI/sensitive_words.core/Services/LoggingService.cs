using sensitive_words.core.Abstractions;

namespace sensitive_words.core.Services
{
    public class LoggingService : BaseService, ILoggingService
    {
        private readonly ILogger<LoggingService> _logger;

        public LoggingService(ILogger<LoggingService> logger)
        {
            _logger = logger;
        }

        public bool LogError(string error, Exception e)
        {
            if (string.IsNullOrEmpty(error))
            {
                return false;
            }

            _logger.LogError(e, error);

            return true;
        }

        public bool LogInfo(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return false;
            }

            _logger.LogInformation(text);

            return true;
        }

        public bool LogWarning(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return false;
            }

            _logger.LogWarning(text);

            return true;
        }
    }
}
