using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hangman
{
    class SecretWords
    {
        public static string SecretWord()
        {
            //Declare variables
            string secretWord = "";            
            Random rnd = new Random();
            

            // Creating an List<T> of strings 
            List<string> secretWordList = new List<string>();

            // Adding elements to List 
            secretWordList.Add("hängmatta");
            secretWordList.Add("papper");
            secretWordList.Add("solsken");
            secretWordList.Add("sandstrand");
            secretWordList.Add("fruktsallad");
            secretWordList.Add("efterrätt");
            secretWordList.Add("sparkcykel");
            secretWordList.Add("satellit");
            secretWordList.Add("paprika");
            secretWordList.Add("apelsin");

            //Choose random "secretWord" from the "secretWordList"
            int index = rnd.Next(secretWordList.Count());
            //Console.WriteLine(index);
            secretWord = secretWordList[index];

            return secretWord;
        }
    }
}
