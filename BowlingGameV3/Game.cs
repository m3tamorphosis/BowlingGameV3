using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingGameV3
{
    public class Game
    {
        private List<Frame> frames = new List<Frame>();
        private int arrLength = 0;
        public void Frames(string input)
        {
            string[] arr = input.Split(' ');
            arrLength = arr.Length;
            for (int i = 0; i < arr.Length; i++) 
            {
                
                frames.Add(new Frame(arr[i]));
            }

        }
        public int TotalScore()
        {
            
            int score = 0;
            for (int i = 0; i < arrLength && i<10; i++)
            {
                
                score += frames[i].calcFrame(GetNext(i), GetNextNext(i));
            }
            return score;
        }
        public Frame GetNext(int index)
        {
            if (index < arrLength-1 )
            {
                return frames[index + 1];
            }
            else { return null; }
        }
        public Frame GetNextNext(int index)
        {
            if (index < arrLength - 2)
            {
                return frames[index + 2];
            }
            else { return null; }
        }


    }
}
