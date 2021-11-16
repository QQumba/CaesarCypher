namespace CaesarCypher.UI.Cypher
{
    public interface ICypher
    {
        public string Encrypt(string text);
        
        public string Decrypt(string text);
    }
}