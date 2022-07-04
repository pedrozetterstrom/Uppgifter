using System;
using System.Text;
using System.Collections.Generic;
using static System.Console;

namespace Hangman
{
    class Program
    {
        static int chances = 10;
        static string path = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "words.txt")).ToUpper();
        static string[] words = path.Split(", ");
        static Random random = new Random();
        static int rndWord = random.Next(0, words.Length);
        static char[] WordChars = words[rndWord].ToCharArray();
        static char[] hiddenChars = new char[WordChars.Length];
        public static StringBuilder letters = new StringBuilder();
        static bool gameOn = false;
        static char guess;

        static void Main(string[] args)
        {
            WriteLine("Welcome to Hangman!\n");
            for (int i = 0; i < hiddenChars.Length; i++)
            {
                hiddenChars[i] = '_';
            }
            bool playing = true;
            while (playing)
            {
                playing = playingGame();
            }
            WriteLine("Thank you for trying Hangman. Bye! :)");
            ReadLine();
        }
        static bool playingGame()
        {
            if (chances == 1)
            {
                Clear();
                WriteLine("That was your last chance. But you are welcome to try again!");
                return false;
            }
            bool result = hiddenChars.Contains('_');
            if (!result)
            {
                Clear();
                WriteLine($"You guessed all the letters in {words[rndWord]}. Congratulations!");
                return false;
            }
            GameState();
            WriteLine($"You have {chances} chance(s) left to guess the word:");
            WriteLine("Choose one option:\n1) Guess a letter.\n2) Guess the word.\n0) Exit game.");
            switch (ReadKey().KeyChar)
            {
                case '1':
                    Clear();
                    GuessLetter();
                    return true;
                case '2':
                    Clear();
                    return GuessWord(); ;
                case '0':
                    Clear();
                    return false;
                default:
                    Clear();
                    return true;
            }

        }
        static void GuessLetter()
        {
            Write("Try guessing a letter: ");
            string g = ReadLine().ToUpper() + " ";
            guess = g[0];
            gameOn = true;
            if (letters.ToString().Contains(guess))
            {
                WriteLine("This letter has already been guessed.\nPress 'Enter' to continue...");
                ReadLine();
            }
            else
            {
                letters.Append(guess);
                checkGuess();
            }
            Clear();
        }
        static bool GuessWord()
        {
            Console.Write("Try guessing the word: ");
            string guessedWord = Console.ReadLine().ToUpper();
            if (guessedWord == words[rndWord])
            {
                Clear();
                Console.WriteLine($"You guessed right! The word was '{words[rndWord]}'. Congratulations!");
                Console.ReadLine();
                return false;
            }
            else
            {
                Console.WriteLine($"You guessed wrong. The word is not '{guessedWord}'.\nPress 'Enter' to continue...");
                Console.ReadLine();
                checkGuess();
                return true;
            }
        }
        static void GameState()
        {
            WriteLine("\nWord Prograssion:\n");
            for (int i = 0; i < hiddenChars.Length; i++)
            {
                Write($"{hiddenChars[i]} ");
            }
            if (gameOn)
            {
                WriteLine("\r\nLetters guessed:\n");
                for (int i = 0; i < letters.Length; i++)
                {
                    Write($"{letters[i]} ");
                }
            }
            

            WriteLine("\r\n");
        }
        static void checkGuess()
        {
            int rightGuess = 0;

            for (int i = 0; i < hiddenChars.Length; i++)
            {
                if (guess == WordChars[i])
                {
                    hiddenChars[i] = guess;
                    rightGuess++;
                }
                Write($"{hiddenChars[i]} ");
            }
            if (rightGuess == 0)
            {
                chances--;
            }
        }
    }
}
