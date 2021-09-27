using System;

namespace Hangman
{
    class Program
    {
        static void Main(string[] args)
        {
            //Declare variables
            bool keepLooping = true;


            char[] guessWord;  
            char[] testWord;    //Progress on guess word
            char[] secretWord;  //Word to guess on
            
            char guessChar;
            int guessCount = 0, guessLimit = 10;
                        
            //Convert "secretWord" to char array
            secretWord = SecretWordList.SecretWord().ToCharArray();

            //Count letters "secretWord"
            int wordLength = MyCodeTools.CountChar(secretWord);
            testWord = new char[wordLength];

            //Prepare "guessWord"
            guessWord = secretWord;            

            //Prepare "testWord"
            string tempString = "";
            for(int i = 0; i < wordLength; i++)
            {
                tempString = tempString.Insert(i, "_");
            }
            testWord = tempString.ToCharArray();

            //Show secret word
            Console.Write("Secret word is ");
            foreach(char items in secretWord)
            {
                Console.Write(items);
            }
            Console.WriteLine();


            //Playing the game        

            for (int i = 0; i < guessLimit; i++)
            {
                //Copy char[] secretWord
                char[] copy = secretWord;
                //int guessIndex = 0;

                Console.WriteLine("Guesscount: {0}", guessCount);
                Console.Write("Please enter a letter to guess: ");
                guessChar = char.Parse(Console.ReadLine().ToUpper());
                    
                bool right = false;
                for (int j = 0; j < copy.Length; j++)
                {
                    if (copy[j] == guessChar)
                    {
                        Console.WriteLine("Your guess is correct.");                            
                        testWord[j] = guessChar;
                        //guessWord[guessIndex] = guessChar;
                        //guessIndex++;
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

                Console.WriteLine(testWord);

                //Break if done
                string tempWord1 = new string(secretWord);
                string tempWord2 = new string(testWord);
                if (tempWord1 == tempWord2)
                {
                    //i = guessLimit;
                    break;
                }                
            } 
        }
    }
}
