using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hangman
{
    class SecretWordList
    {
        public static string SecretWord()
        {
            //Declare variables
            string secretWord = "";            
            Random rnd = new Random();
            string[] arrayWords;

            // Creating an List<T> of strings 
            List<string> SecretWord = new List<string>();

            // Adding elements to List 
            SecretWord.Add("hänga");
            SecretWord.Add("skal");
            SecretWord.Add("polis");
            SecretWord.Add("sand");
            SecretWord.Add("frukt");
            SecretWord.Add("strand");
            SecretWord.Add("sparkcykel");
            SecretWord.Add("bord");
            SecretWord.Add("stol");
            SecretWord.Add("apelsin");
            
            //Convert list to array (assignment requirement)            
            arrayWords = SecretWord.ToArray();

            //Choose random "secretWord" from "arrayWord"
            int index = rnd.Next(arrayWords.Count());
            secretWord = arrayWords[index];            
            
            //Return capital letters string
            secretWord = secretWord.ToUpper();

            return secretWord;
        }
    }
}
