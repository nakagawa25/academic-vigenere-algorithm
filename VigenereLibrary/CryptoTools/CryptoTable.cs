using System.Collections.Generic;
using System.Linq;

namespace VigenereLibrary.CryptoTools
{
    public class CryptoTable
    {
        private const int letters = 26;
        private static string[,] AlphabetTable { get; set; }
        public List<string> Alphabet { get => new List<string>() { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" }; }

        public string[,] VigenereTable
        {
            get
            {
                if (AlphabetTable == null)
                    CreateCryptoTable();
                return AlphabetTable;
            }
        }

        private void CreateCryptoTable()
        {
            AlphabetTable = new string[letters, letters];
            var alphabet = Alphabet;
            for (int row = 0; row < letters; row++)
            {
                for (int column = 0; column < letters; column++)
                    AlphabetTable[row, column] = SortAlphabet(alphabet);
                SortAlphabet(alphabet);
            }
        }

        private string SortAlphabet(List<string> alphabet)
        {
            var selectedLetter = alphabet.First();
            alphabet.RemoveAt(0);
            alphabet.Add(selectedLetter);

            return selectedLetter;
        }
    }
}
