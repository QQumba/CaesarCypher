namespace CaesarCypher.UI.Cypher
{
    public static class AlphabetExtensions
    {
        public static int ClampIndex(this IAlphabet alphabet, int index)
        {
            if (index < 0)
            {
                return alphabet.Length + index;
            }
            
            return index % alphabet.Length;
        }
    }
}