using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hangman
{
    class MyCodeTools
    {
        public static int CountChar(char[] word)
        {
            int charCount = 0;

            charCount = word.Count();

            return charCount;
        }        
    }
}
