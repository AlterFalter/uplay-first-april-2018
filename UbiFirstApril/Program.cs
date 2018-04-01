using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UbiFirstApril
{
    class Program
    {
        static void Main(string[] args)
        {
            bool askForInputsAgain = true;
            while (askForInputsAgain)
            {
                Console.WriteLine("Numbers: ");
                string numbers = Console.ReadLine();
                Console.WriteLine("Voice/Text: ");
                string text = Console.ReadLine();

                try
                {
                    List<int> convertedNumbers = numbers.Split(' ').Where(n => !string.IsNullOrEmpty(n)).Select(n => Convert.ToInt32(n)).ToList();
                    int highestValue = convertedNumbers.Max();
                    string[] sortedText = new string[highestValue + 1];

                    if (convertedNumbers.Count == text.Length)
                    {
                        for (int i = 0; i < convertedNumbers.Count; i++)
                        {
                            string character = text.ElementAt(i).ToString();
                            sortedText[convertedNumbers[i]] = character;
                        }

                        string result = String.Join("", sortedText.Where(s => !string.IsNullOrEmpty(s)));
                        Console.WriteLine("Result: " + result);
                        askForInputsAgain = false;
                    }
                    else
                    {
                        Console.WriteLine($"Your inputs are wrong!\nAmount numbers: {convertedNumbers.Count}\nAmount characters in text: {text.Length}");
                    }
                }
                catch (FormatException ex)
                {
                    Console.WriteLine($"One of your numbers is not a real number!\nException: {ex}");
                }
                catch (OverflowException ex)
                {
                    Console.WriteLine($"You have written a to high number!\nException: {ex}");
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine($"Please check your inputs! Maybe you mistaken the order of the inputs.\nException: {ex}");
                }
                Console.ReadKey();
            }
        }
    }
}
