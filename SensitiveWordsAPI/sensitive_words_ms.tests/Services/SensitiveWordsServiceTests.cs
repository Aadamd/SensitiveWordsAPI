using Moq;
using sensitive_words.core.Abstractions;
using sensitive_words.core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace sensitive_words.tests.Services
{
    [TestClass]
    public class SensitiveWordsServiceTests
    {
        [TestMethod]
        public void GetSensitiveWords_ShouldReturnWords()
        {
            //Arrange
            var mockRepository = new Mock<ISensitiveWordsRepository>();
            var sensitiveWords = new List<string> { "Word1", "Word2" };

            mockRepository.Setup(x => x.GetSensitiveWords()).Returns(sensitiveWords);

            var service = new SensitiveWordsService(mockRepository.Object);

            //Act
            List<string> words = service.GetSensitiveWords();

            //Assert
            CollectionAssert.AreEqual(words, sensitiveWords);
        }

        [TestMethod]
        public void AddSensitiveWord_ShouldCallAddSensitiveWord()
        {
            //Arrange
            var mockRepository = new Mock<ISensitiveWordsRepository>();
            var service = new SensitiveWordsService(mockRepository.Object);
            var sensitiveword = "TestWord";

            //Act
            service.AddSensitiveWord(sensitiveword);

            //Assert
            mockRepository.Verify(repo => repo.AddSensitiveWord(sensitiveword), Times.Once);
        }

        [TestMethod]
        public void AddSensitiveWords_ShouldCallAddSensitiveWords()
        {
            //Arrange
            var mockRepository = new Mock<ISensitiveWordsRepository>();
            var service = new SensitiveWordsService(mockRepository.Object);
            var sensitiveWords = new List<string> { "Word1", "Word2" };

            //Act
            service.AddSensitiveWords(sensitiveWords);

            //Assert
            mockRepository.Verify(repo => repo.AddSensitiveWords(sensitiveWords), Times.Once);
        }

        [TestMethod]
        public void DeleteSensitiveWord_ShouldCallDeleteSensitiveWord()
        {
            //Arrange
            var mockRepository = new Mock<ISensitiveWordsRepository>();
            var service = new SensitiveWordsService(mockRepository.Object);
            var wordId = 0;

            //Act
            service.DeleteSensitiveWord(wordId);

            //Assert
            mockRepository.Verify(repo => repo.DeleteSensitiveWord(wordId), Times.Once);
        }

        [TestMethod]
        public void UpdateSensitiveWord_ShouldCallUpdateSensitiveWord()
        {
            //Arrange
            var mockRepository = new Mock<ISensitiveWordsRepository>();
            var service = new SensitiveWordsService(mockRepository.Object);
            var wordId = 0;
            var sensitiveword = "TestWord";

            //Act
            service.UpdateSensitiveWord(wordId, sensitiveword);

            //Assert
            mockRepository.Verify(repo => repo.UpdateSensitiveWord(wordId, sensitiveword), Times.Once);
        }

        [TestMethod]
        public void SanitizeString_ShouldReturnSanitizeString()
        {
            //Arrange
            var mockRepository = new Mock<ISensitiveWordsRepository>();
            var sensitiveWords = new List<string> { "Word1", "Word2", "TestWord" };
            mockRepository.Setup(x => x.GetSensitiveWords()).Returns(sensitiveWords);

            var service = new SensitiveWordsService(mockRepository.Object);

            //Act
            var sanitizedString = service.SanitizeString("This is a TestWord");

            //Assert
            Assert.AreEqual("This is a ********", sanitizedString);
        }
    }
}
