using System;

namespace PigLatin
{
    class Program
    {
       // private const int V = 1;

        public static void Main()
        {
            // your code goes here
            Console.WriteLine("Welcome to Pig Latin, or should I say igPay atinLay");
            Console.WriteLine("Please feel free to write any kind of sentance");
            Console.WriteLine("PigLatin: ");

            string userInput = Console.ReadLine();
            TranslateWord(userInput);


            // leave this command at the end so your program does not close automatically
            Console.ReadLine();
        }

        public static string TranslateWord(string word)
        {
            //all words to lower case for easy setup
            word = word.ToLower();
            //all words the user created broken up
            string[] wordBank = word.Split(' ');
            //all vowels to check for
            char[] vowelPool = new char[] { 'a', 'e', 'i', 'o', 'u' };
            //all consonants to check for
            char[] consonantPool = new char[] { 'b', 'c', 'd', 'f', 'g', 'h'
                                                , 'j', 'k', 'l', 'm', 'n'
                                                , 'p', 'q', 'r', 's', 't'
                                                , 'v', 'w', 'x', 'y', 'z'};
            //Temporary string to hold currently changing word
            string currentWord = wordBank[0];
            string translatedPigLatin = "";

            //Broken up string variables and int variables
            string firstHalf = "";
            string secondHalf = "";
            int brokenIndex = 0;

            //Check through all words the user input, broken up into wordBank
            for (int currentIndex = 0; currentIndex < wordBank.Length; currentIndex ++)
            {
                //every iteration of the for loop set the new word to the next index
                //according with the currentIndex counter
                currentWord = wordBank[currentIndex];

                //if the first and last letter is a vowel
                if(currentWord.IndexOfAny(vowelPool) == 0 && currentWord.IndexOfAny(vowelPool) == currentWord.Length -1)
                {
                    //Console.WriteLine("Both Begining and end have a vowel");
                    translatedPigLatin = translatedPigLatin + " " + currentWord + "ay";
                }
                //if the first letter is a vowel and the last letter is a consonant
                else if(currentWord.IndexOfAny(vowelPool) == 0 && currentWord.IndexOfAny(consonantPool) == currentWord.Length -1)
                {
                    //Console.WriteLine("Begining is a vowel, the end is a consonant");
                    translatedPigLatin = translatedPigLatin + " " + currentWord + "ay";
                }
                //starts with consonant and has a vowel after
                else if(currentWord.IndexOfAny(consonantPool) == 0)
                {
                    //Console.WriteLine("There is a consonant at the begining of my word");

                    //if there is a vowel on the word find it
                    if(currentWord.IndexOfAny(vowelPool) != -1)
                    {
                        //Grab the index of the first vowel
                        brokenIndex = currentWord.IndexOfAny(vowelPool);
                        //grab all char before first value
                        firstHalf = currentWord.Substring(0, brokenIndex);
                        //grab all char after first value
                        secondHalf = currentWord.Substring(brokenIndex, currentWord.Length - brokenIndex);
                        //add the first half after the second half
                        currentWord = secondHalf + firstHalf;
                        //add word to our translated product
                        translatedPigLatin = translatedPigLatin + " " + currentWord + "ay";

                    }
                    else
                    {
                        continue;
                    }
                }
                //if there are no vowels
                else
                {
                    //Console.WriteLine("No Vowels");

                    translatedPigLatin = translatedPigLatin + " " + currentWord + "ay";
                }

            }
            

            Console.WriteLine("Translated: " + translatedPigLatin);
            return word;
        }
    }
}
