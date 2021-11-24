namespace CaesarCypher.UI.Cypher
{
    public interface IAlphabet
    {
        int Length { get; }
        char[] Encrypted { get; }
        char[] Normal { get; }
        bool Contains(char c);
    }
}