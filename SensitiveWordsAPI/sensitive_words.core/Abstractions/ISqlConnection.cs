using System.Data;

namespace sensitive_words.core.Abstractions
{
    public interface ISqlConnection : IDisposable
    {
        IDbCommand CreateCommand();
        void Open();
        void Close();
    }
}
