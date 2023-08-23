using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace BowlingGameV3
{
    public class Frame
    {
        public string Rolls { get; set; }
        public bool Strike => Rolls.ToLower() == "x";
        public bool Spare => Rolls.Contains("/");
        public bool Miss => Rolls.Contains("-");

        public Frame(string rolls)
        {
            Rolls = rolls;
        }

        public int calcFrame(Frame next, Frame nextNext)
        {
            int score = 0;
            if (Strike)
            {
                score += 10;
                if (next != null)
                {
                    score += StrikeBonus(next, nextNext);
                }
            }
            else if (Spare)
            {
                score += 10;
                if (next != null)
                {
                    score += SpareBonus(next);
                }
            }
            else
            {
                foreach (char x in Rolls)
                {
                    if (x == '-')
                    {
                        score += 0;
                    }
                    else
                    {
                        score += int.Parse(x.ToString());
                    }
                }
            }
            return score;
        }

        public int StrikeBonus(Frame next, Frame nextNext)
        {
            if (nextNext == null) { return 10; }
            int bonus = 0;
            if (next.Strike)
            {
                bonus += 10;
                if (nextNext.Strike)
                {
                    bonus += 10;
                    return bonus;
                }else if (nextNext.Spare) 
                {
                    bonus += SpareBonus(next);
                    return bonus;
                }else if (next.Miss)
                {
                    return bonus;
                }
                else
                {
                    bonus += int.Parse(Rolls[0].ToString());
                    return bonus;
                }
                
            }
            else if (next.Spare)
            {
                bonus+= SpareBonus(next);
                return bonus;
            }
            else
            {
                return int.Parse(Rolls[0].ToString());
            }
        }

        public int SpareBonus(Frame next)
        {
            
            if (next.Miss) 
            {
                return 0;
            }else if (next.Strike) 
            {
                return 10;
            }
            else
            {
                return int.Parse(Rolls[0].ToString()) ;
            }

        }


    }
}
