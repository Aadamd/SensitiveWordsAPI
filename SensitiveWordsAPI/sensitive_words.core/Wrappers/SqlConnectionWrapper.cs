using sensitive_words.core.Abstractions;
using System.Data;
using System.Data.SqlClient;

namespace sensitive_words.core.Wrappers
{
    public class SqlConnectionWrapper : ISqlConnection, IDisposable
    {
        private readonly SqlConnection _sqlConnection;

        public SqlConnectionWrapper(string connectionString)
        {
            _sqlConnection = new SqlConnection(connectionString);
        }

        public IDbCommand CreateCommand()
        {
            return _sqlConnection.CreateCommand();
        }

        public void Open()
        {
            _sqlConnection.Open();
        }

        public void Close()
        {
            _sqlConnection.Close();
        }

        public void Dispose()
        {
            _sqlConnection.Dispose();
        }
    }
}
