using System;

namespace Hangman
{
    class Program
    {
        static void Main(string[] args)
        {
            //Declare variables
            bool keepLooping = true;


            char[] arrGuessWord;  
            char[] arrTestWord;    //Progress on guess word
            char[] arrSecretWord;  //Word to guess on

            string guessWord;
            char guessChar;
            string secretWord;
            int guessCount = 0, guessLimit = 10;
                        
            //Convert "secretWord" to char array
            arrSecretWord = SecretWordList.SecretWord().ToCharArray();

            //Count letters "secretWord"
            int wordLength = MyCodeTools.CountChar(arrSecretWord);
            arrTestWord = new char[wordLength];

            //Prepare "guessWord"
            arrGuessWord = arrSecretWord;            

            //Prepare "testWord"
            string tempString = "";
            for(int i = 0; i < wordLength; i++)
            {
                tempString = tempString.Insert(i, "_");
            }
            arrTestWord = tempString.ToCharArray();

            //Show secret word
            Console.Write("Secret word is ");
            foreach(char items in arrSecretWord)
            {
                Console.Write(items);
            }
            Console.WriteLine();


            //Playing the game

            for (int i = 0; i < guessLimit; i++)
            {
                //Copy char[] secretWord
                char[] copy = arrSecretWord;
                int guessIndex = 0;

                Console.WriteLine("Guesscount: {0}", guessCount);
                Console.Write("Please enter a letter or word to guess: ");
                               
                //Input a guess                
                guessWord = Console.ReadLine().ToUpper();

                if (guessWord.Length > 1)
                {
                    secretWord = new string(arrSecretWord);

                    if (guessWord == secretWord)
                    {
                        Console.WriteLine("Guessed correct!");
                        i = guessLimit;
                    }
                    else
                    {
                        Console.WriteLine("Wrong guess!");
                        guessCount++;
                    }
                
                }
                else if (guessWord.Length == 1)
                {
                    //Guess a Char
                    //guessChar = char.Parse(Console.ReadLine().ToUpper());
                    guessChar = char.Parse(guessWord);
                    bool right = false;
                    for (int j = 0; j < copy.Length; j++)
                    {
                        if (copy[j] == guessChar)
                        {
                            Console.WriteLine("Your guess is correct.");
                            arrTestWord[j] = guessChar;
                            right = true;

                        }
                    }

                    if (right != true)
                    {
                        Console.WriteLine("Your guess is incorrect.");
                        guessCount++;
                    }
                    else
                    {
                        i--;
                        right = false;
                    }

                    Console.WriteLine(arrTestWord);

                    //Break if done
                    string tempWord1 = new string(arrSecretWord);
                    string tempWord2 = new string(arrTestWord);
                    if (tempWord1 == tempWord2)
                    {
                        //i = guessLimit;
                        break;
                    }
                }
            } 
        }
    }
}
