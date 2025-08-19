using System.ComponentModel.Design;
using System.Runtime.InteropServices;
using System.Text;

namespace Assignment_7._2._2
{
    //Given a string s, reverse only the vowels in the string and return it
    //Status: Complete however edge cases cause problems like only consonants
    internal class Program
    {
        static void Main(string[] args)
        {
            string test1 = "pet";
            string test2 = "avacado";
            string test3 = "intelligent";
            string test4 = "IceCreAm";

            Console.WriteLine(ReverseVowels(test1));
            Console.WriteLine(ReverseVowels(test2));
            Console.WriteLine(ReverseVowels(test3));
            Console.WriteLine(ReverseVowels(test4));
            Console.ReadKey();
        }
        //should make a hashset with vowels, upper and lower case in them
        //use two pointers one at each end of the string s
        //create the new string with stringbuilder
        //while leftP and rightP aren't equal
        //start with leftP - while leftP isn't in hashset -> write to sb then increment leftP
        // -- when reach a vowel exit while loop
        //while rightP isn't in hashset --> write to sb2 then decrement rightP
        // -- when reach a vowel exit while loop
        //swap leftP and rightP vowels
        //merge sb and sb2 at the end
        static string ReverseVowels(string input)
        {
            if (input.Length == 1) return input; //case of a single char
            HashSet<char> vowels = new HashSet<char> { 'a', 'A', 'e', 'E', 'i', 'I', 'o', 'O', 'u', 'U' };
            StringBuilder sb = new StringBuilder(input.Length);
            StringBuilder sbRight = new StringBuilder(input.Length);
            
            int leftP = 0;
            int rightP = input.Length - 1;
            if (input.Length == 2) //edge case
            {
                if (vowels.Contains(input[leftP]) && vowels.Contains(input[rightP]))
                    return sb.Append(input[rightP]).Append(input[leftP]).ToString();
                else return input;
            }
            while (leftP < rightP)
            {
                while (!vowels.Contains(input[leftP]))
                {                    
                    sb.Insert(leftP, input[leftP]);
                    leftP++;
                    if (leftP > rightP) break; //prevents duplication of consonants
                }
                while (!vowels.Contains(input[rightP]))
                {
                    if (leftP > rightP) break; //prevents duplication of consonants
                    sbRight.Insert(0, input[rightP]);
                    rightP--;
                    
                }
                if (leftP < rightP) 
                { 
                sb.Insert(leftP, input[rightP]);
                sbRight.Insert(0, input[leftP]);
                leftP++;
                rightP--;
                if (leftP == rightP) sb.Insert(leftP, input[leftP]); // case where one consonant between two vowels in the center
                }
            }
            return sb.Append(sbRight).ToString();
        }
    }
}
