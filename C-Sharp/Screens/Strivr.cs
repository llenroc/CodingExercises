using System;
using System.Collections.Generic;

// A game of bowling consists of 10 parts called "frames"
// In each frame a player has 2 bowls with which they can knock down up to 10 pins
// Each frame is scored as the number of pins that are knocked down
// When all 10 pins are knocked down over the course of 2 bowls in a frame, that's called a spare
// A spare is scored as the pins knocked down (10) + the next bowl
// When all 10 pins are knocked down by the first bowl of a frame, that's called a strike
// A strike is scored as the pins knocked down (10) + the next 2 bowls

// 1, 2 | 3, 4 | 4, 5
//    3      10    19

// 3, 7 | 2, 6
//   12    20

// 9, 1 | 5, 3
//    15    23

// 10 | 7, 2
// 19     28

// 10 | 5, 3
// 18     26

// 10 | 10 | 5, 4
// 25    44   53

namespace InterviewCake
{
    public class Strivr
    {
        // This method is WRONG
        public static int GetScore(List<int[]> frames)
        {
            var result = 0;
            var isSpare = false;
            var isStrike = false;
            var ballCount = 0;
            
            foreach (var entry in frames)
            {
                var currentScore = entry[0] != 10 ? entry[0] + entry[1] : entry[0]; // frame has 2 balls
                result += currentScore;
                if (isSpare)
                {
                    result += entry[0];
                    isSpare = false;
                }
                
                if (currentScore == 10)
                {
                    isSpare = true;
                }
                
                if (isStrike)
                {
                    if (entry[0] != 10) 
                    {
                        result += entry[0] + entry[1];
                        ballCount += 2;
                    }
                    else if (ballCount < 2)
                    {
                        result += entry[0];
                        ballCount++;
                    }

                    // reset counter
                    if (ballCount == 2)
                    {
                        ballCount = 0;
                    }
                }
                
                isStrike = entry[0] == 10;
            }
            
            return result;
        }
    
        public static void GetPlayerScoreTest()
        {
            // 10 | 10 | 5, 4
            // 25    44   53    
            var frames = new Frame[] {
                new Frame { Balls = new [] { 10, 0 } },
                new Frame { Balls = new [] { 10, 0 } },
                new Frame { Balls = new [] { 5, 4 } }
            };
            
            // 10 | 10 | 10
            // 30   50   60    
            // var frames = new Frame[] {
            //     new Frame { Balls = new [] { 10, 0 } },
            //     new Frame { Balls = new [] { 10, 0 } },
            //     new Frame { Balls = new [] { 10, 0 } }
            // };

            var result = GetPlayerScore(frames);

            System.Console.WriteLine(result);
        }

        public static int GetPlayerScore(Frame[] frames)
        {
            var result = 0;

            // input check
            if (frames == null || frames.Length == 0) return result;

            for (var i = 0; i < frames.Length; i++)
            {
                result += frames[i].IsLast ? GetSpecialScore(i, frames) : GetCurrentScore(i, frames);

                if (frames[i].IsStrike)
                {
                    result += GetAdditionalStrikeScore(i, frames);
                }
                else if (frames[i].IsSpare)
                {
                    result += GetAdditionalSpareScore(i, frames);
                }
            }

            return result;
        }
    
        private static int GetAdditionalStrikeScore(int i, Frame[] frames)
        {
            // index check
            if (i == frames.Length - 1) return 0;

            var result = frames[i + 1].Balls[0];

            if (!frames[i + 1].IsStrike)
            {
                result += frames[i + 1].Balls[1];
            }
            else if (frames[i + 1].IsStrike && i < frames.Length - 2)
            {
                result += frames[i + 2].Balls[0];
            }

            return result;
        }

        private static int GetAdditionalSpareScore(int i, Frame[] frames)
        {
            return (i == frames.Length - 1) ? 0 : frames[i + 1].Balls[0];
        }

        private static int GetCurrentScore(int i, Frame[] frames)
        {
            return frames[i].Balls[0] + frames[i].Balls[1];
        }

        private static int GetSpecialScore(int i, Frame[] frames)
        {
            // TODO
            return GetCurrentScore(i, frames);
        }
    }

    public class Frame
    {
        public int PlayerId { get; set; }
        public int[] Balls { get; set; }
        public bool IsStrike
        { 
            get
            {
                return Balls != null && Balls[0] == 10;
            }
        }
        public bool IsSpare 
        { 
            get
            {
                return Balls != null && Balls[0] + Balls[1] == 10;
            }
        }
        public bool IsLast { get; set; }

        public Frame(int playerId)
        {
            PlayerId = playerId;
            Balls = new int[2];
        }

        public Frame()
        {
            Balls = new int[2];
        }
    }
}