using System;
using System.Text;

namespace UbiFirstApril
{
    class Program
    {
        static string DecryptCode(string encText, string encKey)
        {
            if (string.IsNullOrWhiteSpace(encText))
                throw new ArgumentException("'Encryption Text' is required.", nameof(encText));

            if (string.IsNullOrWhiteSpace(encKey))
                throw new ArgumentException("'Encryption Key' Value is required.", nameof(encKey));

            int[] charIndicies = Array.ConvertAll(encKey.Split(' '), s => int.Parse(s));

            if (encText.Length != charIndicies.Length)
                throw new ArgumentException("'Encryption Key' length does not match 'Encrypted Text' length.", nameof(encKey));

            StringBuilder decryptedText = new StringBuilder(encText);

            for (int i = 0; i < charIndicies.Length; i++)
                decryptedText[charIndicies[i] - 1] = encText[i];

            return decryptedText.ToString();
        }

        static void Main(string[] args)
        {
            string decryptedCode = null;

            try
            {
                if (args.Length == 1)
                {
                    string helpMessage =
                        "Ubisoft Uplay April Fools \"admin_console\" code decryptor" + Environment.NewLine +
                        new string('-', 60) + Environment.NewLine +
                        "Usage:" + Environment.NewLine +
                        "    UbiFirstApril [encText, encKey | /h]" + Environment.NewLine +
                        "        encText: Encrypted text to decrypt." + Environment.NewLine +
                        "         encKey: Encryption key to decrypt text with." + Environment.NewLine +
                        "             /h: Displays this help message." + Environment.NewLine +
                        Environment.NewLine +
                        "    Using no parameters will prompt for the encrypted text" + Environment.NewLine +
                        "    and encryption key.";

                    Console.WriteLine(helpMessage);
                    Console.WriteLine();

                    Environment.Exit(0);
                }

                else if (args.Length == 2)
                    decryptedCode = DecryptCode(args[0], args[1]);

                else
                {
                    Console.WriteLine("Enter encrypted text:");
                    string encryptedText = Console.ReadLine();
                    Console.WriteLine();

                    Console.WriteLine("Enter encryption key:");
                    string encryptionKey = Console.ReadLine();
                    Console.WriteLine();

                    decryptedCode = DecryptCode(encryptedText, encryptionKey);
                }

                Console.WriteLine("Decrypted Text:");
                Console.WriteLine(decryptedCode);
            }

            catch (Exception ex)
            {
                Console.WriteLine("Unable to decrypt code. Please check your inputs and try again.");
                Console.WriteLine("Error Details:");
                Console.WriteLine(ex.Message.ToString());
            }

            Console.WriteLine();
            Console.Write("Press any key to exit.");
            Console.Read();
        }
    }
}