using System;
using System.Collections.Generic;
using System.Text;

namespace BowlingGameScore
{
    public class BowlingGame
    {
        public int Score { get; set; }

        public void Roll (int pins)
        {
            Score += pins;
        }
    }
}
