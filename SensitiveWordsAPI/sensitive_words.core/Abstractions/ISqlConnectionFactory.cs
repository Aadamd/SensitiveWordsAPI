using System.Data.SqlClient;

namespace sensitive_words.core.Abstractions
{
    public interface ISqlConnectionFactory
    {
        ISqlConnection CreateConnection();
    }
}
