using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImGen
{
    class Game
    {
        public string Division = "";
        public string HomeTeam = "";
        public string AwayTeam = "";
        public string ScorePeriods = "";
        public string Score = "";

        public Game(List<string> list)
        {
            Division = list[1];
            list[2] = list[2].Replace(" ", "");

            var s = list[2].Split('-');
            HomeTeam = s[0];
            AwayTeam = s[1];
            ScorePeriods = list[3];
            Score = list[4];
        }


    }
}
