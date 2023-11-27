using sensitive_words.core.Abstractions;
using System.Data;
using System.Data.SqlClient;

namespace sensitive_words.core.Services
{
    public class MSSQLSensitiveWordsRepository : ISensitiveWordsRepository
    {
        private readonly ISqlConnectionFactory _connectionFactory;
        private readonly ILogger<MSSQLSensitiveWordsRepository> _logger;
        public MSSQLSensitiveWordsRepository(ISqlConnectionFactory connectionFactory, ILogger<MSSQLSensitiveWordsRepository> logger)
        {
            _connectionFactory = connectionFactory;
            _logger = logger;
        }

        public string AddSensitiveWord(string word)
        {
            using (ISqlConnection connection = _connectionFactory.CreateConnection())
            {
                try
                {
                    connection.Open();
                    string insertQuery = "INSERT INTO SensitiveWords (Word) VALUES (@Word); SELECT SCOPE_IDENTITY();";
                    using (IDbCommand command = connection.CreateCommand())
                    {
                        command.CommandText = insertQuery;

                        IDbDataParameter wordParameter = command.CreateParameter();
                        wordParameter.ParameterName = "@Word";
                        wordParameter.Value = word;
                        command.Parameters.Add(wordParameter);

                        //Execute query
                        command.ExecuteNonQuery();
                    }
                    return ($"Added sensitive word: {word}");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "An error occurred while processing the request");
                    return ex.Message;
                }
            }
        }

        public string AddSensitiveWords(List<string> words)
        {
            using (ISqlConnection connection = _connectionFactory.CreateConnection())
            {
                try
                {
                    connection.Open();


                    foreach (var word in words)
                    {
                        string insertQuery = "INSERT INTO SensitiveWords (Word) VALUES (@Word); SELECT SCOPE_IDENTITY();";
                        using (IDbCommand command = connection.CreateCommand())
                        {
                            command.CommandText = insertQuery;

                            IDbDataParameter wordParameter = command.CreateParameter();
                            wordParameter.ParameterName = "@Word";
                            wordParameter.Value = word;
                            command.Parameters.Add(wordParameter);

                            //Execute query
                            command.ExecuteNonQuery();
                        } 
                    }
                    return ($"Added sensitive word: {words}");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "An error occurred while processing the request");
                    return ex.Message;
                }
            }
        }

        public string DeleteSensitiveWord(int wordId)
        {
            using (ISqlConnection connection = _connectionFactory.CreateConnection())
            {
                try
                {
                    connection.Open();
                    string deleteQuery = "DELETE FROM SensitiveWords WHERE Id = @WordId;";
                    using (IDbCommand command = connection.CreateCommand())
                    {
                        command.CommandText = deleteQuery;

                        IDbDataParameter wordParameter = command.CreateParameter();
                        wordParameter.ParameterName = "@WordId";
                        wordParameter.Value = wordId;
                        command.Parameters.Add(wordParameter);

                        //Execute query
                        int rowDeleted = command.ExecuteNonQuery();
                        if (rowDeleted > 0)
                        {
                            return ($"Deleted sensitive word with Id: {wordId}");
                        }
                        else
                        {
                            return ($"No sensitive word found with Id: {wordId}");
                        }
                            
                    }
                    
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "An error occurred while processing the request");
                    return ex.Message;
                }
            }
        }

        public List<string> GetSensitiveWords()
        {
            List<string> sensitiveWords = new();

            using (ISqlConnection connection = _connectionFactory.CreateConnection())
            {
                try
                {
                    connection.Open();
                    string selectQuery = "SELECT Word FROM SensitiveWords";
                    using (IDbCommand command = connection.CreateCommand())
                    {
                        command.CommandText = selectQuery;

                        using (IDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string word = reader["Word"].ToString();
                                sensitiveWords.Add(word);
                            }
                        }

                    }
                    return sensitiveWords;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "An error occurred while processing the request");
                    sensitiveWords.Add(ex.Message);
                    return sensitiveWords;
                }
            }
        }

        public string UpdateSensitiveWord(int wordId, string updatedWord)
        {
            using (ISqlConnection connection = _connectionFactory.CreateConnection())
            {
                try
                {
                    connection.Open();
                    string updateQuery = "UPDATE SensitiveWords SET Word = @UpdatedWord WHERE Id = @WordId";
                    using (IDbCommand command = connection.CreateCommand())
                    {
                        command.CommandText = updateQuery;

                        IDbDataParameter wordIdParameter = command.CreateParameter();
                        wordIdParameter.ParameterName = "@WordId";
                        wordIdParameter.Value = wordId;
                        command.Parameters.Add(wordIdParameter);

                        IDbDataParameter updatedWordParameter = command.CreateParameter();
                        updatedWordParameter.ParameterName = "@UpdatedWord";
                        updatedWordParameter.Value = updatedWord;
                        command.Parameters.Add(updatedWordParameter);

                        //Execute query
                        int rowUpdated = command.ExecuteNonQuery();
                        if (rowUpdated > 0)
                        {
                            return ($"Updated sensitive word with Id: {wordId} to: {updatedWord}");
                        }
                        else
                        {
                            return ($"No sensitive word found with Id: {wordId}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "An error occurred while processing the request");
                    return ex.Message;
                }
            }
        }
    }
}
