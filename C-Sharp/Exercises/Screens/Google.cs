using System;
using System.Collections.Generic;

namespace Exercises
{
    public class Google
    {
        /*
        Jotto is a game similar to Mastermind, where the mastermind chooses a master word 
        (a five letter English word with distinct letters).
        The other player guesses five letter English words with distinct letters.
        The mastermind responds with the number of letters that the guess and the master word have in common,
        and the number of letters that are in the right place.
        The game ends when the other player guesses the master word.
        
        Example score:
        MM:      "girls"
        Guesser: "lakes" => {2, 1}
        
        Write me a function, that given a mastermind word and a guess word, returns a score.
        */
        public int[] GetScore(string mm, string guesser)
        {
            var mmHashSet = new HashSet<char>(mm.ToCharArray());
            var result = new int[2];
            var iCounter = 0;
            var matcherCounter = 0;

            var imm = 0;
            for (var i = 0; i < guesser.Length; i++)
            {
                if (guesser[i].Equals(mm[i]))
                {
                    iCounter++;
                }

                if (mmHashSet.Contains(guesser[i]))
                {
                    matcherCounter++;
                }
                imm++;
            }
            result[0] = matcherCounter;
            result[1] = iCounter;

            return result;
        }
    }
}


