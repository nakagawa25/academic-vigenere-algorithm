using System;

namespace VigenereCrypto
{
    class Program
    {
        private static VigenereLibrary.CryptoTools.EncryptionFunctions EncryptionFunctions;
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Escolha uma opção" + Environment.NewLine + "1 - Criptografar" +
                                  Environment.NewLine + "2 - Decriptografar");
                Console.Write("Opção: ");
                var option = Convert.ToInt32(Console.ReadLine());
                EncryptionFunctions = new VigenereLibrary.CryptoTools.EncryptionFunctions();
                switch (option)
                {
                    case 1:
                        ShowEncryptMenu();
                        break;
                    case 2:
                        ShowDecryptMenu();
                        break;
                    default:
                        throw new Exception("Opção Inválida.");
                }
            }
            catch (Exception error)
            {
                Console.WriteLine("Erro na aplicação. Erro: " + error.Message);
            }
            Console.ReadLine();
        }

        private static void ShowEncryptMenu()
        {
            Console.WriteLine("Digite o texto a ser Criptografado: ");
            var plainText = Console.ReadLine();
            Console.WriteLine("Digite a chave: ");
            var key = Console.ReadLine();

            Console.WriteLine("Texto Criptografado: " + EncryptionFunctions.Encrypt(plainText, key));
        }
        private static void ShowDecryptMenu()
        {
            Console.WriteLine("Digite o texto a ser Decriptografado: ");
            var plainText = Console.ReadLine();
            Console.WriteLine("Digite a chave: ");
            var key = Console.ReadLine();

            Console.WriteLine("Texto Decriptografado: " + EncryptionFunctions.Decrypt(plainText, key));
        }
    }
}
