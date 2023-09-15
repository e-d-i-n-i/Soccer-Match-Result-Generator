using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerMatches2
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 4; // Number of matches
            List<Match> matches = new List<Match>();
            for (int i = 0; i < n; i++)
            {
                Console.Write("Enter team 1 name: ");
                string team1 = Console.ReadLine();
                Console.Write("Enter team 2 name: ");
                string team2 = Console.ReadLine();
                Console.Write("Enter odds for team 1 win: ");
                double odds1 = double.Parse(Console.ReadLine());
                Console.Write("Enter odds for draw: ");
                double oddsD = double.Parse(Console.ReadLine());
                Console.Write("Enter odds for team 2 win: ");
                double odds2 = double.Parse(Console.ReadLine());
                matches.Add(new Match(team1, team2, odds1, oddsD, odds2));
            }
            List<string> outcomes = new List<string>();
            CalculateOutcomes(n, "", outcomes);
            foreach (string outcome in outcomes)
            {
                Console.WriteLine(outcome);
                double totalOdds = 1;
                for (int i = 0; i < n; i++)
                {
                    if (outcome[i] == 'W')
                    {
                        totalOdds *= matches[i].Odds1;
                        Console.WriteLine(matches[i].Team1 + " vs " + matches[i].Team2 + ": " + matches[i].Team1 + " wins");
                    }
                    else if (outcome[i] == 'D')
                    {
                        totalOdds *= matches[i].OddsD;
                        Console.WriteLine(matches[i].Team1 + " vs " + matches[i].Team2 + ": Draw");
                    }
                    else
                    {
                        totalOdds *= matches[i].Odds2;
                        Console.WriteLine(matches[i].Team1 + " vs " + matches[i].Team2 + ": " + matches[i].Team2 + " wins");
                    }
                }
                Console.WriteLine("Total Odds: " + totalOdds);
            }
        }

        static void CalculateOutcomes(int n, string outcome, List<string> outcomes)
        {
            if (n == 0)
            {
                outcomes.Add(outcome);
                return;
            }
            CalculateOutcomes(n - 1, outcome + "W", outcomes);
            CalculateOutcomes(n - 1, outcome + "D", outcomes);
            CalculateOutcomes(n - 1, outcome + "L", outcomes);
        }
    }

    class Match
    {
        public string Team1 { get; set; }
        public string Team2 { get; set; }
        public double Odds1 { get; set; }
        public double OddsD { get; set; }
        public double Odds2 { get; set; }

        public Match(string team1, string team2, double odds1, double oddsD, double odds2)
        {
            Team1 = team1;
            Team2 = team2;
            Odds1 = odds1;
            OddsD = oddsD;
            Odds2 = odds2;
        }
    }
}
