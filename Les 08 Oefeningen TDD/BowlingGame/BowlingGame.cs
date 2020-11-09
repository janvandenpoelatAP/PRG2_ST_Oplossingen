using System;
using System.Collections.Generic;
using System.Text;

namespace BowlingGameScore
{
    public class BowlingGame
    {
        private int[] pins = new int[21];  // het aantal omgeworpen kegels per worp (maximaal 21 worpen laatste frame een spare + 1 of strike + 2;
        private int currentRoll = 0;       // teller van het aantal worpen die de gebruiker heeft gedaan
        
        public int Score
        {
            get 
            {
                int score = 0;
                int rollIndex = 0;
                for (int frame = 0; frame < 10; frame++) // loop over het aantal worpen
                {
                    if (IsSpare(rollIndex)) // Spare
                    {
                        score += GetSpareScore(rollIndex);
                    }
                    else
                    {
                        score += GetStandardScore(rollIndex);
                    }
                    rollIndex += 2;
                }

                return score;
            }
        }

        private int GetStandardScore(int rollIndex)
        {
            return pins[rollIndex] + pins[rollIndex + 1];
        }

        private int GetSpareScore(int rollIndex)
        {
            return pins[rollIndex] + pins[rollIndex + 1] + pins[rollIndex + 2];
        }

        private bool IsSpare(int rollIndex)
        {
            return pins[rollIndex] + pins[rollIndex + 1] == 10;
        }

        public void Roll (int pinsThisRoll)
        {
            pins[currentRoll++] = pinsThisRoll;
        }
    }
}
