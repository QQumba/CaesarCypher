using CaesarCypher.UI.Cypher;
using NUnit.Framework;

namespace CaesarCypher.Test
{
    [TestFixture]
    public class KeyCypherTests
    {
        private ICypher _cypher;
        
        [SetUp]
        public void KeyCypherTestSetUp()
        {
            _cypher = new KeyCypher(12);
        }
        
        
    }
}