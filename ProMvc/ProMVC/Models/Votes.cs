using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProMVC.Models
{
    public enum Color
    {
        Red,
        Green,
        Yellow,
        Purple
    }

    public class Votes
    {
        private static Dictionary<Color,int> votes = new Dictionary<Color, int>();

        public static void RecordVote(Color color)
        {
            votes[color] = votes.ContainsKey(color) ? votes[color] + 1 : 1;
        }

        public static void ChangeVote(Color newColor, Color oldColor)
        {
            if (votes.ContainsKey(oldColor))
            {
                votes[oldColor]--;
                if (votes[oldColor] < 0)
                {
                    votes[oldColor] = 0;
                }
            }

            RecordVote(newColor);
        }

        public static int GetVotes(Color color)
        {
            return votes.ContainsKey(color) ? votes[color] : 0;
        }
    }
}