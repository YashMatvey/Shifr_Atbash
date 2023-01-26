using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shifr_Atbash
{
    internal class CifrAtbash
    {
        public string ChifrA(string Text)
        {    
            string AlphabetRus =  "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
            string AlphabetRusUp ="АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
            string Alphabet = "abcdefghijklmnopqrstuvwxyz";
            string AlphabetUp = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string result = "";
            foreach (char c in Text)
            {
                int count = 0;
                for (int i = 0; i < Alphabet.Length; i++)
                {
                    if (c == Alphabet[i])
                    {
                        result += Alphabet[Alphabet.Length - 1 - i];
                    }
                    if (c == AlphabetUp[i])
                    {
                        result += AlphabetUp[AlphabetUp.Length - 1 - i];
                    }
                    // если символ не принадлежит алфавмту 
                    if (c != Alphabet[i] || c != AlphabetUp[i])
                    {
                        for (int k = 0; k < Alphabet.Length; k++)
                        {
                            if (c == Alphabet[k])
                            {
                                count++;
                            }
                            if (c == AlphabetUp[k])
                            {
                                count++;
                            }
                        }
                    }
                }
                for (int j = 0; j < AlphabetRus.Length; j++)
                {
                    if (c == AlphabetRus[j])
                    {
                        result += AlphabetRus[AlphabetRus.Length - 1 - j];
                    }
                    if (c == AlphabetRusUp[j])
                    {
                        result += AlphabetRusUp[AlphabetRusUp.Length - 1 - j];
                    }
                    // если символ не принадлежит алфавмту 
                    if (c != AlphabetRus[j] || c != AlphabetRusUp[j])
                    {
                        for (int k = 0; k < AlphabetRus.Length; k++)
                        {
                            if (c == AlphabetRus[k])
                            {
                                count++;
                            }
                            if (c == AlphabetRusUp[k])
                            {
                                count++;
                            }
                        }
                    }
                }
                if (count == 0)
                {
                    result += c;
                }
            }
            return result;
        }
    }
}
