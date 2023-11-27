using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using sensitive_words.core.Abstractions;
using sensitive_words.core.Services;
using System.Data;
using System.Data.SqlClient;

namespace sensitive_words.tests.Commands
{
    [TestClass]
    public class MSSQLSensitiveWordsRepositoryTests
    {
        private Mock<ISqlConnectionFactory> _mockFactory;
        private Mock<ISqlConnection> _mockConnection;
        private Mock<IDbCommand> _mockCommand;
        private Mock<SqlDataReader> _mockReader;
        private Mock<ILogger<MSSQLSensitiveWordsRepository>> _mockLogger;

        [TestInitialize]
        public void Initialize()
        {
            _mockCommand = new Mock<IDbCommand>();
            _mockFactory = new Mock<ISqlConnectionFactory>();
            _mockConnection = new Mock<ISqlConnection>();
            _mockReader = new Mock<SqlDataReader>();
            _mockLogger = new Mock<ILogger<MSSQLSensitiveWordsRepository>>();
            _mockFactory.Setup(factory => factory.CreateConnection()).Returns(_mockConnection.Object);
            _mockConnection.Setup(conn => conn.CreateCommand()).Returns(_mockCommand.Object);
        }

        [TestMethod]
        public void AddSensitiveWord_ShouldAddWordToDB()
        {
            //Arrange
            var repository = new MSSQLSensitiveWordsRepository(_mockFactory.Object, _mockLogger.Object);

            //Act
            repository.AddSensitiveWord("TestWord");

            //Assert
            _mockConnection.Verify(conn => conn.Open(), Times.Once);
            _mockConnection.Verify(conn => conn.CreateCommand(), Times.Once);
            _mockCommand.VerifySet(command => command.CommandText = "INSERT INTO SensitiveWords (Word) VALUES (@Word); SELECT SCOPE_IDENTITY();", Times.Once);
            _mockConnection.Verify(conn => conn.Dispose(), Times.Once);
        }

        [TestMethod]
        public void DeleteSensitiveWord_ShouldDeleteWordFromDB()
        {
            //Arrange
            var repository = new MSSQLSensitiveWordsRepository(_mockFactory.Object, _mockLogger.Object);

            //Act
            repository.DeleteSensitiveWord(10);

            //Assert
            _mockConnection.Verify(conn => conn.Open(), Times.Once);
            _mockConnection.Verify(conn => conn.CreateCommand(), Times.Once);
            _mockCommand.VerifySet(command => command.CommandText = "DELETE FROM SensitiveWords WHERE Id = @WordId;", Times.Once);
            _mockConnection.Verify(conn => conn.Dispose(), Times.Once);
        }

        [TestMethod]
        public void GetSensitiveWords_ShouldGetWordsFromDB()
        {
            //Arrange
            var repository = new MSSQLSensitiveWordsRepository(_mockFactory.Object, _mockLogger.Object);

            //Act
            var sensitiveWords = repository.GetSensitiveWords();

            //Assert
            _mockConnection.Verify(conn => conn.Open(), Times.Once);
            _mockConnection.Verify(conn => conn.CreateCommand(), Times.Once);
            _mockCommand.VerifySet(command => command.CommandText = "SELECT Word FROM SensitiveWords", Times.Once);
            _mockConnection.Verify(conn => conn.Dispose(), Times.Once);
        }

        [TestMethod]
        public void UpdateSensitiveWord_ShouldUpdateWordFromDB()
        {
            //Arrange
            var repository = new MSSQLSensitiveWordsRepository(_mockFactory.Object, _mockLogger.Object);

            //Act
            repository.UpdateSensitiveWord(10, "TestWord");

            //Assert
            _mockConnection.Verify(conn => conn.Open(), Times.Once);
            _mockConnection.Verify(conn => conn.CreateCommand(), Times.Once);
            _mockCommand.VerifySet(command => command.CommandText = "UPDATE SensitiveWords SET Word = @UpdatedWord WHERE Id = @WordId", Times.Once);
            _mockConnection.Verify(conn => conn.Dispose(), Times.Once);
        }
    }
}
