using System;

namespace VigenereLibrary.CryptoTools
{
    public class EncryptionFunctions
    {
        private static CryptoTable CryptoTable = new CryptoTable();
        public string Encrypt(string plainText, string key)
        {
            key = ExtendKey(key, plainText.Length);
            return Encode(plainText.ToUpper(), key.ToUpper());
        }

        public string Decrypt(string encryptedText, string key)
        {
            key = ExtendKey(key, encryptedText.Length);
            return Decode(encryptedText.ToUpper(), key.ToUpper());
        }

        private string Encode(string inputText, string key)
        {
            int textIndex, keyIndex;
            string cryptoText = string.Empty;
            for (int i = 0; i < inputText.Length; i++)
            {
                textIndex = CryptoTable.Alphabet.IndexOf(inputText[i].ToString());
                keyIndex = CryptoTable.Alphabet.IndexOf(key[i].ToString());
                cryptoText += CryptoTable.VigenereTable[keyIndex, textIndex];
            }

            return cryptoText;
        }

        private string Decode(string inputText, string key)
        {
            int rowIndex;
            string decryptoText = string.Empty;
            for (int i = 0; i < inputText.Length; i++)
            {
                rowIndex = CryptoTable.Alphabet.IndexOf(key[i].ToString());
                for (int j = 0; j < CryptoTable.Alphabet.Count; j++)
                {
                    if (CryptoTable.VigenereTable[rowIndex, j] == inputText[i].ToString())
                        decryptoText += CryptoTable.Alphabet[j];
                }
            }

            return decryptoText;
        }

        private string ExtendKey(string key, int pureMessageLength)
        {
            if (key.Length < pureMessageLength)
            {
                var times = Math.Truncate((decimal)(pureMessageLength / key.Length));
                for (int i = 0; i < times; i++)
                    key += key;
            }

            return key;
        }
    }
}
