using sensitive_words.core.Abstractions;
using sensitive_words.core.Wrappers;
using System.Data.SqlClient;

namespace sensitive_words.core.Factories
{
    public class SqlConnectionFactory : ISqlConnectionFactory
    {
        private readonly string _connectionString;

        public SqlConnectionFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public ISqlConnection CreateConnection()
        {
            return new SqlConnectionWrapper(_connectionString);
        }
    }
}
