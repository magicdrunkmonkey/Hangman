using System;
using System.Collections.Generic;
using System.Text;

namespace Hangman
{
    class Program
    {
        static void Main(string[] args)
        {
            //Declare variables
            bool keepLooping = true;
            while (keepLooping)
            {
                //char[] arrGuessWord;  
                char[] arrTestWord;    //Progress on guess word
                char[] arrSecretWord = SecretWordList.SecretWord().ToCharArray();   //Convert "secretWord" to char array

                string guessWord;
                char guessChar = '0';
                string secretWord = new string(arrSecretWord);
                int guessCount = 0, guessLimit = 10;

                bool trigger = true, trigger2 = true;
                bool right = false;

                //Count letters "secretWord"
                int wordLength = MyCodeTools.CountChar(arrSecretWord);
                arrTestWord = new char[wordLength];

                //Build string on wrong guessed chars
                StringBuilder wrongGuessedChar = new StringBuilder("", wordLength);

                //Prepare "guessWord"
                //arrGuessWord = arrSecretWord;            

                //Prepare "testWord"
                string tempString = "";
                for (int i = 0; i < wordLength; i++)
                {
                    tempString = tempString.Insert(i, "_");
                }
                arrTestWord = tempString.ToCharArray();

                //Show secret word
                /*
                Console.Write("Secret word is ");
                foreach(char items in arrSecretWord)
                {
                    Console.Write(items);
                }
                Console.WriteLine();
                */

                //Playing the game
                

                for (int i = 0; i < guessLimit; i++)
                {
                    char[] copy = arrSecretWord;
                    

                    //Input a guess
                    Console.Write("Please enter a letter or a swedish word to guess: "); 
                    guessWord = Console.ReadLine().ToUpper();
                    Console.Clear();
                    Console.WriteLine("You guessed: "+guessWord);

                    if (guessWord.Length > 1)
                    {
                        if (guessWord == secretWord)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("\nGuessed correct!");
                            Console.ResetColor();
                            i = guessLimit;
                            trigger2 = false;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Wrong word!");
                            Console.ResetColor();
                            guessCount++;
                        }
                    }
                    else if (guessWord.Length == 1)
                    {

                        guessChar = char.Parse(guessWord);
                        string temp = wrongGuessedChar.ToString();

                        if (temp.Contains(guessChar))
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("\nAlready guessed!");
                            Console.ResetColor();
                            trigger = false;
                            i--;
                        }
                        else
                        {

                            for (int j = 0; j < copy.Length; j++)
                            {
                                if (copy[j] == guessChar)
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("\nYour guess is correct.");
                                    Console.ResetColor();
                                    arrTestWord[j] = guessChar;
                                    right = true;

                                }
                            }
                        }
                    }

                    //If guessed wrong, add char to "wrongGuessedChar"
                    if (right != true && trigger2 == true)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nYour guess is incorrect.");
                        Console.ResetColor();
                        if (trigger)         //True if wrong char has not been used
                        {
                            wrongGuessedChar.Append(guessChar);
                            guessCount++;
                        }
                        trigger = true;
                    }
                    else if (right && trigger2)
                    {
                        i--;
                        right = false;
                    }

                    //Guess counting
                    if (guessCount > 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Wronguessed {0} of {1}", guessCount, guessLimit);
                        Console.ResetColor();
                    }

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("Correct chars so far: ");
                    Console.WriteLine(arrTestWord);
                    Console.ResetColor();

                    //Wrong guessed chars
                    if (wrongGuessedChar.ToString() != "" && trigger2)
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("Guessed wrong with {1} ", wrongGuessedChar.Length, wrongGuessedChar.ToString());
                        Console.ResetColor();
                    }

                    //Break if done
                    string tempWord1 = new string(arrSecretWord);
                    string tempWord2 = new string(arrTestWord);
                    if (tempWord1 == tempWord2)
                    {
                        i = guessLimit;
                        //break;
                    }
                }

                //Endgame
                if (guessCount < guessLimit)
                {
                    //Wins the game
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nYou found the word {0} and won the game!", secretWord);
                    Console.ResetColor();
                }
                else
                {
                    //Lost the game
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("The secret word is {0}.", secretWord);
                    Console.WriteLine("You lost, better luck next time!", secretWord);
                    Console.ResetColor();
                }

                try
                {
                    bool tempLoop = true;
                    while (tempLoop)
                    {
                        Console.Write("Play again? (y/n)");
                        char answer = char.Parse(Console.ReadLine());
                        if (answer == 'n' || answer == 'N')
                        {
                            keepLooping = false;
                            tempLoop = false;
                        }
                        else if (answer == 'y' || answer == 'Y')
                        {
                            tempLoop = false;
                        }
                        else
                        {
                            Console.WriteLine("Not a valid answer!");
                        }
                    }
                }
                catch
                {
                    Console.WriteLine("Not a valid answer!");
                }
            }
        }
    }
}
