package org.practice;


import java.util.*;

/***
 * This Class contains exercises and coding questions asked during Screen Interviews
 */
public class Screen {

    /***
        Problem Description:
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

        Company: GOOGLE 
     */
    public static int[] google_getScore(final String mm, final String guesser) throws Exception {
        if (mm == null || mm.length() == 0 || guesser == null || guesser.length() == 0) {
            throw new Exception("error");
        }

        final int[] result = new int[2];
        result[0] = -1;
        result[1] = -1;

        int matchPossCounter = 0;
        int matchCharCounter = 0;
        HashSet<Character> mmSet = new HashSet<Character>();

        for (Character character : mm.toCharArray()) {
            mmSet.add(character);
        }

        for (int i = 0; i < 5; i++) {
            if (mm.charAt(i) == guesser.charAt(i)) {
                matchPossCounter++;
            }
            if (mmSet.contains(guesser.charAt(i))) {
                matchCharCounter++;
            }
        }

        result[0] = matchCharCounter;
        result[1] = matchPossCounter;

        return result;
    }
}