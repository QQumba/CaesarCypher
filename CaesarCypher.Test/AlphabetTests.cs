using CaesarCypher.UI.Cypher;
using NUnit.Framework;

namespace CaesarCypher.Test
{
    [TestFixture]
    public class AlphabetTests
    {
        private IAlphabet _alphabet;
        
        [SetUp]
        public void AlphabetTestSetup()
        {
            _alphabet = new Alphabet(12);
        }
        
        [Test]
        public void Contains_ReturnsTrue_WhenCyrillicLetterPassed([Values('а','ё','ж','я')] char letter)
        {
            var contains = _alphabet.Contains(letter);
            Assert.True(contains);
        }
        
        [Test]
        public void Contains_ReturnsFalse_WhenNonCyrillicLetterPassed([Values('a','b','c','t')] char letter)
        {
            var contains = _alphabet.Contains(letter);
            Assert.False(contains);
        }
        
        [Test]
        public void Contains_ReturnsFalse_WhenNonLetterPassed([Values('3','-','+','!')] char letter)
        {
            var contains = _alphabet.Contains(letter);
            Assert.False(contains);
        }
    }
}